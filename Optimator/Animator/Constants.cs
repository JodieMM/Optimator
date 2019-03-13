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
        // Folders
        public const string PiecesFolder = "Pieces";
        public static string SetsFolder => "Sets";
        public static string ScenesFolder => "Scenes";
        public static string VideosFolder => "Videos";

        // Name Validation
        public const string WIPName = "Z WIP";
        public static Regex PermittedName = new Regex(@"^[A-Za-z0-9]+$");

        // Characters
        public static char[] Comma = new char[] { ',' };
        public static char[] Colon = new char[] { ':' };
        public static char[] Semi = new char[] { ';' };
        public const string CommaS = ",";
        public const string ColonS = ":";
        public const string SemiS = ";";

        // UI Precision
        public static int[] Ranges = new int[] { 0, 3, 5, 7, 9 };
        public const int ClickPrecision = 5;

        // File Extensions
        public const string Txt = ".txt";
        public const string Png = ".png";
        public const string Optr = ".optr";

        // Colours
        public static Color shadowShade = Color.DarkGray;
        public static Color invisible = Color.FromArgb(0, 0, 0, 0);
        public static Color highlight = Color.ForestGreen;
        public static Color select = Color.Red;

        // Piece Defaults
        public static Color defaultFill = Color.FromArgb(255, 204, 240, 255);
        public static Color defaultOutline = Color.FromArgb(255, 204, 204, 255);
        public const decimal defaultOutlineWidth = 2;
        public const string defaultPieceDetails = "wr100";
        public const string defaultAngleOptions = "150;150;0;0;0;100";

        // Piece Options
        public static string[] connectorOptions = { "line", "none" };
        public static object[] connectorOptionsReadable = new object[] { "Line", "Blank" };
        public static string[] fillOptions = { "fill", "gradient" };
        public static string[] solidOptions = { "s", "f" };
        
        // Scene Options
        public static object[] possibleChanges = new object[] { "X", "Y", "Rotation", "Turn", "Spin", "Size", "Order", "Removed" };

        // Version
        public const string Version = "Version 1.0.0";
    }
}
