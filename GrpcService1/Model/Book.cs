using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GrpcService1.Model
{
    //не реализовывал
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
