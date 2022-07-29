namespace TimetableMakerDataAccess.Contracts;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task SaveDataAsync<T>(string storedProdecure, T parameters, string connectionId = "Default");
}
