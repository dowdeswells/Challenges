using System.Collections.Generic;

namespace CoderByte.CorrectPath
{
    public interface IPathElementSource
    {
        IEnumerable<PathElement> PathElements();
    }
}