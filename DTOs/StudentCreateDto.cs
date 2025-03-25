namespace StudentApi.DTOs
{
    public class StudentCreateDto
    {
        public required string Nome { get; set; }
        public required string Cognome { get; set; }
        public required string Email { get; set; }
    }
}
