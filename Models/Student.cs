﻿using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
  
        public class Student
        {
            public int Id { get; set; }

            [Required]
            public string Nome { get; set; }

            [Required]
            public string Cognome { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }
        }
    }


