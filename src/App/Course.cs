using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App;

public class Course
{
    [Key] public int CourseId { get; set; }
    [ForeignKey("TeacherId")] public Teacher Teacher { get; set; }
    public string Name { get; set; }
    [ForeignKey("GroupId")] public CourseGroup Group { get; set; }

    public List<RoomOption> RequiredOptions { get; set; }

    public bool IsLab { get; set; }

    [NotMapped] public Time AssignedTime { get; set; }
    [NotMapped] public int required_capacity;
    [NotMapped] public bool required_projector;

    protected bool Equals(Course other)
    {
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Course)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}