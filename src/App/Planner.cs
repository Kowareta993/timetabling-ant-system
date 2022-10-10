using System.Collections;
using System.Text.RegularExpressions;

namespace App;

public class Planner
{
    private Course[] _events;
    private Room[] _rooms;
    private Time[] _times;
    private Teacher[] _teachers;
    private ChartGroup[] _chartGroups;
    private const int Tries = 100;
    private CourseGroup[] _groups;
    private Student[] _students;
    private double[,,] _pheromones;
    private const double MaxPheromone = 3.33;
    private const double MinPheromone = 0.3;
    private static readonly Random Random = new Random();
    private const int Ants = 84;
    private const double Persistence = 0.7;
    private const double A = 1;
    private const int Iterations = 500;
    private const double C = Iterations / 2.0;
    private double _persistence;
    private readonly UniversityContext _db;
    private const double Epsilon = 0.1;
    private const int Convergence = 5;


    private void DataInit()
    {
        _events = _db.GetCourses();
        _rooms = _db.GetRooms();
        _times = _db.GetTimes();
        _teachers = _db.GetTeachers();
        _groups = _db.GetCourseGroups();
        _students = _db.GetStudents();
        _chartGroups = _db.GetChartGroups();
        foreach (var teacher in _teachers)
        {
            teacher.ConfirmedRoomsIndexes = FindIndexes(teacher.ConfirmedRooms.Select(c => c.Room).ToArray(), _rooms);
            teacher.ConfirmedTimesIndexes = FindIndexes(teacher.ConfirmedTimes.Select(c => c.Time).ToArray(), _times);
        }
    }

    public Planner()
    {
        _persistence = Persistence;
        _db = new UniversityContext();
        DataInit();
    }

    private void PheromonesInit()
    {
        this._pheromones = new double[_events.Length, _rooms.Length, _times.Length];
        for (int i = 0; i < _events.Length; i++)
        {
            for (int j = 0; j < _rooms.Length; j++)
            {
                for (int k = 0; k < _times.Length; k++)
                {
                    _pheromones[i, j, k] = MaxPheromone;
                }
            }
        }
    }


    private double RoomsExtraOptionsConstraint(int[,] solution)
    {
        double cost = 0;
        for (int i = 0; i < solution.GetLength(0); i++)
        {
            Room room = _rooms[solution[i, 0]];
            cost += room.ExtraOptions(_events[i].RequiredOptions.ToArray());
        }

        return cost;
    }

