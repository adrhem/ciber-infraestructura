using CiberInfraestructuraApi.Models;

namespace CiberInfraestructuraApi.DataAccess
{
  public class DataAccessProvider : IDataAccessProvider
  {
    private readonly PostgreSqlContext _context;

    public DataAccessProvider(PostgreSqlContext context)
    {
      _context = context;
    }

    public CatPersonal? GetPersonal(int id)
    {
      return _context.CatPersonal.Find(id);
    }

    public List<CatPersonal> GetAllPersonal()
    {
      return _context.CatPersonal.ToList();
    }
  }
}