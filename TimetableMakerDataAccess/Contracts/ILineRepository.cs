using TimetableMakerDataAccess.Dtos;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Contracts;

public interface ILineRepository: IRepository<Line>
{
    Task<LineModeDto> GetLineModeByIdAsync(int id);
    Task<IReadOnlyList<LineModeDto>> GetAllLinesModesAsync();
}
