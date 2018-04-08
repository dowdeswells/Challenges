using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;

namespace EightQueens
{
    public class CoordinatesStringReader
    {
        private const string RowField = "ROW";
        private const string ColumnField = "COLUMN";
        
        private const string FieldRegexPattern = @"\((?<ROW>\d+)\,(?<COLUMN>\d+)\)";

        private const RegexOptions CultureInvariantIgnoreCase =
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;

        /// <summary>
        /// Transform a field string eg: (1,2)
        /// </summary>
        /// <param name="field">a field string eg: (1,2)</param>
        public Coordinate TransformField(string field)
        {
            Match match = Regex.Match(field, FieldRegexPattern, CultureInvariantIgnoreCase);

            var coord = BuildCoordinate(match);

            return coord;
        }

        private static Coordinate BuildCoordinate(Match match)
        {
            if (match.Groups.Count != 3)
            {
                return Coordinate.Empty();
            }
            int row, column;
            if (int.TryParse(match.Groups[RowField].Value, out row) &&
                int.TryParse(match.Groups[ColumnField].Value, out column))
            {
                {
                    return new Coordinate(row, column);
                }
            }

            return Coordinate.Empty();
        }
    }
}