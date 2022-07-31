
namespace TimetableMakerDataAccess.Dtos;

public class RouteDto
{
    public int LineId { get; set; }
    public int LocationId { get; set; }
    public TimeOnly ArrivalTime { get; set; }
}
