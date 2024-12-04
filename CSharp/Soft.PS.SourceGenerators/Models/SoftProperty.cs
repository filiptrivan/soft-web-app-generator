﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.SourceGenerators.Models
{
    public class SoftProperty
    {
        public string Type { get; set; }
        public string IdentifierText { get; set; }
        public string ClassIdentifierText { get; set; } // TODO FT: Add to every case, you didn't finished this, but it works for now.


        public List<SoftAttribute> Attributes = new List<SoftAttribute>();
        public string Project { get; set; } // FT: Used only for ng controllers generator when we need to import classes from the different assebmlies
    }
}
