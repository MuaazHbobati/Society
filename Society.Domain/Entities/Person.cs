using Society.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null;
        public string FatherName { get; set; } = null;
        public string LastName { get; set; } = null;
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public User? User { get; set; }
    }
}
