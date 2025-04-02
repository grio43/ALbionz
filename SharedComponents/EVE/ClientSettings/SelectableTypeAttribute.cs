﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.EVE.ClientSettings
{
    [AttributeUsage(AttributeTargets.All)]
    public class SelectableTypeAttribute : Attribute
    {
        public SelectableTypeAttribute(params Type[] types)
        {
            Types = types;
        }
        public Type[] Types { get; }
    }
}
