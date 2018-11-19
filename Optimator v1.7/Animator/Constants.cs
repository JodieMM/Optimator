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
        public static double MidX = 325;
        public static double MidY = 325;

        // Folders
        public static string PiecesFolder => "\\Pieces\\";
        public static string PointsFolder => "\\Points\\";
        public static string SetsFolder => "\\Sets\\";
        public static string ScenesFolder = "\\Scenes\\";

        // Reserved Names
        public static string PieceStructure => "ZPieceScaffold";
        public static string PointStructure => "ZPointScaffold";
        public static string SetStructure => "ZSetScaffold";
        public static string SceneStructure => "ZSceneScaffold";
        public static string WIPName => "ZWIP";

        // Name Validation
        public static string[] ReservedNames = { PieceStructure, PointStructure, SetStructure, WIPName };
        public static string[] InvalidNames = { "", " ", "Piece Name", "Set Name", "Scene Name" };
        public static Regex PermittedName = new Regex(@"^[A-Za-z0-9]+$");

        // Characters
        public static char[] Comma = new char[] { ',' };
        public static char[] Colon = new char[] { ':' };
        public static char[] Semi = new char[] { ';' };

        // UI Precision
        public static int[] Ranges = new int[] { 0, 3, 5, 7, 9 };
        public static int ClickPrecision = 5;

        // File Extensions
        public static string Txt => ".txt";
    }
}
