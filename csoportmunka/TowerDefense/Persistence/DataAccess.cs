using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TowerDefense.Persistence
{
    public class DataAccess : IDataAccess
    {
        public async Task Save(SaveData data, string location, bool overwrite)
        {
            if (data == null)
                throw new DataException("Saving failed.");

            if (overwrite)
            {
                await Delete(data.SaveName, location);
            }

            var uniqueName = string.Format(@"{0}.json", Guid.NewGuid());
            string outputJSON = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            await File.WriteAllTextAsync($"{location}/{uniqueName}", outputJSON);
        }

        public async Task<SaveData> Load(string name, string location)
        {
            if (!Directory.Exists(location))
                throw new DataException("No saves!");

            string[] saves = Directory.GetFiles(location, "*.json");

            SaveData data = null;

            for (int i = 0; i < saves.Length; ++i)
            {
                string inputJSON = await File.ReadAllTextAsync(saves[i]);
                data = JsonConvert.DeserializeObject<SaveData>(inputJSON, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

                if (data.SaveName == name)
                    break;
            }

            return data;
        }

        public async Task Delete(string name, string location)
        {
            if (!Directory.Exists(location))
                throw new DataException("No saves!");

            string[] saves = Directory.GetFiles(location, "*.json");

            SaveData data = null;

            int i;
            for (i = 0; i < saves.Length; ++i)
            {
                string inputJSON = await File.ReadAllTextAsync(saves[i]);
                data = JsonConvert.DeserializeObject<SaveData>(inputJSON, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

                if (data.SaveName == name)
                    break;
            }

            File.Delete(saves[i]);
        }

        public async Task<string[]> GetSaveNames(string location)
        {
            if (!Directory.Exists(location))
                throw new DataException("No saves!");

            string[] saves = Directory.GetFiles(location, "*.json");
            string[] saveNames = new string[saves.Length];

            for (int i = 0; i < saves.Length; ++i)
            {
                string inputJSON = await File.ReadAllTextAsync(saves[i]);
                SaveData data = JsonConvert.DeserializeObject<SaveData>(inputJSON, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                saveNames[i] = data.SaveName;
            }

            return saveNames;
        }
    }
}
