namespace CoderByte.CorrectPath
{
    public struct Coordinate
    {
        public int x;
        public int y;

        public bool Equals(Coordinate coord)
        {
            return x == coord.x && y == coord.y;
        }

    }
}