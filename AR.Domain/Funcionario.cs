using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR.Domain
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        [MaxLength(100, ErrorMessage = "The field: {0} can not exceed {1} character.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        [MaxLength(50, ErrorMessage = "The field: {0} can not exceed {1} character.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        [MaxLength(14, ErrorMessage = "The field: {0} can not exceed {1} character.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        public string Function { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        public DateTime InclusionDate { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        [DefaultValue(0)]
        public int QuantityEventWorked { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        [DefaultValue(0)]
        public int QuantityEventPlanned { get; set; }
    }
}