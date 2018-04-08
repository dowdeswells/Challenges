namespace CoderByte.CorrectPath
{
    public interface IMovementCommand
    {
        Coordinate Move(Coordinate currentPos);
    }


    public class MoveUp : IMovementCommand
    {
        public Coordinate Move(Coordinate currentPos)
        {
            return new Coordinate
            {
                x = currentPos.x,
                y = currentPos.y - 1
            };
        }
    }

    public class MoveDown : IMovementCommand
    {
        public Coordinate Move(Coordinate currentPos)
        {
            return new Coordinate
            {
                x = currentPos.x,
                y = currentPos.y + 1
            };
        }
    }

    public class MoveLeft : IMovementCommand
    {
        public Coordinate Move(Coordinate currentPos)
        {
            return new Coordinate
            {
                x = currentPos.x - 1,
                y = currentPos.y
            };
        }
    }

    public class MoveRight : IMovementCommand
    {
        public Coordinate Move(Coordinate currentPos)
        {
            return new Coordinate
            {
                x = currentPos.x + 1,
                y = currentPos.y
            };
        }
    }
    
}