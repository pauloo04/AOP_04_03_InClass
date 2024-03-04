using System.Diagnostics;

namespace GameOfLife
{
    public class Cell : ICell
    {
        public bool aliveState { set; get; }
        public List<Cell> neighbors { set; get; }
        public Cell(bool s)
        {
            aliveState = s;
            neighbors = [];
        }
    }
}