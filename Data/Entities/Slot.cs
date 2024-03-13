using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Slot : BaseEntity
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public DateTime Date { get; set; }
        public int TeacherId { get; set; }
        public Teacher teacher { get; set; }

        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public virtual IList<Student> Students { get; set; }
    }
}
