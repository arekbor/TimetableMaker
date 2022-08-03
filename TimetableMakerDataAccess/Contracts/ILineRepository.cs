using TimetableMakerDataAccess.Dtos;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Contracts;

public interface ILineRepository: IRepository<Line>
{
    Task<LineModeDto> GetLineRoutesByIdAsync(int id);
}
