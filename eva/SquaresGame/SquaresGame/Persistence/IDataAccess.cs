using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquaresGame.Model;

namespace SquaresGame.Persistence
{
    public interface IDataAccess
    {
        public void SaveGame(string path, int size, List<int> table, int bluePoint, int redPoint, int playerToMove);
        public GameStatus LoadGame(string path);
    }
}
