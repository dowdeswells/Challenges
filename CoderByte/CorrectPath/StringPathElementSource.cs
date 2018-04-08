using System.Collections.Generic;

namespace CoderByte.CorrectPath
{
    public class StringPathElementSource : IPathElementSource
    {
        private readonly string _stringOfMovementCommands;

        public StringPathElementSource(string stringOfMovementCommands)
        {
            _stringOfMovementCommands = stringOfMovementCommands;
        }

        public IEnumerable<PathElement> PathElements()
        {
            foreach (var ch in _stringOfMovementCommands.ToCharArray())
            {
                var movementCommand = TranslateCharCommand(ch);
                yield return movementCommand;
            }
        }

        private static PathElement TranslateCharCommand(char characterCmd)
        {
            switch (characterCmd)
            {
                case 'u':
                    return PathElement.Known(new MoveUp());

                case 'd':
                    return PathElement.Known(new MoveDown());

                case 'l':
                    return PathElement.Known(new MoveLeft());

                case 'r':
                    return PathElement.Known(new MoveRight());

                default:
                    return PathElement.Unknown();
            }
        }


    }
}