﻿using System;
using System.IO;

namespace SharedComponents.EveMarshal.Extend
{
    class WrongMachoNode : ExtendedObject
    {
        public Int64 correctNode;
        /*
        * [PyObjectEx Normal]
        *   Header:
        *     [PyTuple 3 items]
        *       [PyToken carbon.common.script.net.machoNetExceptions.WrongMachoNode]
        *       [PyTuple 0 items]
        *       [PyDict 1 kvp]
        *         Key:[PyString "payload"]
        *         ==Value:[PyInt correctNode]
        *   List:
        *   Dictionary:
        */
        public WrongMachoNode(PyDict obj)
        {
            if(obj == null)
            {
                throw new InvalidDataException("WrongMachoNode: null dictionary.");
            }
            if(!obj.Contains("payload"))
            {
                throw new InvalidDataException("WrongMachoNode: Could not find key 'payload'.");
            }
            if(obj.Dictionary.Count > 1)
            {
                throw new InvalidDataException("WrongMachoNode: Too many values in dictionary.");
            }
            PyRep value = obj.Get("payload");
            correctNode = value.IntValue;
        }

        public override void dump(PrettyPrinter printer)
        {
            printer.addLine("[WrongMachoNode: correct node = " + correctNode + "]");
        }
    }
}
