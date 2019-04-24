using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCFTest.Model
{
    public class Student
    {
        public Student()
        {

        }
        public int Id { get; set; }

        [MinLength(2), MaxLength(50)]
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [MaxLength(350)]
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        // Foreign key for Standard
        public Nullable<int> StandardId { get; set; }
        public Standard Standard { get; set; }
    }
}
