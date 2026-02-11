using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Society.Domain.Entities
{
    public class Team
    {
        public Guid Id { get; set; }

        public Guid FormationId { get; set; }

        public Guid ProgramSubjectId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
