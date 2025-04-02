﻿using System.IO;

namespace SharedComponents.EveMarshal
{

    public class PyChecksumedStream : PyRep
    {
        public uint Checksum { get; private set; }
        public PyRep Data { get; private set; }

        public PyChecksumedStream(PyRep data)
            : base(PyObjectType.ChecksumedStream)
        {
            Data = data;
        }

        public PyChecksumedStream()
            : base(PyObjectType.ChecksumedStream)
        {
            
        }

        public override void Decode(Unmarshal context, MarshalOpcode op)
        {
            Checksum = context.reader.ReadUInt32();
            Data = context.ReadObject(this);
        }

        protected override void EncodeInternal(BinaryWriter output)
        {
            output.WriteOpcode(MarshalOpcode.ChecksumedStream);
            var ms = new MemoryStream();
            var tmp = new BinaryWriter(ms);
            Data.Encode(tmp);
            var data = ms.ToArray();
            Checksum = Adler32.Checksum(data);
            output.Write(Checksum);
            output.Write(data);
        }

        public override void dump(PrettyPrinter printer)
        {
            printer.addLine("[PyChecksumedStream Checksum: " + Checksum + "]");
            printer.addItem(Data);
        }
    }

}