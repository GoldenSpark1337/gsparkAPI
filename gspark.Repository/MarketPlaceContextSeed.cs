using gspark.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using LogLevel = NLog.LogLevel;

namespace gspark.Repository
{
    using gspark.Domain.Models;

    public class MarketPlaceContextSeed
    {
        public static async Task SeedAsync(MarketPlaceContext dbContext, UserManager<User> userManager, 
            RoleManager<UserRole> roleManager, Logger logger)
        {
            try
            {
                if (!dbContext.Keys.Any())
                {
                    await dbContext.Keys.AddRangeAsync
                    (
                        new Key { Id = 1, Track_Key = "A" },
                        new Key { Id = 2, Track_Key = "A#" },
                        new Key { Id = 3, Track_Key = "B" },
                        new Key { Id = 4, Track_Key = "C" },
                        new Key { Id = 5, Track_Key = "C#" },
                        new Key { Id = 6, Track_Key = "D" },
                        new Key { Id = 7, Track_Key = "D#" },
                        new Key { Id = 8, Track_Key = "E" },
                        new Key { Id = 9, Track_Key = "F" },
                        new Key { Id = 10, Track_Key = "F#" },
                        new Key { Id = 11, Track_Key = "G" },
                        new Key { Id = 12, Track_Key = "G#" }
                    );
                }

                if (!dbContext.Subgenres.Any())
                {
                    await dbContext.Subgenres.AddRangeAsync(
                        new Subgenre {Id = 1, Name = "Old School", GenreId = 1},
                        new Subgenre{Id = 2, Name = "Trap", GenreId = 1},
                        new Subgenre{Id = 3, Name = "Club", GenreId = 1},
                        new Subgenre{Id = 4, Name = "East", GenreId = 1},
                        new Subgenre{Id = 5, Name = "Underground", GenreId = 1},
                        new Subgenre{Id = 6, Name = "Orchestral", GenreId = 1},
                        new Subgenre{Id = 7, Name = "West", GenreId = 1},
                        new Subgenre{Id = 8, Name = "Dirty South", GenreId = 1},
                        new Subgenre{Id = 9, Name = "Soul", GenreId = 2},
                        new Subgenre{Id = 10, Name = "Funk", GenreId = 2},
                        new Subgenre{Id = 11, Name = "New Soul", GenreId = 2},
                        new Subgenre{Id = 12, Name = "K-Pop", GenreId = 3},
                        new Subgenre{Id = 13, Name = "Indie", GenreId = 3},
                        new Subgenre{Id = 14, Name = "DanceHall", GenreId = 3},
                        new Subgenre{Id = 15, Name = "Hip-Hop", GenreId = 3},
                        new Subgenre{Id = 16, Name = "Classic Rock", GenreId = 4},
                        new Subgenre{Id = 17, Name = "Nu Metal", GenreId = 4},
                        new Subgenre{Id = 18, Name = "Alternative", GenreId = 4},
                        new Subgenre{Id = 19, Name = "Emo", GenreId = 4},
                        new Subgenre{Id = 20, Name = "Techno", GenreId = 5},
                        new Subgenre{Id = 21, Name = "House", GenreId = 5},
                        new Subgenre{Id = 22, Name = "DnB", GenreId = 5},
                        new Subgenre{Id = 23, Name = "DubStep", GenreId = 5},
                        new Subgenre{Id = 24, Name = "Synthwave", GenreId = 5},
                        new Subgenre{Id = 25, Name = "Ambient", GenreId = 5},
                        new Subgenre{Id = 26, Name = "Electro Swing", GenreId = 5},
                        new Subgenre{Id = 27, Name = "Afrobeat", GenreId = 6},
                        new Subgenre{Id = 28, Name = "Reggaeton", GenreId = 6},
                        new Subgenre{Id = 29, Name = "Dub", GenreId = 6},
                        new Subgenre{Id = 30, Name = "Roots", GenreId = 6},
                        new Subgenre{Id = 31, Name = "Christian", GenreId = 7},
                        new Subgenre{Id = 32, Name = "Progressive", GenreId = 7},
                        new Subgenre{Id = 33, Name = "Western", GenreId = 7},
                        new Subgenre{Id = 34, Name = "Bluegrass", GenreId = 7},
                        new Subgenre{Id = 35, Name = "Country Rock", GenreId = 7},
                        new Subgenre{Id = 36, Name = "Swing", GenreId = 8},
                        new Subgenre{Id = 37, Name = "Bossa nova", GenreId = 8},
                        new Subgenre{Id = 38, Name = "Vocal", GenreId = 8},
                        new Subgenre{Id = 39, Name = "Noir", GenreId = 8},
                        new Subgenre{Id = 40, Name = "Blues", GenreId = 8}
                    );
                }

                if (!dbContext.Genres.Any())
                {
                    await dbContext.Genres.AddRangeAsync(
                        new Genre {Id = 1, Name = "Hip-Hop"},
                        new Genre {Id = 2, Name = "RnB"},
                        new Genre {Id = 3, Name = "Pop"},
                        new Genre {Id = 4, Name = "Rock"},
                        new Genre {Id = 5, Name = "Electronic"},
                        new Genre {Id = 6, Name = "Reggae"},
                        new Genre {Id = 7, Name = "Country"},
                        new Genre {Id = 8, Name = "Jazz"},
                        new Genre {Id = 9, Name = "Kazakh"},
                        new Genre {Id = 10, Name = "Experimental"}
                    );
                }

                if (!dbContext.ProductTypes.Any())
                {
                    await dbContext.ProductTypes.AddRangeAsync(
                        new ProductType {Id = 1, Name = "Tracks"},
                        new ProductType {Id = 2, Name = "Kits"},
                        new ProductType {Id = 3, Name = "Services"},
                        new ProductType {Id = 4, Name = "Vsts"}
                        );
                }

                var roles = new List<UserRole>()
                {
                    new UserRole {Name = "Free"},
                    new UserRole {Name = "ProPage"},
                    new UserRole {Name = "Admin"}
                };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }

                if (!(await userManager.Users.AnyAsync()))
                {
                    var user = new User()
                    {
                        UserName = "gspark",
                        Email = "gspark1337@gmail.com",
                    };
                    await userManager.CreateAsync(user, "Nomad1984$$$");
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                
                
                
                await dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                logger.Log(LogLevel.Trace, exception.Message);
            }
        }
    }
}
