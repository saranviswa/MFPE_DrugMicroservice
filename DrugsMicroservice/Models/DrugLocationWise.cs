using System;
using System.ComponentModel.DataAnnotations;

namespace DrugsMicroservice.Models
{
    public class DrugLocationWise
    {
        [Key]
        public int Id { get; set; }
        public string DrugName { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }

    }
}
