﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public decimal UnitPrice { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
        public int CategoryId { get; set; }

    }
}
