
namespace TimetableMakerDataAccess.Models;

public class Route
{
    public int Id { get; set; }
    public int LineId { get; set; }
    public int LocationId { get; set; }
    public TimeOnly ArrivalTime { get; set; }
}

