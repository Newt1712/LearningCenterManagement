using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("attendances")]
public class Attendance
{
    public int student_id { get; set; }
    public Student Student { get; set; }

    public int slot_id { get; set; }
    public Slot Slot { get; set; }

    public bool is_present { get; set; }

}