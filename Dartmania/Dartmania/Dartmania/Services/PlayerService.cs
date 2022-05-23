using Dartmania.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Dartmania.Services;

[assembly: Dependency(typeof(PlayerService))]
namespace Dartmania.Services
{
    public class PlayerService : IPlayerService
    {
        SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Player>();
        }
        public async Task AddPlayer(string name)
        {
            await Init();

            var player = new Player
            {
                Name = name,
                AverageScore = 0,
                BestScore = 0
            };

            await db.InsertAsync(player);
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            await Init();

            var players = await db.Table<Player>().ToListAsync();
            return players;
        }

        public async Task<Player> GetPlayer(string name)
        {
            await Init();

            var player = await db.Table<Player>()
                .FirstOrDefaultAsync(c => c.Name == name);
            return player;
        }

        public Task RemovePlayer(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateScore(string name, double score)
        {
            await Init();
            var player = await db.Table<Player>()
                .FirstOrDefaultAsync(c => c.Name == name);
            if(player.AverageScore != 0)
            {
                player.AverageScore = (player.AverageScore + score) / 2;
            }
            else
            {
                player.AverageScore = score;
            }

            await db.UpdateAsync(player);
        }

    }
}
