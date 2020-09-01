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
        // File Extensions
        public const string PieceExt = ".optrp";
        public const string SetExt = ".optrs";
        public const string SceneExt = ".optrc";
        public const string VideoExt = ".optrv";
        public const string Png = ".png";
        public const string Mp4 = ".mp4";
        public const string Avi = ".avi";
        public const string Gif = ".gif";

        // File Filters
        public const string PieceFilter = "Piece Files (*" + PieceExt + ")|*" + PieceExt;
        public const string SetFilter = "Set Files (*" + SetExt + ")|*" + SetExt;
        public const string SceneFilter = "Scene Files (*" + SceneExt + ")|*" + SceneExt;
        public const string VideoFilter = "Video Files (*" + VideoExt + ")|*" + VideoExt;
        public const string AviFilter = "Avi File (*" + Avi + ")|*" + Avi;
        public const string PartFilter = "Part Files (*" + PieceExt + ";*" + SetExt + ")|*" + PieceExt + ";*" + SetExt;
        public const string OptiFilter = "Optimator Files (*" + PieceExt + ";*" + SetExt + ";*" + SceneExt + ";*" + VideoExt +
            ")|*" + PieceExt + ";*" + SetExt + ";*" + SceneExt + ";*" + VideoExt;

        // Characters
        public static char[] Comma = new char[] { ',' };
        public static char[] Colon = new char[] { ':' };
        public static char[] Semi = new char[] { ';' };
        public static char[] Stop = new char[] { '.' };
        public const string CommaS = ",";
        public const string ColonS = ":";
        public const string SemiS = ";";

        // UI
        public static Font headingLblFont = new Font("Segoe UI", 20F, FontStyle.Bold);
        public static Font subLblFont = new Font("Segoe UI", 18F, FontStyle.Italic);
        public static Font contentFont = new Font("Segoe UI", 16F);

        // UI Precision
        public static int[] ClickPrecisions = new int[] { 0, 3, 5, 7, 9 };
        public const int DragPrecision = 5;
        public const int CentreBox = 150;

        // Piece Defaults
        public static Color defaultFill = Color.FromArgb(255, 204, 240, 255);
        public static Color defaultOutline = Color.FromArgb(255, 204, 204, 255);
        public const decimal defaultOutlineWidth = 2;

        // Piece Options
        public enum ConnectorOption
        {
            None,
            Line,            
            Curve
        }
        public enum FillOption
        {
            None,
            Fill,
            Gradient
        }
        public enum PieceOption
        {
            Piece,
            Flat,
            Line,
            FlatLine,
            Decal
        }

        // Colours
        public static Color shadowShade = Color.DarkGray;
        public static Color invisible = Color.FromArgb(0, 0, 0, 0);
        public static Color highlight = Color.ForestGreen;
        public static Color select = Color.Red;
        public static Color lowlight = Color.CadetBlue;
        public static Color option1 = Color.SaddleBrown;
        public static Color option2 = Color.Purple;
        public static Color activeAnimation = Color.FromArgb(255, 153, 204, 255);
        public static Color finishedAnimation = Color.FromArgb(255, 77, 166, 255);
        public static Color toDoAnimation = Color.FromArgb(255, 204, 230, 255);

        // Maximum Values
        public static float MaximumSize = 1000;
        public static float MaximumXY = 6000;

        // Scene Options
        public enum Action
        {
            None,
            X,
            Y,
            Rotation,
            Turn,
            Spin,
            Size
        }
    }
}
