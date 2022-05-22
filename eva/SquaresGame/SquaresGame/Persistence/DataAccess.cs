using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquaresGame.Model;

namespace SquaresGame.Persistence
{
    public class DataAccess : IDataAccess
    {
        
        public void SaveGame(string path, int size, List<int> table, int bluePoint, int redPoint, int playerToMove)
        {

            try
            {
                StreamWriter sw = new StreamWriter(path);

                //size bluePoint redPoint playerToMove <--- is written to the first line of the file
                sw.WriteLine(size + " " + bluePoint + " " + redPoint + " " + playerToMove);

                //Writing the table in matrix format (size x size) to the file

                //A-version
                /*
                for (int i = 0; i < size*size; i++)
                {
                    if (i % size == size-1)
                    {
                        sw.WriteLine(table[i] + " ");
                    }
                    else
                    {
                        sw.Write(table[i] + " ");
                    }
                }
                */

                //B-version 

                for (int i = 0; i < size * size; i += size)
                {

                    for (int j = i; j < (i + size); j++)
                    {
                        sw.Write(table[j] + " ");

                    }
                    sw.Write("\n");
                }

                sw.Close();
            }
            catch
            {
                throw new DataAccessException();
            }

            

            
        }

        public GameStatus LoadGame(string path)
        {
            int size = 0;
            int blueP = 0;
            int redP = 0;
            int playerToMove = 0;
            List<int> table = new List<int>();



            try
            {
                StreamReader sr = new StreamReader(path);
                String line = sr.ReadLine();
                string[] numbers = line.Split(' ');
                size = Convert.ToInt32(numbers[0]);
                blueP = Convert.ToInt32(numbers[1]);
                redP = Convert.ToInt32(numbers[2]);
                playerToMove = Convert.ToInt32(numbers[3]);
                
                for (int i = 0; i < size; i++)
                {
                    string row = sr.ReadLine();
                    string[] separated = row.Split(' ');
                    for (int j = 0; j < size; j++)
                    {
                        table.Add(Convert.ToInt32(separated[j]));
                    }
                }
                sr.Close();
     
            }

            catch
            {
                throw new DataAccessException();
            }

            GameStatus gs = new GameStatus(size, blueP, redP, playerToMove, table);
            return gs;


        }


    }
}
