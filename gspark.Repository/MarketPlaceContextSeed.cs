namespace gspark.Repository
{
    using gspark.Domain.Models;

    public class MarketPlaceContextSeed
    {
        public async static void SeedAsync(MarketPlaceContext dbContext)
        {
            await dbContext.Keys.AddRangeAsync
            (
                new Key { Id = 1, TrackKey = "A" },
                new Key { Id = 2, TrackKey = "A#" },
                new Key { Id = 3, TrackKey = "B" },
                new Key { Id = 4, TrackKey = "C" },
                new Key { Id = 5, TrackKey = "C#" },
                new Key { Id = 6, TrackKey = "D" },
                new Key { Id = 7, TrackKey = "D#" },
                new Key { Id = 8, TrackKey = "E" },
                new Key { Id = 9, TrackKey = "F" },
                new Key { Id = 10, TrackKey = "F#" },
                new Key { Id = 11, TrackKey = "G" },
                new Key { Id = 12, TrackKey = "G#" }
            );

            await dbContext.SaveChangesAsync();
        }
    }
}
