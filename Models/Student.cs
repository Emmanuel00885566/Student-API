using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Range(15, 100, ErrorMessage = "Age must be between 15 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Course is required")]
        public required string Course { get; set; }

        [Required(ErrorMessage = "Level is required")]
        public required string Level { get; set; }
    }
}
