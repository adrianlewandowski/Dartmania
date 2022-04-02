using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dartmania.Models;

namespace Dartmania.Services
{
    public interface iPlayerService
    {
        Task AddPlayer(string name);
        Task<IEnumerable<Player>> GetPlayer();
        Task<Player> GetPlayer(int id);
        Task RemovePlayer(int id);
    }
}
