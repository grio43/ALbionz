﻿using System;
using System.IO;
using System.Text;
using SharedComponents.EveMarshal.Python;

namespace SharedComponents.EveMarshal
{

    public class PyString : PyRep
    {
        public string Value { get; private set; }
        public byte[] Raw { get; private set; }
        public bool ForceUTF8 { get; private set; }
        public MarshalOpcode opCode = MarshalOpcode.Error;
        public int tableIndex = -1;
        private bool decodedAnalized = false;

        public PyString()
            : base(PyObjectType.String)
        {
        }

        public PyString(string data)
            : base(PyObjectType.String)
        {
            Raw = Encoding.ASCII.GetBytes(data);
            Value = data;
        }

        public PyString(string data, bool forceUTF8)
            : base(PyObjectType.String)
        {
            Raw = Encoding.UTF8.GetBytes(data);
            Value = data;
            ForceUTF8 = forceUTF8;
        }

        public PyString(byte[] raw)
            : base(PyObjectType.String)
        {
            Raw = raw;
            Value = Encoding.ASCII.GetString(raw);
        }

        private void Update(string data)
        {
            Raw = Encoding.ASCII.GetBytes(data);
            Value = data;
        }

        private void Update(byte[] data, bool isUnicode = false)
        {
            Raw = data;
            Value = isUnicode ? Encoding.Unicode.GetString(Raw) : Encoding.ASCII.GetString(Raw);
        }

        private void UpdateUTF8(byte[] data)
        {
            Raw = data;
            Value = Encoding.UTF8.GetString(Raw);
        }

        public override void Decode(Unmarshal context, MarshalOpcode op)
        {
            decodedAnalized = context.analizeInput;
            opCode = op;
            if (op == MarshalOpcode.StringEmpty)
                Update(new byte[0]);
            else if (op == MarshalOpcode.StringChar)
                Update(new[]{context.reader.ReadByte()});
            else if (op == MarshalOpcode.WStringUTF8)
                UpdateUTF8(context.reader.ReadBytes((int)context.reader.ReadSizeEx()));
            else if (op == MarshalOpcode.WStringUCS2Char)
                Update(new[]{context.reader.ReadByte(), context.reader.ReadByte()}, true);
            else if (op == MarshalOpcode.WStringEmpty)
                Update(new byte[0]);
            else if (op == MarshalOpcode.WStringUCS2)
                Update(context.reader.ReadBytes((int)context.reader.ReadSizeEx() * 2), true);
            else if (op == MarshalOpcode.StringShort)
                Update(context.reader.ReadBytes(context.reader.ReadByte()));
            else if (op == MarshalOpcode.StringLong)
                Update(context.reader.ReadBytes((int)context.reader.ReadSizeEx()));
            else if (op == MarshalOpcode.StringTable)
            {
                tableIndex = context.reader.ReadByte();
                Update(StringTable.Entries[tableIndex-1]);
            }
        }

        protected override void EncodeInternal(BinaryWriter output)
        {
            if (ForceUTF8)
            {
                output.WriteOpcode(MarshalOpcode.WStringUTF8);
                output.WriteSizeEx(Raw.Length);
                output.Write(Raw);
                return;
            }

            int idx;
            if (Raw.Length == 0)
                output.WriteOpcode(MarshalOpcode.StringEmpty);
            else if (Raw.Length == 1)
            {
                output.WriteOpcode(MarshalOpcode.StringChar);
                output.Write(Raw[0]);
            }
            else if ((idx = StringTable.Entries.IndexOf(Value)) >= 0)
            {
                output.WriteOpcode(MarshalOpcode.StringTable);
                output.Write((byte)(idx+1));
            }
            else
            {
                /*if (Raw.Length < 0xFF)
                {
                    output.WriteOpcode(MarshalOpcode.StringShort);
                    output.Write((byte)Raw.Length);
                    output.Write(Raw);
                }
                else*/
                {
                    output.WriteOpcode(MarshalOpcode.StringLong);
                    output.WriteSizeEx(Raw.Length);
                    output.Write(Raw);
                }
            }
        }

        public override string ToString()
        {
            if (Value.Length <= 0)
                return "<empty string>";
            if (char.IsLetterOrDigit(Value[0]) || Value[0] >= 32)
                return "<" + Value + ">";
            return "<" + BitConverter.ToString(Raw) + ">";
        }

        public override void dump(PrettyPrinter printer)
        {
            string name = "Unknown";
            if (opCode == MarshalOpcode.StringEmpty)
            {
                name = "PyStringEmpty";
            }
            else if (opCode == MarshalOpcode.StringChar)
            {
                name = "PyStringChar";
            }
            else if (opCode == MarshalOpcode.WStringUTF8)
            {
                name = "PyWStringUTF8";
            }
            else if (opCode == MarshalOpcode.WStringUCS2Char)
            {
                name = "PyWStringUCS2Char";
            }
            else if (opCode == MarshalOpcode.WStringEmpty)
            {
                name = "PyWStringEmpty";
            }
            else if (opCode == MarshalOpcode.WStringUCS2)
            {
                name = "PyWStringUCS2";
            }
            else if (opCode == MarshalOpcode.StringShort)
            {
                name = "PyString";
            }
            else if (opCode == MarshalOpcode.StringLong)
            {
                name = "PyString";
            }
            else if (opCode == MarshalOpcode.StringTable)
            {
                name = "PyStringTable[" + tableIndex.ToString() + "]";
            }

            bool printed = false;
            if (Raw.Length > 0 && (Raw[0] == (byte)Unmarshal.ZlibMarker || Raw[0] == (byte)Unmarshal.HeaderByte || Raw[0] == Unmarshal.PythonMarker || Raw[0] == 0x63))
            {
                // We have serialized python data, decode and display it.
                byte[] d = Raw;
                if (d[0] == Unmarshal.ZlibMarker)
                {
                    d = Zlib.Decompress(d);
                }
                if (d != null && (d[0] == Unmarshal.PythonMarker || d[0]== 0x63) && printer.decompilePython && d.Length > 60)
                {
                    // We have a python file.
                    Bytecode code = new Bytecode();
                    if (code.load(d, d[0] == 0x63))
                    {
                        printer.addLine("[" + name);
                        Python.PrettyPrinter pp = new Python.PrettyPrinter();
                        pp.indent = printer.indent;
                        pp.indentLevel = printer.indentLevel + 1;
                        code.dump(pp);
                        printer.addLine(pp.dump);
                        printer.addLine("]");
                        printed = true;
                    }
                }
                else if(d != null && d[0] == Unmarshal.HeaderByte)
                {
                    Unmarshal un = new Unmarshal();
                    un.analizeInput = decodedAnalized;
                    PyRep obj = un.Process(d, this);
                    if(obj != null)
                    {
                        string sType = "<serialized>";
                        if(Raw[0] == Unmarshal.ZlibMarker)
                        {
                            sType = "<serialized-compressed>";
                        }
                        printer.addLine("[" + name + " " + sType);
                        printer.addItem(obj);
                        printer.addLine("]");
                        printed = true;
                    }
                }
            }
            if (!printed)
            {
                if (!PrettyPrinter.containsBinary(Raw))
                {
                    printer.addLine("[" + name + " \"" + Value + "\"]");
                }
                else
                {
                    printer.addLine("[" + name + " \"" + Value + "\"");
                    printer.indentLevel += 2;
                    printer.addLine("<binary len=" + Value.Length + "> hex=\"" + PrettyPrinter.ByteArrayToString(Raw) + "\"]");
                    printer.indentLevel -= 2;
                }
            }
        }

    }

}