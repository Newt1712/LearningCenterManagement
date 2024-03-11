using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("attendance")]
public class Attendance
{
    public DateTime date { get; set; }
    public string remark { get; set; }
    public double status { get; set; }
    public int student_id { get; set; }
}