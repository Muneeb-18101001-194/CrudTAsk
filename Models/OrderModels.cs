using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDTASK.Models
{
    public class OrderModels
    {

        [Key]

        public int id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Quantity { get; set; }

        public string Price { get; set; }
    }
}

