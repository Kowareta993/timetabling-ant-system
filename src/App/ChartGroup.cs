using System.ComponentModel.DataAnnotations;

namespace App;

public class ChartGroup
{
    [Key] public int GroupId { get; set; }
    public string Name { get; set; }

    public List<CourseGroup> CourseGroups { get; set; }

    public override string ToString()
    {
        return $"{this.Name}";
    }

    protected bool Equals(CourseGroup other)
    {
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((CourseGroup)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}