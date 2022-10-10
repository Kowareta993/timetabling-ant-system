using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App;

public class Teacher
{
    [NotMapped] private List<Room> AssignedRooms { get; set; }

    [NotMapped] public List<Time> AssignedTimes { get; set; }
    public virtual List<ConfirmedTime> ConfirmedTimes { get; set; }
    public List<ConfirmedRoom> ConfirmedRooms { get; set; }
    public virtual List<ProposedTime> ProposedTimes { get; set; }

    public virtual List<ProposedRoom> ProposedRooms { get; set; }

    [NotMapped] public int[] ConfirmedTimesIndexes { get; set; }
    [NotMapped] public int[] ConfirmedRoomsIndexes { get; set; }

    public string Name { get; set; }

    [Key] public int TeacherId { get; set; }

    public void ClearAssignments()
    {
        AssignedTimes = new List<Time>();
        AssignedRooms = new List<Room>();
    }

    public void AssignTime(Time t)
    {
        AssignedTimes.Add(t);
    }

    public void AssignRoom(Room r)
    {
        AssignedRooms.Add(r);
    }

    public int TimeConstraint()
    {
        int count = 0;
        foreach (var t1 in AssignedTimes)
        {
            foreach (var t2 in AssignedTimes)
            {
                if (t1.Equals(t2))
                    continue;
                if (t1.Interval(t2) < 0)
                    count++;
            }
        }

        return count / 2;
    }

    public int ProposedTimesConstraint()
    {
        var times = ProposedTimes.Select(t => t.Time).ToList();
        return AssignedTimes.Count(time => !times.Contains(time));
    }

    public int ProposedRoomsConstraint()
    {
        var rooms = ProposedRooms.Select(r => r.Room).ToList();
        return AssignedRooms.Count(r => !rooms.Contains(r));
    }
}