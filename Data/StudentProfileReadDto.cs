namespace StudentApi.DTOs
{
    public class StudentProfileReadDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string FiscalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

