namespace CoderByte.CorrectPath
{
    public class SquareBoard : IBoard
    {
        private readonly int _size;

        public SquareBoard(int size)
        {
            _size = size;
        }

        public bool IsValidCoordinate(Coordinate coord)
        {
            if (coord.x < 1 || coord.x > _size)
            {
                return false;
            }
            if (coord.y < 1 || coord.y > _size)
            {
                return false;
            }

            return true;
        }

        public bool IsFinish(Coordinate coord)
        {
            return (coord.x == _size && coord.y == _size);
        }

        public Coordinate Start()
        {
            return new Coordinate
            {
                x = 1,
                y = 1
            };
        }
        
    }
}