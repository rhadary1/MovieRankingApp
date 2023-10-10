using Microsoft.EntityFrameworkCore;
using RankingApp.Enums;
using RankingApp.Model;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace RankingApp.Database
{
    public static class DbInitializer
    {
        public static void Initialize(
            RankedItemContext rankedItemContext,
            UserContext userContext)
        {
            rankedItemContext.Database.EnsureCreated();
            userContext.Database.EnsureCreated();

            // Look for any students.
            if (!rankedItemContext.RankedItems.Any())
            {
                var items = new RankedItem[]
                {
                    new RankedItem{Title = "The Godfather", ImageId=1, Ranking=0, Type=ItemType.Movie },
                    new RankedItem{Title = "Highlander", ImageId=2, Ranking=0, Type=ItemType.Movie },
                    new RankedItem{Title = "Highlander II", ImageId=3, Ranking=0, Type=ItemType.Movie },
                    new RankedItem{Title = "The Last of the Mohicans", ImageId=4, Ranking=0, Type=ItemType.Movie },
                    new RankedItem{Title = "Police Academy 6", ImageId=5, Ranking=0, Type=ItemType.Movie },
                    new RankedItem{Title = "Rear Window", ImageId=6, Ranking=0, Type=ItemType.Movie },
                    new RankedItem{Title = "Road House", ImageId=7, Ranking=0, Type=ItemType.Movie },
                    new RankedItem{Title = "The Shawshank Redemption", ImageId=8, Ranking=0, Type=ItemType.Movie },
                    new RankedItem{Title = "Star Treck IV", ImageId=9, Ranking=0, Type=ItemType.Movie },
                    new RankedItem{Title = "Superman 4", ImageId=10, Ranking=0, Type=ItemType.Movie },
                    new RankedItem{Title = "Abbey Road", ImageId=11, Ranking=0, Type=ItemType.Album },
                    new RankedItem{Title = "Adrenalize", ImageId=12, Ranking=0, Type=ItemType.Album },
                    new RankedItem{Title = "Back in Black", ImageId=13, Ranking=0, Type=ItemType.Album },
                    new RankedItem{Title = "Enjoy the Silence", ImageId=14, Ranking=0, Type=ItemType.Album },
                    new RankedItem{Title = "Parachutes", ImageId=15, Ranking=0, Type=ItemType.Album },
                    new RankedItem{Title = "Ride the Lightning", ImageId=16, Ranking=0, Type=ItemType.Album },
                    new RankedItem{Title = "Rock or Bust", ImageId=17, Ranking=0, Type=ItemType.Album },
                    new RankedItem{Title = "Rust in Peace", ImageId=18, Ranking=0, Type=ItemType.Album },
                    new RankedItem{Title = "St. Anger", ImageId=19, Ranking=0, Type=ItemType.Album },
                    new RankedItem{Title = "The Final Countdown", ImageId=20, Ranking=0, Type=ItemType.Album }

                };

                foreach (var item in items)
                {
                    rankedItemContext.RankedItems.Add(item);
                }

                /* To clear all records, uncomment
                var allRecords = context.RankedItems.ToList(); // Replace "YourDbSet" with the DbSet for your table
                context.RankedItems.RemoveRange(allRecords); */

                rankedItemContext.SaveChanges();
            }

            if (!userContext.Users.Any())
            {
                var users = new User[]
                {
                    new User { Name="TestUser", Email="TestUser@google.com", Password="P@ssw0rd" },
                };

                foreach (var user in users)
                {
                    userContext.Users.Add(user);
                }

                userContext.SaveChanges();
            }
        }
    }
}
