using CiberInfraestructuraApi.Models;

namespace CiberInfraestructuraApi.DataAccess
{
  public interface IDataAccessProvider
  {
    Task<CatPersonal?> GetPersonal(int id);
    Task<List<CatPersonal>> GetAllPersonal();
    Task<CatPersonal> AddPersonal(CatPersonal catPersonal);
  }
}