namespace gspark.Repository
{
    using gspark.Domain.Models;

    public class MarketPlaceContextSeed
    {
        public async static void SeedAsync(MarketPlaceContext dbContext)
        {
            //await dbContext.Keys.AddRangeAsync
            //(
            //    new TrackKey { Id = 1, Track_Key = "A" },
            //    new TrackKey { Id = 2, Track_Key = "A#" },
            //    new TrackKey { Id = 3, Track_Key = "B" },
            //    new TrackKey { Id = 4, Track_Key = "C" },
            //    new TrackKey { Id = 5, Track_Key = "C#" },
            //    new TrackKey { Id = 6, Track_Key = "D" },
            //    new TrackKey { Id = 7, Track_Key = "D#" },
            //    new TrackKey { Id = 8, Track_Key = "E" },
            //    new TrackKey { Id = 9, Track_Key = "F" },
            //    new TrackKey { Id = 10, Track_Key = "F#" },
            //    new TrackKey { Id = 11, Track_Key = "G" },
            //    new TrackKey { Id = 12, Track_Key = "G#" }
            //);

            //await dbContext.SaveChangesAsync();
        }
    }
}
