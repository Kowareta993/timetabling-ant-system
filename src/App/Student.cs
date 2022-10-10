using System.ComponentModel.DataAnnotations;

namespace App;

public class Student
{
    [Key] public int StudentId { get; set; }
    public string Name { get; set; }
    


}