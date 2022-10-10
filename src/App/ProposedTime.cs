using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App;

public class ProposedTime
{
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int TimeId { get; set; }
    public Time Time { get; set; }
}