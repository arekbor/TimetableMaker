using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Contracts;

public interface IData<T>
{
    Task DeleteAsync(int id);
    Task<T> GetAsync(int id);
    Task InsetAsync(T obj);
    Task UpdateModeAsync(T obj);
}
