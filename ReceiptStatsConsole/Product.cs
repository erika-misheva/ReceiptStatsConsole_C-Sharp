﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptStatsConsole.DataAccess
{
    public class Product
    {
        public string Name { get; set; }    
        public bool Domestic { get; set; }
        public double Price { get; set; }
        public int? Weight { get; set; }
        public string Description { get; set; }
    }
}
