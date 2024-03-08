namespace GameOfLife
{
    public class AutomationSimulator
    {
        public static void NextGeneration(Grid grid)
        {
            List<Cell> changed = [];
            foreach (List<Cell> row in grid.grid){
                foreach (Cell cell in row)
                {
                    if ((cell.aliveState && cell.CountLiveNeighbors() < 2) ||
                    (cell.aliveState && cell.CountLiveNeighbors() > 3) ||
                    (!cell.aliveState && cell.CountLiveNeighbors() == 3))
                    {
                        changed.Add(cell);
                    }
                }
            }
            foreach (Cell cell in changed)
            {
                cell.ChangeState();
            }
        }
    }
}