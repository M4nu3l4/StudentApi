using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
  
        public class Student
        {
            public int Id { get; set; }

            [Required]
            public  required string Nome { get; set; }

            [Required]
            public required string Cognome { get; set; }

            [Required, EmailAddress]
            public required string Email { get; set; }


        public StudentProfile? Profile { get; set; }

    }

}


