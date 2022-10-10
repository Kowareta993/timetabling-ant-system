using System.ComponentModel.DataAnnotations;

namespace App;

public enum Day
{
    Sat,
    Sun,
    Mon,
    Tue,
    Wed
}

public class Time
{
    public Day Day { get; set; }
    public double Start { get; set; }
    public double Duration { get; set; }
    [Key] public int TimeId { get; set; }

    public virtual List<ProposedTime> ProposedTimes { get; set; }
    public virtual List<ConfirmedTime> ConfirmedTimes { get; set; }
    
    public double Interval(Time t)
    {
        if (this.Intersects(t))
            return 0;
        double dist1 = Math.Abs(this.Start + this.Duration - t.Start);
        double dist2 = Math.Abs(t.Start + t.Duration - this.Start);
        return Math.Abs(24 * (this.Day - t.Day)) + Math.Min(dist1, dist2);
    }

    protected bool Equals(Time other)
    {
        return Day == other.Day && Start.Equals(other.Start) && Duration.Equals(other.Duration);
    }

    public override string ToString()
    {
        return $"{this.Day} {this.Start}-{this.Start + Duration}";
    }

    public bool Intersects(Time t)
    {
        
        if (t.Day != this.Day)
            return false;
        if (this.Equals(t))
            return true;
        if (t.Start > this.Start && t.Start < this.Start + this.Duration)
            return true;
        if (this.Start > t.Start && this.Start < t.Start + t.Duration)
            return true;
        return false;
    }
}