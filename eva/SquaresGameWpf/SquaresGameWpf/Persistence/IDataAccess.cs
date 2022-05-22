using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquaresGameWpf.Model;

namespace SquaresGameWpf.Persistence
{
    public interface IDataAccess
    {
        public void SaveGame(string path, int size, List<int> table, int bluePoint, int redPoint, int playerToMove);
        public GameStatus LoadGame(string path);
    }
}
