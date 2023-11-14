using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelGramApi.Models;

namespace TravelGramApi.Controllers
{
  [ApiController]
  public class ReviewsController : ControllerBase
  {
  private readonly TravelGramApiContext _db;

  public ReviewsController(TravelGramApiContext db)
    {
      _db = db;
    }
    
  [HttpGet ("Reviews")]
  public async Task<List<Review>> Get(int score, string author, string tagline, string body)
  {
  IQueryable<Review> query = _db.Review.AsQueryable();

    if (score != null)
    {
      query = query.Where(entry => entry.Score == score);
    }

      if (author != null)
    {
      query = query.Where(entry => entry.Author == author);
    }

    if (tagline != null)
    {
      query = query.Where(entry => entry.Tagline == tagline);
    }

    if (body != null)
    {
      query = query.Where(entry => entry.Body == body);
    }

    return await query.ToListAsync();
  }

  public ActionResult Create(Review review)
  {
    ViewBag.DestinationId = new SelectList(_db.Destinations, "DestinationId", "Name");
    return View();
  }


  [HttpPost]
  public async Task<ActionResult<Review>> Post(Review review)
  {
    _db.Reviews.Add(review);
    await _db.SaveChangesAsync();

    return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
  }
     
  

  [HttpGet ("Reviews/{id}")]
  public async Task<ActionResult<Review>> GetReview(int id)
  {
    var review = await _db.Review.FindAsync(id);

    if (review == null)
    {
      return NotFound();
    }
    return review;
  }    
    
    
  [HttpGet ("Destinations")]
  public ActionResult<List<Destination>> Get(string name, string country, string city)
  {
    IQueryable<Destination> query = _db.Destination.AsQueryable();

    if (name != null)
    {
      query = query.Where(entry =>Name == name);
    }
  }

  [HttpPut("Reviews/{id}")]
  public async Task<IActionResult> Put(int id, Review review)
  {
    if (id != review.ReviewId)
    {
      return BadRequest();
    }

    _db.Entry(review).State = EntityState.Modified;
    await _db.SaveChangesAsync();

    return NoContent();
  }

  [HttpPut("Destination/{id}")]
  public async Task<IActionResult> Put(int id, Destination destination)
  {
    if (id != destination.DestinationId)
    {
      return BadRequest();
    }

    _db.Entry(destination).State = EntityState.Modified;
    await _db.SaveChangesAsync();

    return NoContent();
  }

  [HttpDelete("Reviews/{id}")]
  public async Task<IActionResult> DeleteReview(int id)
  {
    var review = await _db.Review.FindAsync(id);

    if (review == null)
    {
      return NotFound();
    }

    _db.Review.Remove(review);
    await _db.SaveChangesAsync();

    return NoContent();
  }
      
  [HttpDelete("Destinations/{id}")]
  public async Task<IActionResult> DeleteDestination(int id)
  {
    var destination = await _db.Destination.FindAsync(id);

    if (destination == null)
    {
            return NotFound();
    }

    _db.Destination.Remove(destination);
    await _db.SaveChangesAsync();

    return NoContent();
  }
  
  }
}
