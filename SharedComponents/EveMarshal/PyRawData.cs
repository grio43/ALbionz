﻿using System;
using System.IO;

namespace SharedComponents.EveMarshal
{

    /// <summary>
    /// Used to insert raw data into the marshal stream; not an actual blue marshal opcode
    /// </summary>
    public class PyRawData : PyRep
    {
        public byte[] Data { get; set; }

        public PyRawData()
            : base(PyObjectType.RawData)
        {
            
        }

        public PyRawData(byte[] data)
            : this()
        {
            Data = data;
        }

        public override void Decode(Unmarshal context, MarshalOpcode op)
        {
            throw new NotImplementedException();
        }

        protected override void EncodeInternal(BinaryWriter output)
        {
            output.Write(Data);
        }
        public override void dump(PrettyPrinter printer)
        {
            printer.addLine(PrettyPrinter.PrintRawData(this));
        }

    }

}