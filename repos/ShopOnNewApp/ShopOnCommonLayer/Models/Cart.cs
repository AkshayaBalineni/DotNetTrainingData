﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnCommonLayer.Models
{
   public class Cart
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int Qty { get; set; }
    }
}
