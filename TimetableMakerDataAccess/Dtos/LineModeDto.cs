namespace TimetableMakerDataAccess.Dtos;

public class LineModeDto
{
    public int LineId { get; set; }
    public string LineName { get; set; }
    public string Type { get; set; }
    public string Model { get; set; }
    public int Seats { get; set; }

    public IReadOnlyList<RouteLocationDto> RouteLocationDto { get; set; }
}