    private int[] Choice(double[,] weights)
    {
        int m = weights.GetLength(0);
        int n = weights.GetLength(1);
        double sum = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sum += weights[i, j];
            }
        }

        double rng = Random.NextDouble() * sum;
        double c = 0;
        bool found = weights[0, 0] > 0;
        int ii = 0;
        int jj = 0;
        while (c + weights[ii, jj] < rng)
        {
            if (weights[ii, jj] > 0)
                found = true;

            c += weights[ii, jj];
            jj++;
            if (jj == n)
            {
                jj = 0;
                ii++;
            }
        }

        if (!found)
            return new int[] { -1, -1 };
        return new int[] { ii, jj };
    }

    private int[] FindIndexes(Object[] arr, Object[] reference)
    {
        int[] indexes = new int[arr.Length];
        int idx = 0;
        foreach (var obj in arr)
        {
            for (int i = 0; i < reference.Length; i++)
            {
                if (obj.Equals(reference[i]))
                {
                    indexes[idx] = i;
                }
            }

            idx++;
        }

        return indexes;
    }

    private bool[,] ValidPaths(int[,] solution, int step)
    {
        bool[,] isValid = new bool[_rooms.Length, _times.Length];
        for (int i = 0; i < _rooms.Length; i++)
        {
            for (int j = 0; j < _times.Length; j++)
            {
                isValid[i, j] = false;
            }
        }

        int[] rooms = _events[step].Teacher.ConfirmedRoomsIndexes;
        int[] times = _events[step].Teacher.ConfirmedTimesIndexes;
        for (int i = 0; i < rooms.Length; i++)
        {
            for (int j = 0; j < times.Length; j++)
            {
                isValid[rooms[i], times[j]] = true;
                if (_events[step].RequiredOptions.Any(option => !_rooms[rooms[i]].HasOption(option)))
                {
                    isValid[rooms[i], times[j]] = false;
                }
            }
        }

        for (int i = 0; i < step; i++)
        {
            isValid[solution[i, 0], solution[i, 1]] = false;
        }

        for (int i = 0; i < times.Length; i++)
        {
            foreach (var t in _events[step].Teacher.AssignedTimes)
            {
                if (_times[i].Intersects(t))
                {
                    for (int j = 0; j < _rooms.Length; j++)
                    {
                        isValid[j, i] = false;
                    }
                }
            }
        }

        return isValid;
    }

    private double[,] PathsWeights(int e, bool[,] isValid)
    {
        double[,] weights = new double[_rooms.Length, _times.Length];
        for (int i = 0; i < _rooms.Length; i++)
        {
            for (int j = 0; j < _times.Length; j++)
            {
                weights[i, j] = _pheromones[e, i, j];
                if (!isValid[i, j])
                    weights[i, j] = 0;
            }
        }

        return weights;
    }

    private void ClearAssignments()
    {
        foreach (var teacher in _teachers)
        {
            teacher.ClearAssignments();
        }
    }

    private int[,]? BuildSolution()
    {
        int[,] solution = new int[_events.Length, 2];
        ClearAssignments();
        for (int i = 0; i < _events.Length; i++)
        {
            bool[,] isValid = ValidPaths(solution, i);
            double[,] weights = PathsWeights(i, isValid);
            int[] idx = Choice(weights);
            if (idx[0] == -1)
            {
                return null;
            }

            solution[i, 0] = idx[0];
            solution[i, 1] = idx[1];
            _events[i].Teacher.AssignTime(_times[idx[1]]);
            _events[i].Teacher.AssignRoom(_rooms[idx[0]]);
        }

        return solution;
    }

    private int[][,]? BuildSolutions()
    {
        int[][,] solutions = new int[Ants][,];
        for (int k = 0; k < Ants; k++)
        {
            int t = 0;
            while (t < Tries)
            {
                int[,]? solution = BuildSolution();
                if (solution != null)
                {
                    solutions[k] = solution;
                    break;
                }

                t++;
            }

            if (t == Tries)
            {
                return null;
            }
        }

        return solutions;
    }

    private int[,] BestSolution(int[][,]? solutions)
    {
        var costs = new double[solutions.Length];
        for (var i = 0; i < solutions.Length; i++)
        {
            costs[i] = F(solutions[i]);
        }

        var best = 0;
        for (var i = 0; i < solutions.Length; i++)
        {
            if (costs[i] < costs[best])
                best = i;
        }

        return solutions[best];
    }

    private void PrintSolution(int[,] solution)
    {
        string s = "";
        for (int j = 0; j < solution.GetLength(0); j++)
        {
            s += $"({_rooms[solution[j, 0]]}, {_times[solution[j, 1]]}), ";
        }
        Console.WriteLine(s);
    }

    private void PrintSolutions(int[][,] solutions)
    {
        foreach (var t in solutions)
        {
            PrintSolution(t);
        }
    }

    private double TeacherTimeConstraint(int[,] solution)
    {
        foreach (var t in _teachers)
        {
            t.ClearAssignments();
        }

        for (var i = 0; i < _events.Length; i++)
        {
            var room = solution[i, 0];
            var time = solution[i, 1];
            _events[i].Teacher.AssignTime(_times[time]);
        }

        return _teachers.Aggregate<Teacher, double>(0, (current, teacher) => current + teacher.TimeConstraint());
    }

    private double TeacherProposedTimeConstraint(int[,] solution)
    {
        foreach (var t in _teachers)
        {
            t.ClearAssignments();
        }

        for (var i = 0; i < _events.Length; i++)
        {
            var room = solution[i, 0];
            var time = solution[i, 1];
            _events[i].Teacher.AssignTime(_times[time]);
        }

        return _teachers.Aggregate<Teacher, double>(0,
            (current, teacher) => current + teacher.ProposedTimesConstraint());
    }

    private double TeacherProposedRoomConstraint(int[,] solution)
    {
        foreach (var t in _teachers)
        {
            t.ClearAssignments();
        }

        for (var i = 0; i < _events.Length; i++)
        {
            var room = solution[i, 0];
            var time = solution[i, 1];
            _events[i].Teacher.AssignRoom(_rooms[room]);
        }

        return _teachers.Aggregate<Teacher, double>(0,
            (current, teacher) => current + teacher.ProposedTimesConstraint());
    }

    private Assignment[] ToAssignment(int[,] solution)
    {
        PrintSolution(solution);
        Assignment[] suggestions = new Assignment[solution.GetLength(0)];
        for (int i = 0; i < solution.GetLength(0); i++)
        {
            Assignment s = new Assignment();
            s.Course = _events[i];
            s.Room = _rooms[solution[i, 0]];
            s.Time = _times[solution[i, 1]];
            foreach (var option in s.Course.RequiredOptions)
            {
                if (option is RoomCapacity capacity)
                {
                    s.Course.required_capacity = capacity.Capacity;
                }

                if (option is RoomHasProjector projector)
                {
                    s.Course.required_projector = projector.Projector;
                }
            }
            foreach (var option in s.Room.Options)
            {
                if (option is RoomCapacity capacity)
                {
                    s.Room.capacity = capacity.Capacity;
                }

                if (option is RoomHasProjector projector)
                {
                    s.Room.has_projector = projector.Projector;
                }
            }
            suggestions[i] = s;
        }

        return suggestions;
    }


    private double GroupTimeConstraint(int[,] solution)
    {
        double cost = 0;
        for (var i = 0; i < solution.GetLength(0); i++)
        {
            for (var j = i + 1; j < solution.GetLength(0); j++)
            {
                if (!_events[i].Group.Equals(_events[j].Group)) continue;
                var t1 = _times[solution[i, 1]];
                var t2 = _times[solution[j, 1]];
                if (t1.Interval(t2) < 1.5)
                    cost += 1;
            }
        }

        return cost;
    }

    private static bool Backtrack(int step, Time[] times, List<CourseGroup> groups, Course c)
    {
        if (step == times.Length)
            return true;
        if (groups[step].Equals(c.Group))
        {
            var t = c.AssignedTime;
            if (times.Any(time1 => time1.Intersects(t))) return false;
            var deepCopy = new Time[times.Length];
            times.CopyTo(deepCopy, 0);
            deepCopy[step] = t;
            return Backtrack(step + 1, deepCopy, groups, c);
        }

        foreach (var course in groups[step].Events)
        {
            var t = course.AssignedTime;
            if (times.Any(time1 => time1.Intersects(t))) continue;
            var deepCopy = new Time[times.Length];
            times.CopyTo(deepCopy, 0);
            deepCopy[step] = t;
            if (Backtrack(step + 1, deepCopy, groups, c))
                return true;
        }

        return false;
    }

    private bool ChartCompatible(int[,] solution, ChartGroup g)
    {
        Time[] pickedTimes = new Time[g.CourseGroups.Count];
        for (int i = 0; i < _events.Length; i++)
        {
            _events[i].AssignedTime = _times[solution[i, 1]];
        }
        foreach (var courseGroup in g.CourseGroups)
        {
            foreach (var course in courseGroup.Events)
            {
                if (!Backtrack(0, pickedTimes, g.CourseGroups, course))
                    return false;
            }
        }

        return true;
    }


    private double ChartGroupConstraint(int[,] solution)
    {
        double cost = 0;
        foreach (var chartGroup in _chartGroups)
        {
            if (!ChartCompatible(solution, chartGroup))
                cost += 1;
        }
        return cost;
    }

    private double F(int[,] solution)
    {
        double[] weights = { 5, 20, 20, 5, 1 , 100};
        Func<int[,], double>[] func =
        {
            TeacherTimeConstraint, TeacherProposedTimeConstraint, TeacherProposedRoomConstraint, GroupTimeConstraint,
            RoomsExtraOptionsConstraint, ChartGroupConstraint
        };
        return weights.Select((t, i) => t * func[i](solution)).Sum();
    }

    private double Fitness(double f, double worst, double sum)
    {
        if (Ants * worst - sum == 0)
            return 0;
        return (worst - f) / (Ants * worst - sum);
    }

    private void UpdatePheromones(int[][,]? solutions)
    {
        for (int i = 0; i < _events.Length; i++)
        {
            for (int j = 0; j < _rooms.Length; j++)
            {
                for (int k = 0; k < _times.Length; k++)
                {
                    this._pheromones[i, j, k] *= _persistence;
                }
            }
        }

        double[] costs = new double[Ants];
        for (int i = 0; i < Ants; i++)
        {
            costs[i] = F(solutions[i]);
        }

        double sum = costs.Sum();
        double worst = costs.Max();
        for (int i = 0; i < solutions.Length; i++)
        {
            int[,] solution = solutions[i];
            for (int e = 0; e < _events.Length; e++)
            {
                int room = solution[e, 0];
                int time = solution[e, 1];
                _pheromones[e, room, time] += Fitness(costs[i], worst, sum);
            }
        }

        for (int i = 0; i < _events.Length; i++)
        {
            for (int j = 0; j < _rooms.Length; j++)
            {
                for (int k = 0; k < _times.Length; k++)
                {
                    if (_pheromones[i, j, k] < MinPheromone)
                        _pheromones[i, j, k] = MinPheromone;
                    else if (_pheromones[i, j, k] > MaxPheromone)
                        _pheromones[i, j, k] = MaxPheromone;
                }
            }
        }
    }

    private void UpdateParameters(int t)
    {
        _persistence = Persistence * 1 / (1 + Math.Exp(-A * (t - C)));
    }

    public Assignment[]? Plan()
    {
        PheromonesInit();
        int[][,]? solutions = { };
        int count = 0;
        double lastCost = 0;
        for (int i = 0; i < Iterations; i++)
        {
            solutions = BuildSolutions();
            if (solutions == null)
            {
                Console.WriteLine("cannot find a solution");
                return null;
            }

            UpdatePheromones(solutions);
            UpdateParameters(i + 1);
            var best = BestSolution(solutions);
            if (Math.Abs(F(best) - lastCost) < Epsilon)
            {
                count++;
                if (count == Convergence)
                {
                    break;
                }
            }
            else
            {
                count = 0;
            }

            lastCost = F(best);
        }

        return ToAssignment(BestSolution(solutions));
    }
}