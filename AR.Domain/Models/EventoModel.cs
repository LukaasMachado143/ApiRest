using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR.Domain.Models
{
    [Table("Eventos")]
    public class EventoModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        [DataType(DataType.Date)]
        public string EventDate { get; set; }
        public string? Period { get; set; }
        public int? AmountGuests { get; set; }
        public string? Address { get; set; }
        public string?  AdressComplement{ get; set; }
        [DataType(DataType.Time)]
        public string? ArrivalTime { get; set; }
        public int? AmountWaiters { get; set; }
        public string? NameWaiters { get; set; }
        public decimal? ServiceValue { get; set; }


    }
}
