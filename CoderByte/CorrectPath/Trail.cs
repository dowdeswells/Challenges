using System.Collections.Generic;
using System.Linq;

namespace CoderByte.CorrectPath
{
    public class Trail 
    {
        private readonly IBoard _board;
        private List<Coordinate> _coordinates = new List<Coordinate>();
        private List<IMovementCommand> _commands = new List<IMovementCommand>();
        
        public bool IsValid { get; private set; }

        public IReadOnlyCollection<Coordinate> TrailCoordinates
        {
            get { return _coordinates.AsReadOnly(); }
        }

        private Trail(IBoard board)
        {
            _board = board;
            IsValid = true;
        }
        
        public static Trail Start(IBoard board)
        {
            var trail = new Trail(board);
            trail._coordinates.Add(board.Start());
            return trail;
        }

        public void Move(IMovementCommand cmd)
        {
            var nextPosition = cmd.Move(CurrentPosition);
            if (!_board.IsValidCoordinate(nextPosition))
            {
                Abort();
                return;
            }

            if (HasBeenHereBefore(nextPosition))
            {
                Abort();
                return;
            }
            
            _coordinates.Add(nextPosition);
            _commands.Add(cmd);
            
        }
        
        public void Abort()
        {
            IsValid = false;
        }
        
        public bool IsComplete()
        {
            return IsValid && _board.IsFinish(CurrentPosition);
        }
        
        public Coordinate CurrentPosition
        {
            get { return _coordinates.Last(); }
        }

        public IReadOnlyCollection<IMovementCommand> MovementCommands
        {
            get { return _commands.AsReadOnly(); }
        }

        public bool HasBeenHereBefore(Coordinate nextPosition)
        {
            return _coordinates
                .Any(c => c.Equals(nextPosition));
        }

        public Trail Fork()
        {
            var trail = new Trail(_board);
            trail._coordinates = new List<Coordinate>(_coordinates);
            trail._commands = new List<IMovementCommand>(_commands);
            return trail;
        }
    }
}