namespace gspark.Repository
{
    public class DbInitializer
    {
        public static void Initialize(MarketPlaceContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
