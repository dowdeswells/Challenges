namespace CoderByte.CorrectPath
{
    public class PathElement
    {
        public bool IsToBeSolved { get; private set; }
        public IMovementCommand MovementCommand { get; private set; }

        public static PathElement Known(IMovementCommand cmd)
        {
            return new PathElement
            {
                IsToBeSolved = false,
                MovementCommand = cmd
            };
        }

        public static PathElement Unknown()
        {
            return new PathElement
            {
                IsToBeSolved = true,
                MovementCommand = null
            };
        }
    }
}