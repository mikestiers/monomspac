using System;
using System.Collections.Generic;
using System.Text;

namespace MsPacMan.Entities
{
    public class Cell
    {
        public Cell(int x, int y, bool isDot, bool visited)
        {
            this.squareSize = 12;
            this.x = x;
            this.y = y;
            this.isDot = isDot;
            this.visited = visited;
        }
        public int squareSize = 12;
        public int x { get; set; }
        public int y { get; set; }
        public bool isDot { get; set; }
        public bool visited { get; set; }
    }
}
