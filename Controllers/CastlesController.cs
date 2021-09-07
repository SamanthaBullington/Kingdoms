using System;
using System.Collections.Generic;
using Kingdoms.Models;
using Kingdoms.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kingdoms.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class CastlesController : ControllerBase
  {
    private readonly CastlesService _castlesService;

    public CastlesController(CastlesService castlesService)
    {
      _castlesService = castlesService;
    }

    // GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Castle>> Get()
    {
      try
      {
        IEnumerable<Castle> castles = _castlesService.Get();
        return Ok(castles);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // GetById
    [HttpGet("{id}")]
    public ActionResult<Castle> Get(int id)
    {
      try
      {
        Castle castle = _castlesService.Get(id);
        return Ok(castle);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Create
    [HttpPost]
    public ActionResult<Castle> Create([FromBody] Castle newCastle)
    {
      try
      {
        Castle castle = _castlesService.Create(newCastle);
        return Ok(castle);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Update
    [HttpPut("{id}")]
    public ActionResult<Castle> Edit([FromBody] Castle updatedCastle, int id)
    {
      try
      {
        updatedCastle.Id = id;
        Castle castle = _castlesService.Edit(updatedCastle);
        return Ok(castle);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Destroy
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _castlesService.Delete(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}