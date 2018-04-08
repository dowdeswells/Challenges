namespace CoderByte.CorrectPath
{
    public interface IBoard
    {
        bool IsValidCoordinate(Coordinate coord);
        bool IsFinish(Coordinate coord);
        Coordinate Start();
    }
}