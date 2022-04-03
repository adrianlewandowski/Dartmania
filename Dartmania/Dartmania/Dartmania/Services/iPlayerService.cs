using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dartmania.Models;

namespace Dartmania.Services
{
    public interface IPlayerService
    {
        Task AddPlayer(string name);
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> GetPlayer(string name);
        Task RemovePlayer(int id);
    }
}
