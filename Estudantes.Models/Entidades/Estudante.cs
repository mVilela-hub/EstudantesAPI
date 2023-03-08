using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estudantes.Models.Entidades
{
    [Table("Students")]
    public class Estudante
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string MiddleName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        [MaxLength(1, ErrorMessage = "Tamanho máximo do campo {0} é de {1} caracteres")]
        public string Gender { get; set; } = String.Empty;
        public string StreetAddress { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        [MaxLength(2, ErrorMessage = "Tamanho máximo do campo {0} é de {1} caracteres")]
        public string State { get; set; } = String.Empty;
        [MaxLength(5, ErrorMessage = "Tamanho máximo do campo {0} é de {1} caracteres")]
        public string ZipCode { get; set; } = String.Empty;
        public string Telephone { get; set; } = String.Empty;
        public string email { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public int DegreePursued { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string? ClassStandingCode { get; set; }
        [MaxLength(1, ErrorMessage = "Tamanho máximo do campo {0} é de {1} caracteres")]
        public string StudentStatus { get; set; } = String.Empty;
        [Required(ErrorMessage = "{0} é obrigatório")]
        [MaxLength(6, ErrorMessage = "Tamanho máximo do campo {0} é de {1} caracteres")]
        public string EnrollmentTerm { get; set; } = String.Empty;
    }
}
