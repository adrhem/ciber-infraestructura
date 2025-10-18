using CiberInfraestructuraApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CiberInfraestructuraApi.DataAccess
{
  public class DataAccessProvider : IDataAccessProvider
  {
    private readonly PostgreSqlContext _context;

    public DataAccessProvider(PostgreSqlContext context)
    {
      _context = context;
    }

    public async Task<CatPersonal?> GetPersonal(int id)
    {
      return await _context.CatPersonal.FindAsync(id);
    }

    public async Task<List<CatPersonal>> GetAllPersonal()
    {
      return await _context.CatPersonal.ToListAsync();
    }
  }
}