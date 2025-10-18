using CiberInfraestructuraApi.Models;

namespace CiberInfraestructuraApi.DataAccess
{
  public interface IDataAccessProvider
  {
    CatPersonal? GetPersonal(int id);
    List<CatPersonal> GetAllPersonal();
  }
}