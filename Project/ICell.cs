namespace GameOfLife
{
    public interface ICell
    {
        public bool aliveState { set; get; }
        public List<Cell> neighbors { set; get; }
    }
}