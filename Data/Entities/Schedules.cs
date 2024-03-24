using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("schedules")]
public class Schedules : BaseEntity
{
    public DateTime date { get; set; }
    public string attendances { get; set; }
    public int classroom_id { get; set; }
    public int slot { get; set; }
}