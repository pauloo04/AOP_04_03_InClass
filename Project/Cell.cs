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
        public void ChangeState()
        {
            aliveState = !aliveState;
        }
        public int CountLiveNeighbors()
        {
            int count = 0;
            foreach (Cell neighbor in neighbors)
            {
                count += Convert.ToInt32(neighbor.aliveState);
            }
            return count;
        }
    }
}