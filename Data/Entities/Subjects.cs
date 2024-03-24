using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("subjects")]
public class Subjects : BaseEntity
{
    public string name { get; set; }
    public string description { get; set; }
    public decimal currentPrice { get; set; }
    public int totalSlot { get; set; }
    public int subjectType { get; set; }
    public int subjectLevel { get; set; }
    public int isDeleted { get; set; }
}