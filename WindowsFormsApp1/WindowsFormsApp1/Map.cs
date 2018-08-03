using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Map
    {
        private List<MapTile> Tiles;
        public string Name { get; set; }
        public int MapHeight { get; set; }
        public int MapWidth { get; set; }

        public Map()
        {
            Tiles = new List<MapTile>();
        }

        public MapTile[] GetTiles()
        {
            return Tiles.ToArray();
        }

        public void SaveMapToFile(string path)
        {
            string savedata = "name=" + Name + Environment.NewLine;
            savedata       += "width=" + MapWidth + Environment.NewLine;
            savedata       += "height=" + MapHeight + Environment.NewLine;
            savedata       += "---tiles---" + Environment.NewLine;

            foreach (MapTile tile in Tiles)
            {
                string strCords = tile.Coords.X + "," + tile.Coords.Y;
                string curTile = "path=" + tile.PathToImage + Environment.NewLine;
                curTile += "cords=" + strCords + Environment.NewLine;

                savedata += curTile;
            }
            File.WriteAllText(path, savedata);
        }

        public void LoadMapFromPath(string path)
        {
            Clear();

            string[] savedata = File.ReadAllLines(path);
            Name = savedata[0].Split('=')[1];
            MapWidth = Convert.ToInt32(savedata[1].Split('=')[1]);
            MapHeight = Convert.ToInt32(savedata[2].Split('=')[1]);

            for (int i = 4; i < savedata.Length; i += 2)
            {
                string[] point = savedata[i + 1].Split('=')[1].Split(',');
                int x = Convert.ToInt32(point[0]);
                int y = Convert.ToInt32(point[1]);

                MapTile tile = new MapTile { PathToImage = savedata[i].Split('=')[1], Coords = new Point(x, y) };
                Tiles.Add(tile);
            }
        }

        public void AddTile(MapTile tile)
        {
            Tiles.Add(tile);
        }

        public void RemoveAt(int i)
        {
            Tiles.RemoveAt(i);
        }

        public void Clear()
        {
            Tiles.Clear();
        }
    }
}
