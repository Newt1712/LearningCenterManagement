using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("attendances")]
public class Attendances
{
    public int student_id { get; set; }

    public int schedule_id { get; set; }

    public bool is_present { get; set; }
}