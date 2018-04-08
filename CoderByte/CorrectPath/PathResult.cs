using System.Collections.Generic;

namespace CoderByte.CorrectPath
{
    public class PathResult
    {
        public bool HasSolution { get; private set; }

        public IEnumerable<IMovementCommand> Path { get; private set; }

        public static PathResult Solution(IEnumerable<IMovementCommand> path)
        {
            return new PathResult
            {
                HasSolution = true,
                Path = path
            };
        }

        public static PathResult NotSolvable()
        {
            return new PathResult
            {
                HasSolution = false,
                Path = new List<IMovementCommand>()
            };
        }
    }
}