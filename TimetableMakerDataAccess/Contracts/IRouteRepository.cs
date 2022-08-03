using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Contracts;

public interface IRouteRepository:IRepository<RouteLines>
{
    Task<int> DeleteAllRoutesByLineId(int id);
}
