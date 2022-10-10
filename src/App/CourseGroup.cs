using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace App;

public class CourseGroup
{
    [Key]
    public int GroupId { get; set; }
    public string Name { get; set; }

    public List<Course> Events { get; set; }

    public void AddEvent(Course e)
    {
        this.Events.Add(e);
    }

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