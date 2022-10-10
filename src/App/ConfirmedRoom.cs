using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App;

public class ConfirmedRoom
{
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
}