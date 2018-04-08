using System.Collections.Generic;
using System.Linq;

namespace EightQueens
{
    public class AttackingQueenFinder
    {
        private readonly IQueenSource _queenSource;

        public AttackingQueenFinder(IQueenSource queenSource)
        {
            _queenSource = queenSource;
        }

        public FindQueenResult FindAttacker()
        {
            return FindFirstAttackingQueen(_queenSource.Queens().ToList());
        }
        
        private FindQueenResult FindFirstAttackingQueen(IList<Queen> queens)
        {
            for (int i = 0; i < queens.Count; i++)
            {
                var primaryQueen = queens[i];
                for (int j = i + 1; j < queens.Count; j++)
                {
                    var secondaryQueen = queens[j];
                    if (primaryQueen.IsAttacking(secondaryQueen))
                    {
                        return FindQueenResult.FoundQueen(primaryQueen);
                    }
                }
            }

            return FindQueenResult.NotFound();
        }
        
    }
}