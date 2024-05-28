using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RallyBaneTest.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}