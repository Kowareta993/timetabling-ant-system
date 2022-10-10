using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App;

public class Assignment
{
    
    public Course Course { get; set; }
    public Room Room { get; set; }
    public Time Time { get; set; }
}