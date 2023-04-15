using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR.Domain.Entidades
{
    [Table("Funcionarios")]
    public class FuncionarioModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        [MaxLength(150, ErrorMessage = "The field: {0} can not exceed {1} character.")]
        [MinLength(2, ErrorMessage = "The field: {0} can not be less {1} character.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        [MaxLength(50, ErrorMessage = "The field: {0} can not exceed {1} character.")]
        [MinLength(2, ErrorMessage = "The field: {0} can not be less {1} character.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        [Range(14, 14, ErrorMessage = "The field: {0} must be {1} characters long.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "The field: {0} can not be empty.")]
        [MinLength(5, ErrorMessage = "The field: {0} can not be less {1} character.")]
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