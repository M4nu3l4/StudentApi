using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StudentApi.Data;


namespace StudentApi.Data
{
    public class StudentContextFactory : IDesignTimeDbContextFactory<StudentContext>
    {
        public StudentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentContext>();
            optionsBuilder.UseSqlite("Data Source=StudentApi.db");

            return new StudentContext(optionsBuilder.Options);
        }
    }
}
