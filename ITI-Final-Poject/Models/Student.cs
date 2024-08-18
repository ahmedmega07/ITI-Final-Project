using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Final_Poject.Models
{
    public class Student
    {
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Display(Name = "Student Age")]
        public int Age { get; set; }


        [ForeignKey("Department")]
        [Display(Name = "Department Name")]
        public int Dept_Id { get; set; }


        public virtual Department? Department { get; set; }


        public string? Image { get; set; } = "~/Images/default.png";
    }
}
