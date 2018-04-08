using System;

namespace EightQueens
{
    public class Queen
    {
        public Queen(int row, int column)
        {
            Row = row;
            Column = column;
        }
        
        public bool IsAttacking(Queen anotherQueen)
        {
            return IsOnSameRowOrColumn(anotherQueen) ||
                   IsOnSameDiagonal(anotherQueen);
        }

        private bool IsOnSameDiagonal(Queen anotherQueen)
        {
            var xDiff = Math.Abs(this.Row - anotherQueen.Row);
            var yDiff = Math.Abs(this.Column - anotherQueen.Column);

            return xDiff == yDiff;
        }

        private bool IsOnSameRowOrColumn(Queen anotherQueen)
        {
            return
                this.Row == anotherQueen.Row ||
                this.Column == anotherQueen.Column;
        }

        public int Column { get; private set; }

        public int  Row { get; private set; }
    }
}