using System.Drawing;

namespace Optimator
{
    /// <summary>
    /// Constant values used throughout the program.
    /// Can be modified here for changes to be applied everywhere.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public static class Consts
    {
        // Setup
        public const string Version = "1.0.0";
        public const string Settings = "Settings.txt";
        public const string DefaultSettings = "DefaultSettings.txt";

        // Folders 
        public const string PiecesFolder = "Pieces";
        public const string SetsFolder = "Sets";
        public const string ScenesFolder = "Scenes";
        public const string VideosFolder = "Videos";

        // Types
        public const string Piece = "Piece";
        public const string Set = "Set";
        public const string Scene = "Scene";

        // File Extensions
        public const string Optr = ".optr";
        public const string Png = ".png";

        // Characters
        public static char[] Comma = new char[] { ',' };
        public static char[] Colon = new char[] { ':' };
        public static char[] Semi = new char[] { ';' };
        public static char[] Stop = new char[] { '.' };
        public const string CommaS = ",";
        public const string ColonS = ":";
        public const string SemiS = ";";

        // UI Precision
        public static int[] ClickPrecisions = new int[] { 0, 3, 5, 7, 9 };
        public const int DragPrecision = 5;
        public const int CentreBox = 150;

        // Piece Defaults
        public static Color defaultFill = Color.FromArgb(255, 204, 240, 255);
        public static Color defaultOutline = Color.FromArgb(255, 204, 204, 255);
        public const decimal defaultOutlineWidth = 2;
        public const string defaultPieceDetails = "wr100";

        // Piece Options
        public static string[] connectorOptions = { "line", "none" };
        public static object[] connectorOptionsReadable = new object[] { "Line", "Blank" };
        public static string[] fillOptions = { "fill", "gradient" };
        public static string[] solidOptions = { "s", "f" };

        // Colours
        public static Color shadowShade = Color.DarkGray;
        public static Color invisible = Color.FromArgb(0, 0, 0, 0);
        public static Color highlight = Color.ForestGreen;
        public static Color select = Color.Red;
        public static Color lowlight = Color.CadetBlue;
        public static Color option1 = Color.SaddleBrown;
        public static Color option2 = Color.Purple;

        // Scene Options
        public static object[] possibleChanges = new object[] { "X", "Y", "Rotation", "Turn", "Spin", "Size", "Order", "Removed" };
    }
}
