﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharedComponents.EveMarshal
{
    
    public class PyList : PyRep, IEnumerable<PyRep>
    {
        public List<PyRep> Items { get; private set; }

        public PyList()
            : base(PyObjectType.List)
        {
            Items = new List<PyRep>();
        }

        public PyList(List<PyRep> items)
            : base(PyObjectType.List)
        {
            Items = items;
        }

        public override void Decode(Unmarshal context, MarshalOpcode op)
        {
            int count = -1;
            switch (op)
            {
                case MarshalOpcode.ListEmpty:
                    count = 0;
                    break;
                case MarshalOpcode.ListOne:
                    count = 1;
                    break;
                case MarshalOpcode.List:
                    count = (int)context.reader.ReadSizeEx();
                    break;
            }

            if (count >= 0)
            {
                Items = new List<PyRep>(count);
                for (int i = 0; i < count; i++)
                    Items.Add(context.ReadObject(this));
            }
        }

        protected override void EncodeInternal(BinaryWriter output)
        {
            if (Items.Count == 0)
                output.WriteOpcode(MarshalOpcode.ListEmpty);
            else
            {
                if (Items.Count == 1)
                    output.WriteOpcode(MarshalOpcode.ListOne);
                else
                {
                    output.WriteOpcode(MarshalOpcode.List);
                    output.WriteSizeEx(Items.Count);
                }

                foreach (var item in Items)
                    item.Encode(output);
            }
        }

        public IEnumerator<PyRep> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public override string ToString()
        {
            var sb = new StringBuilder("<\n");
            foreach (var obj in Items)
                sb.AppendLine("\t" + obj);
            sb.Append(">");
            return sb.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override void dump(PrettyPrinter printer)
        {
            printer.addLine("[PyList " + Items.Count + " items]" + PrettyPrinter.PrintRawData(this));
            foreach (var item in Items)
            {
                printer.addItem(item);
            }
        }

    }

}