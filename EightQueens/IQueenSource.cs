using System.Collections.Generic;

namespace EightQueens
{
    public interface IQueenSource
    {
        IEnumerable<Queen> Queens();
    }
}