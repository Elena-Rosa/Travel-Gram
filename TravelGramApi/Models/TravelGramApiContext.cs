using Microsoft.EntityFrameworkCore;

namespace TravelGramApi.Models
{
    public class TravelGramApiContext: DbContext
    {
        public Dbset<Review> Reviews {get; set; }
        public Dbset<Destination> Destinations {get; set; }
        public Dbset<Travelor> Travelors {get; set; }
        public TravelGramApiContext(DbContextOptions<TravelGramApi> options) : base(options)
        {
        }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //    builder.Entity<Review>()
        //     .HasData(
        //         new Review { ReviewId = 1, Score = 5, Author = "John", Tagline = "Best place to ski!", body = "My family enjoyed our stay in the cabin. It was so cozy!"},
        //         new Review { ReviewId = 2, Score = 4, Author = "Amy", Tagline = "Nice place to try all the food!", body = "My hubby and I enjoyed our view from the 25th floor. It was awesome!"},
        //         new Review { ReviewId = 3, Score = 3, Author = "Tom", Tagline = "So so vibes on the trail!", body = "My family almost got attacked by a bear. Not fun!"},
        //         new Review { ReviewId = 4, Score = 2, Author = "Kelly", Tagline = "Pretty terrible for a beach in Florida!", body = "My family didn't enjoy their stay in the bungalow. It was so hot!"},
        //         new Review { ReviewId = 5, Score = 1, Author = "Bob", Tagline = "Worst place to ski!", body = "My family hated our stay in the cabin. It was not cozy!"}
        //     );
        // }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Destinations>()
        //     .HasData(
        //         new Review { DestinationId = 1, Name = "Aspen Snowmass", City = "Aspen", Country = "United States"},
        //         new Review { DestinationId = 2, Name = "Chinese Street Food", City = "Shanghai", Country = "China"},
        //         new Review { DestinationId = 3, Name = "Appalachian Trail", City = "Harpers Ferry", Country = "United States"},
        //         new Review { DestinationId = 4, Name = "Emerald Coast", City = "Destin", Country = "United States"}
        //     );
        // }
    }
}