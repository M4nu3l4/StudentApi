using System.ComponentModel.DataAnnotations;




namespace StudentApi.DTOs

{
    public class StudentProfileUpdateDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

    [Required]
    [RegularExpression("^[A-Z]{6}[0-9]{2}[A-Z][0-9]{2}[A-Z][0-9]{3}[A-Z]$",
     ErrorMessage = "Il codice fiscale non è valido")]
    public required string FiscalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
