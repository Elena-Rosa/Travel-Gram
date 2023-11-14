using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelGramApi.Models;

namespace TravelGramApi.Controllers
{
  [ApiController]
  public class DestinationsController : ControllerBase
  {
    private readonly TravelGramApiContext _db;

    public DestinationsController(TravelGramApi db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<List<Destination>> Get(string name, string country, name city)
    {
      IQueryable<Destination> query = _db.Destination.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry =>Name == name);
      }

      if (country != null)
      {
        query = query.Where(entry =>Country == country);
      }

      if (city != null)
      {
        query = query.Where(entry =>City == city);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Destination>> GetDestination(int id)
    {
      Destination destination = await _db.Destinations.FindAsync(id);

      if (destination == null)
      {
        return NotFound();
      }
      return destination;
    }

    [HttpPost]
    public async Task<ActionResult<Destination>> Post(Destination destination)
    {
      if (id != destination.DestinationId)
      {
        return BadRequest();
      }

      _db.Destinations.Update(destination);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch
      {
        if (!DestinationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
      Destination destination = await _db.Destination.FindAsync(id);
      if (destination == null)
      {
        return NotFound();
      }

      _db.Destinations.Remove(destination);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  
  }
}

// public ActionResult Details(int id)
//     {
//       Flavor thisFlavor = _db.Flavors
//           .Include(flavor => flavor.Treat)
//           .Include(flavor => flavor.JoinEntities)
//           .ThenInclude(join => join.Treat)
//           .FirstOrDefault(flavor => flavor.FlavorId == id);
//       return View(thisFlavor);
//     }