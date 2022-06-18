using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrugsMicroservice.Models
{
    public class DrugList
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        [DataType(DataType.Date)]
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int UnitsPerPackage { get; set; }
        public double Cost { get; set; }
        public Dictionary<string, int> LocationWiseQty { get; set; }
    }
}
