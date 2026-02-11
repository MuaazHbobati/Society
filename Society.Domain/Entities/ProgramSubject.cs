using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Domain.Entities
{
    public class ProgramSubject
    {
        public Guid Id { get; set; }

        public Guid ProgramId { get; set; }
        public Guid SubjectId { get; set; }
    }

}
