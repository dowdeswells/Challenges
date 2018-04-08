namespace EightQueens
{
    public class FindQueenResult
    {
        public bool Found { get; private set; }
        public Queen Queen { get; private set; }

        private FindQueenResult()
        {
            
        }
        
        public static FindQueenResult NotFound()
        {
            return new FindQueenResult
            {
                Found = false,
                Queen = null
            };
        }

        public static FindQueenResult FoundQueen(Queen queen)
        {
            return new FindQueenResult
            {
                Found = true,
                Queen = queen
            };        
        }
    }
}