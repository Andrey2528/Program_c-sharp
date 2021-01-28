using System;
using System.IO;

namespace pathfinder
{
    class pathFinder
    {
        string input = @"D:\Programmer\C#\pathfinder\pathfinder\input.txt";    //opening input file
        string output = @"D:\Programmer\C#\pathfinder\pathfinder\output.txt";  //opening output file
        int[,] Map;
        int MapWidht;//widgt
        int MapHeight;//height

        // Constructor
        public void ReadMap()
        {
            MapWidht = 18; //х
            MapHeight = 6; //у
            Map = new int[MapHeight, MapWidht];
        }
        public void fileReading() //file reading and line feed
        {
            using (StreamReader readText = File.OpenText(input))
            {
                string[] lines;
                using (StreamReader v = File.OpenText(input))
                {
                    string file = readText.ReadToEnd();
                    lines = file.Split('\n');
                    for (int i = 0; i < lines.Length; i++)
                    {
                        for (int j = 0; j < MapWidht; j++)
                        {
                            Map[i, j] = fileConvert(lines[i], j);
                        }
                    }
                }
                readText.Close();
            }
        }
        public int fileConvert(string line, int i) // takes a row and convert each element to a matrix
        {
            int element = 0;
            if (line[i] == '*')
            {
                element = 1;
            }
            else if (line[i] == ' ')
            {
                element = 0;
            }
            else if (line[i] == 'O')
            {
                element = 0;
            }
            else if (line[i] == 'E')
            {
                element = 0;
            }
            return element;
        }

        //search for a way
        public void FindWave(int startX, int startY, int targetX, int targetY)
        {
            bool add = true;
            int[,] cMap = new int[MapHeight, MapWidht];
            int x, y, step = 0;
            for (y = 0; y < MapHeight; y++)
                for (x = 0; x < MapWidht; x++)
                {
                    if (Map[y, x] == 1)
                        cMap[y, x] = -2;//wall indicator
                    else
                        cMap[y, x] = -1;//indicator has not yet set foot here
                }
            cMap[targetY, targetX] = 0;//Start from the finish line
            while (add == true)
            {
                add = false;
                for (y = 0; y < MapWidht; y++)
                    for (x = 0; x < MapHeight; x++)
                    {
                        if (cMap[x, y] == step)
                        {

                            //put the value of step + 1 in neighboring cells (if they are passable)
                            if (y - 1 >= 0 && cMap[x, y - 1] != -2 && cMap[x, y - 1] == -1)
                                cMap[x, y - 1] = step + 1;
                            if (x - 1 >= 0 && cMap[x - 1, y] != -2 && cMap[x - 1, y] == -1)
                                cMap[x - 1, y] = step + 1;

                            if (y + 1 < MapWidht && cMap[x, y + 1] != -2 && cMap[x, y + 1] == -1)
                                cMap[x, y + 1] = step + 1;
                            if (x + 1 < MapHeight && cMap[x + 1, y] != -2 && cMap[x + 1, y] == -1)
                                cMap[x + 1, y] = step + 1;
                        }
                    }
                step++;

                add = true;
                if (cMap[startY, startX] != -1)//decision found
                    add = true;
                if (step > MapWidht * MapHeight)//decision not found
                    add = false;
            }
            using (StreamWriter sw = new StreamWriter(output, true, System.Text.Encoding.Default))
            {
                for (y = 0; y < MapHeight; y++) //write in file output.txt
                {
                    string space = " ";
                    string wall = "*";
                    string Start = "O";
                    string Finish = "E";
                    string hod = ".";

                    for (x = 0; x < 19; x++)
                        if (x == MapWidht)
                        {
                            sw.Write("\n");
                        }
                        else
                        {
                            if (cMap[y, x] == -1)
                            {
                                sw.Write(space);
                            }
                            else
                                if (cMap[y, x] == -2)
                                {
                                    sw.Write(wall);
                                }
                            else
                                if (y == startY && x == startX)
                                {
                                    sw.Write(Start);
                                }
                            else
                                if (y == targetY && x == targetX)
                                {
                                    sw.Write(Finish);
                                }
                            else
                                if (cMap[y, x] > -1)
                                {
                                    sw.Write(hod, cMap[y, x]);
                                }
                        }
                }
                sw.Close();
            }

        }
        public static void Main()
        {
            pathFinder pf = new pathFinder();
            pf.ReadMap();
            pf.fileReading();
            pf.FindWave(2, 1, 11, 5);
            Console.WriteLine("The program worked, look at the file: output.txt \nplease click ENTER :)");
            Console.ReadKey();
        }
    }
}