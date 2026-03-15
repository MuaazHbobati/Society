using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Domain.Entities
{
    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProgramSubject> ProgramSubjects { get; set; } = new List<ProgramSubject>();
    }

}
