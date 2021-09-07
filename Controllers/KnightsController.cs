using System;
using System.Collections.Generic;
using Kingdoms.Models;
using Kingdoms.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kingdoms.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class KnightsController : ControllerBase
  {
    private readonly KnightsService _knightsService;

    public KnightsController(KnightsService knightsService)
    {
      _knightsService = knightsService;
    }

    // GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Knight>> Get()
    {
      try
      {
        IEnumerable<Knight> knights = _knightsService.Get();
        return Ok(knights);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // GetById
    [HttpGet("{id}")]
    public ActionResult<Knight> Get(int id)
    {
      try
      {
        Knight knight = _knightsService.Get(id);
        return Ok(knight);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Create
    [HttpPost]
    public ActionResult<Knight> Create([FromBody] Knight newKnight)
    {
      try
      {
        Knight knight = _knightsService.Create(newKnight);
        return Ok(knight);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Update
    [HttpPut("{id}")]
    public ActionResult<Knight> Edit([FromBody] Knight updatedKnight, int id)
    {
      try
      {
        updatedKnight.Id = id;
        Knight knight = _knightsService.Edit(updatedKnight);
        return Ok(knight);
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
        _knightsService.Delete(id);
        return Ok("Successfully Deleted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}