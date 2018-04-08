using System.Text;

namespace CoderByte.CorrectPath
{
    public class StringCommandReporter
    {
        public string ReportOn(PathResult result)
        {
            if (result.HasSolution)
            {
                return DecodePath(result);
            }

            return "No Solution";
        }

        private static string DecodePath(PathResult result)
        {
            StringBuilder pathAsLetters = new StringBuilder();
            foreach (var cmd in result.Path)
            {
                if (cmd is MoveUp)
                {
                    pathAsLetters.Append('u');
                }

                if (cmd is MoveDown)
                {
                    pathAsLetters.Append('d');
                }

                if (cmd is MoveLeft)
                {
                    pathAsLetters.Append('l');
                }

                if (cmd is MoveRight)
                {
                    pathAsLetters.Append('r');
                }
            }

            return pathAsLetters.ToString();
        }
    }
}