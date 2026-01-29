using Society.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Domain.Entities
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; } = null;
        
        [Required, MaxLength(100)]
        public string FatherName { get; set; } = null;

        [Required, MaxLength(100)]
        public string LastName { get; set; } = null;
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public User? User { get; set; }
    }
}
