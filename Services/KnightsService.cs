using System;
using System.Collections.Generic;
using Kingdoms.Models;
using Kingdoms.Repositories;

namespace Kingdoms.Services
{
  public class KnightsService
  {
    private readonly KnightsRepository _repo;

    public KnightsService(KnightsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Knight> Get()
    {
      return _repo.Get();
    }

    internal Knight Get(int id)
    {
      Knight knight = _repo.Get(id);
      if (knight == null)
      {
        throw new Exception("Invalid Id");
      }
      return knight;
    }

    internal Knight Create(Knight newKnight)
    {
      Knight knight = _repo.Create(newKnight);
      if (knight == null)
      {
        throw new Exception("Invalid Id");
      }
      return knight;
    }

    internal Knight Edit(Knight updatedKnight)
    {
      // Find the original before edits
      Knight original = Get(updatedKnight.Id);
      // check each value on the incoming object, if it exits then allow it to continue, if it does not set it to the original value
      updatedKnight.Name = updatedKnight.Name != null ? updatedKnight.Name : original.Name;
      updatedKnight.Weapon = updatedKnight.Weapon != null ? updatedKnight.Weapon : original.Weapon;
      updatedKnight.RoundTable = updatedKnight.RoundTableWasSet ? updatedKnight.RoundTable : original.RoundTable;
      return _repo.Update(updatedKnight);
    }

    internal void Delete(int id)
    {
      Knight original = Get(id);
      _repo.Delete(id);
    }
  }
}