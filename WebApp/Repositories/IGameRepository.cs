using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    interface IGameRepository
    {
        IEnumerable<Game> Games { get; }

        void AddGame(Game game);

        void EditGame(Game game);

        void DeleteGame(Game game);

        Game GetGameId(int gameId);

    }
}
