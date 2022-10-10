using Microsoft.EntityFrameworkCore;

namespace App;

public class UniversityContext : DbContext
{
    public UniversityContext()
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Time> Times { get; set; }
    public DbSet<RoomOption> RoomOptions { get; set; }
    public DbSet<RoomCapacity> RoomCapacities { get; set; }
    public DbSet<RoomHasProjector> RoomHasProjectors { get; set; }
    public DbSet<ConfirmedTime> ConfirmedTimes { get; set; }
    public DbSet<ConfirmedRoom> ConfirmedRooms { get; set; }
    public DbSet<ProposedTime> ProposedTimes { get; set; }
    public DbSet<ChartGroup> ChartGroups { get; set; }

    public DbSet<ProposedRoom> ProposedRooms { get; set; }


    public Teacher[] GetTeachers()
    {
        var teachers = this.Teachers.Include(t => t.ConfirmedRooms).ThenInclude(c => c.Room).AsQueryable();
        teachers = teachers.Include(t => t.ConfirmedTimes).ThenInclude(c => c.Time).AsQueryable();
        teachers = teachers.Include(t => t.ProposedTimes).ThenInclude(c => c.Time).AsQueryable();
        teachers = teachers.Include(t => t.ProposedRooms).ThenInclude(c => c.Room).AsQueryable();
        return teachers.ToArray();
    }

    public Course[] GetCourses()
    {
        var courses = this.Courses.Include(c => c.RequiredOptions).AsQueryable();
        courses = courses.Include(c => c.Teacher).AsQueryable();
        courses = courses.Include(c => c.Group).AsQueryable();
        return courses.ToArray();
    }

    public Room[] GetRooms()
    {
        var rooms = this.Rooms.Include(x => x.Options).AsQueryable();
        rooms = rooms.Include(x => x.ConfirmedRooms).ThenInclude(x => x.Teacher).AsQueryable();
        rooms = rooms.Include(x => x.ProposedRooms).ThenInclude(x => x.Teacher).AsQueryable();
        return rooms.ToArray();
    }

    public Time[] GetTimes()
    {
        var times = this.Times.Include(x => x.ConfirmedTimes).ThenInclude(x => x.Teacher).AsQueryable();
        times = times.Include(x => x.ProposedTimes).ThenInclude(x => x.Teacher).AsQueryable();
        return times.ToArray();
    }

    public CourseGroup[] GetCourseGroups()
    {
        var groups = this.CourseGroups.Include(x => x.Events).AsQueryable();
        return groups.ToArray();
    }

    public ChartGroup[] GetChartGroups()
    {
        var groups = this.ChartGroups.Include(x => x.CourseGroups).AsQueryable();
        return groups.ToArray();
    }

    public DbSet<CourseGroup> CourseGroups { get; set; }
    public DbSet<Student> Students { get; set; }

    public Student[] GetStudents()
    {
        var students = this.Students.AsQueryable();
        return students.ToArray();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Time>().ToTable("Times");
        // modelBuilder.Entity<Room>().ToTable("Rooms");
        modelBuilder.Entity<ProposedTime>().HasKey(t => new { t.TeacherId, t.TimeId });
        modelBuilder.Entity<ProposedRoom>().HasKey(r => new { r.TeacherId, r.RoomId });
        modelBuilder.Entity<ConfirmedTime>().HasKey(t => new { t.TeacherId, t.TimeId });
        modelBuilder.Entity<ConfirmedRoom>().HasKey(r => new { r.TeacherId, r.RoomId });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=UniDB.db;");
    }
}