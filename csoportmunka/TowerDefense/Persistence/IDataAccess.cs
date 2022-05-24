using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Persistence
{
    public interface IDataAccess
    {
        public Task Save(SaveData data, string location, bool overwrite);
        public Task<SaveData> Load(string name, string location);
        public Task Delete(string name, string location);
        public Task<string[]> GetSaveNames(string location);
    }
}
