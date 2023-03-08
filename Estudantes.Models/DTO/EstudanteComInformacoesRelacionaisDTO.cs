using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudantes.Models.DTO
{
    public class EstudanteComInformacoesRelacionaisDTO
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string MiddleName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Gender { get; set; } = String.Empty;
        public string StreetAddress { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string ZipCode { get; set; } = String.Empty;
        public string Telephone { get; set; } = String.Empty;
        public string email { get; set; } = String.Empty;
        public string DateOfBirth { get; set; } = String.Empty;
        public int DegreePursued { get; set; }
        public string DegreeName { get; set; } = String.Empty;
        public string ClassStandingCode { get; set; } = String.Empty;
        public string? ClassStandingName { get; set; } = String.Empty;
        public string StudentStatus { get; set; } = String.Empty;
        public string EnrollmentTerm { get; set; } = String.Empty;
        public string SessionCode { get; set; } = String.Empty;
        public int Year { get; set; }
    }
}
