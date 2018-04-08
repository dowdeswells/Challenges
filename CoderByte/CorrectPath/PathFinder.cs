using System.Collections.Generic;
using System.Linq;

namespace CoderByte.CorrectPath
{
    public class PathFinder
    {
        private readonly IBoard _board;

        public PathFinder(IBoard board)
        {
            _board = board;
        }

        public PathResult Solve(IPathElementSource commandSource)
        {
            var start = Trail.Start(_board);
            List<Trail> trails = new List<Trail>();
            trails.Add(start);
            
            foreach (var cmd in commandSource.PathElements())
            {
                if (cmd.IsToBeSolved)
                {
                    trails = ForkTrailsInAllDirections(trails);
                }
                else
                {
                    trails = AdvanceTrails(trails, cmd.MovementCommand);
                }
            }

            var finished = trails.FirstOrDefault(t => t.IsComplete());
            if (finished != null)
            {
                return PathResult.Solution(finished.MovementCommands);
            }
            else
            {
                return PathResult.NotSolvable();
            }
        }

        private List<Trail> ForkTrailsInAllDirections(List<Trail> trails)
        {
            List<Trail> forkedTrails = new List<Trail>();

            foreach (var trail in trails)
            {
                var forks = new IMovementCommand[] { new MoveDown(), new MoveLeft(), new MoveRight(), };
                foreach (var forkCmd in forks)
                {
                    var forked = trail.Fork();
                    forked.Move(forkCmd);
                    forkedTrails.Add(forked);
                }
                trail.Move(new MoveUp());
                forkedTrails.Add(trail);
            }
            return FilterValidTrails(forkedTrails);
        }

        private List<Trail> AdvanceTrails(List<Trail> trails, IMovementCommand cmd)
        {
            foreach (var trail in trails)
            {
                trail.Move(cmd);
            }

            return FilterValidTrails(trails);
        }

        private static List<Trail> FilterValidTrails(List<Trail> trails)
        {
            return trails.Where(t => t.IsValid).ToList();
        }
    }
}