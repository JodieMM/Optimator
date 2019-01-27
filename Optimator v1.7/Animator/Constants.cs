using System.Drawing;
using System.Text.RegularExpressions;

namespace Animator
{
    /// <summary>
    /// Constant values used throughout the program.
    /// Can be modified here for changes to be applied everywhere.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public static class Constants
    {
        // Constant Values
        public static double MidX = 150;
        public static double MidY = 150;

        // Folders
        public static string PiecesFolder => "Pieces";
        public static string JoinsFolder => "Joins";
        public static string SetsFolder => "Sets";
        public static string ScenesFolder => "Scenes";
        public static string VideosFolder => "Videos";

        // Name Validation
        public static string WIPName => "Z WIP";
        public static Regex PermittedName = new Regex(@"^[A-Za-z0-9]+$");

        // Characters
        public static char[] Comma = new char[] { ',' };
        public static char[] Colon = new char[] { ':' };
        public static char[] Semi = new char[] { ';' };
        public static string CommaS = ",";
        public static string ColonS = ":";
        public static string SemiS = ";";

        // UI Precision
        public static int[] Ranges = new int[] { 0, 3, 5, 7, 9 };
        public static int ClickPrecision = 5;

        // File Extensions
        public static string Txt => ".txt";
        public static string Png => ".png";

        // Colours
        public static Color shadowShade = Color.DarkGray;
        public static Color highlight = Color.ForestGreen;
        public static Color select = Color.Red;

        // Piece Defaults
        public static Color defaultFill = Color.FromArgb(255, 204, 204, 255);
        public static Color defaultOutline = Color.FromArgb(255, 204, 240, 255);
        public static decimal defaultOutlineWidth = 2;
        public static string defaultPieceDetails = "wr100";

        // Piece Options
        public static string[] connectorOptions = { "line", "none" };
        public static object[] connectorOptionsReadable = new object[] { "Line", "Blank" };
        public static string[] fillOptions = { "fill", "gradient" };
        public static string[] solidOptions = { "s", "f" };

        // Scene Options
        public static object[] possibleChanges = new object[] { "X", "Y", "Rotation", "Turn", "Spin", "Size", "Order", "Removed" };
    }
}
