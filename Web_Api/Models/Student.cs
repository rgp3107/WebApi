using System.ComponentModel.DataAnnotations;

namespace Web_Api.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int  Age { get; set; }
    }
}
