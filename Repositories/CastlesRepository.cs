using System.Collections.Generic;
using System.Data;
using System.Linq;
using Kingdoms.Models;
using Dapper;

namespace Kingdoms.Repositories
{
  public class CastlesRepository
  {
    private readonly IDbConnection _db;

    public CastlesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Castle> Get()
    {
      string sql = "SELECT * FROM castles";
      return _db.Query<Castle>(sql).ToList();
    }

    internal Castle Get(int id)
    {
      // the '@' is used by dapper to pull in variables off of a provided object
      string sql = "SELECT * FROM castles WHERE id = @id";
      //   Query first or default retruns a single objecr or NULL if not found
      return _db.QueryFirstOrDefault<Castle>(sql, new { id });
    }

    internal Castle Create(Castle newCastle)
    {
      string sql = @"
      INSERT INTO castles
      (name, location)
      VALUES
      (@Name, @Location);
      SELECT LAST_INSERT_ID();";
      newCastle.Id = _db.ExecuteScalar<int>(sql, newCastle);
      return newCastle;
    }

    internal Castle Update(Castle updatedCastle)
    {
      string sql = @"
        UPDATE castles
        SET
            name = @Name,
            location = @Location
        WHERE id = @Id;
      ";
      _db.Execute(sql, updatedCastle);
      return updatedCastle;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM castles WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}