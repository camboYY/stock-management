using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcMovie.Models
{
    public class Rate
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Rate Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayName("Rate Value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        // Add more properties or relations as needed, for example, if you want to link to other models
    }
}
