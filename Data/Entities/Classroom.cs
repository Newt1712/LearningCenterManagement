using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("classrooms")]
public class Classrooms : BaseEntity
{
    public decimal classroomNo { get; set; }
    public bool status { get; set; }
    public int subject_id { get; set; }
    public int capacity { get; set; }
    public int teacher_id { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
}