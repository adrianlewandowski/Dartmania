using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Dartmania.Models;

namespace Dartmania.Services
{
    public static class DbServcies
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Player>();
        }

        public static async Task AddPlayer(string name)
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

        public static async Task RemovePlayer(int id)
        {
            await Init();

            await db.DeleteAsync<Player>(id);
        }

        public static async Task GetPlayer(string name)
        {
            await Init();
        }

        public static async Task<IEnumerable<Player>> GetPlayersList()
        {
            await Init();

            var players_list = await db.Table<Player>().ToListAsync();
            return players_list;
        }

        public static async Task GetPlayerScores(int id)
        {
            await Init();
        }
        //Dodanie w ilu rzutach skończył?
        public static async Task AddPlayerThrows(string name,string score)
        {
            await Init();
        }

        // Funnkcja dodaje średnią z 3 rzutów do bazy
        public static async Task AddPlayerAverageScore(string name, int score)
        {
            await Init();
        }

        public static async Task GetPlayerAverageScore(int id)
        {
            await Init();
        }

    }
}
