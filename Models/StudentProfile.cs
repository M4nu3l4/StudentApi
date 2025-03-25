using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FiscalCode { get; set; }

        public DateTime BirthDate { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
