using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Helper
    {
        public static ChessClient ChessClient { get; set; }
        public static KeyValuePair<int, int> NotationToCoordinates(string notation)
        {
            List<string> a = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h" };
            KeyValuePair<int, int> coordinates = new KeyValuePair<int, int>(Math.Abs(Convert.ToInt32(notation[1].ToString()) - 8), a.FindIndex(x => x == notation[0].ToString()));
            return coordinates;
        }
        public static string CoordinatesToNotation(KeyValuePair<int, int> coordinates)
        {
            string[] a = new string[8] { "a", "b", "c", "d", "e", "f", "g", "h" };
            return a[coordinates.Value] + Math.Abs(coordinates.Key - 8);
        }
    }
}
