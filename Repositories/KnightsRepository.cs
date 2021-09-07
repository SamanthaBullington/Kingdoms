using System.Collections.Generic;
using System.Data;
using System.Linq;
using Kingdoms.Models;
using Dapper;

namespace Kingdoms.Repositories
{
  public class KnightsRepository
  {
    private readonly IDbConnection _db;

    public KnightsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Knight> Get()
    {
      string sql = "SELECT * FROM knights";
      return _db.Query<Knight>(sql).ToList();
    }

    internal Knight Get(int id)
    {
      // the '@' is used by dapper to pull in variables off of a provided object
      string sql = "SELECT * FROM knights WHERE id = @id";
      //   Query first or default retruns a single objecr or NULL if not found
      return _db.QueryFirstOrDefault<Knight>(sql, new { id });
    }

    internal Knight Create(Knight newKnight)
    {
      string sql = @"
      INSERT INTO knights
      (name, weapon, roundtable)
      VALUES
      (@Name, @Weapon, @RoundTable);
      SELECT LAST_INSERT_ID();";
      newKnight.Id = _db.ExecuteScalar<int>(sql, newKnight);
      return newKnight;
    }

    internal Knight Update(Knight updatedKnight)
    {
      string sql = @"
        UPDATE knights
        SET
            name = @Name,
            weapon = @Weapon,
            roundtable = @RoundTable
        WHERE id = @Id;
      ";
      _db.Execute(sql, updatedKnight);
      return updatedKnight;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM knights WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}