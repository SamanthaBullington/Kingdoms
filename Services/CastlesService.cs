using System;
using System.Collections.Generic;
using Kingdoms.Models;
using Kingdoms.Repositories;

namespace Kingdoms.Services
{
  public class CastlesService
  {
    private readonly CastlesRepository _repo;

    public CastlesService(CastlesRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Castle> Get()
    {
      return _repo.Get();
    }

    internal Castle Get(int id)
    {
      Castle castle = _repo.Get(id);
      if (castle == null)
      {
        throw new Exception("Invalid Id");
      }
      return castle;
    }

    internal Castle Create(Castle newCastle)
    {
      Castle castle = _repo.Create(newCastle);
      if (castle == null)
      {
        throw new Exception("Invalid Id");
      }
      return castle;
    }

    internal Castle Edit(Castle updatedCastle)
    {
      // Find the original before edits
      Castle original = Get(updatedCastle.Id);
      // check each value on the incoming object, if it exits then allow it to continue, if it does not set it to the original value
      updatedCastle.Name = updatedCastle.Name != null ? updatedCastle.Name : original.Name;
      updatedCastle.Location = updatedCastle.Location != null ? updatedCastle.Location : original.Location;
      return _repo.Update(updatedCastle);
    }

    internal void Delete(int id)
    {
      Castle original = Get(id);
      _repo.Delete(id);
    }
  }
}