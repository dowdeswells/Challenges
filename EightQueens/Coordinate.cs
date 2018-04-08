namespace EightQueens
{
    public struct Coordinate
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static bool operator ==(Coordinate c1, Coordinate c2)
        {
            return c1.Row == c2.Row && c1.Column == c2.Column;
        }
        
        public static bool operator !=(Coordinate c1, Coordinate c2)
        {
            return !(c1 == c2);
        }
        
        public static Coordinate Empty()
        {
            return new Coordinate(0,0);
        }
    }
}