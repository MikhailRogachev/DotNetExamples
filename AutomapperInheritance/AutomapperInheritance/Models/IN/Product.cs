﻿using defProduct = AutomapperInheritance.Models;

namespace AutomapperInheritance.Models.IN
{
    public class Product : defProduct.Product
    {
        public new IReadOnlyCollection<Note> Notes { get; set; } = new List<Note>();
    }
}
