using Microsoft.EntityFrameworkCore;
using MyFriends.Models;

namespace MyFriends.DAL
{
    public class DataLayer : DbContext
    {
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();
            Seed();
        }

        private void Seed()
        {
            if (Friends.Count() > 0) return;
         
            FriendModel friend = new FriendModel
            {
                FirstName = "אבי",
                LastName = "כהן",
                EmailAddress = "aa@aa.com",
                Phone = "052-1234567"
            };
            Friends.Add(friend);
            SaveChanges();
            
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            //SqlServerDbContextOptionsExtensions
            return new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .Options;
        }

        public DbSet<FriendModel> Friends { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
