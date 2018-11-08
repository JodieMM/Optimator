using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Animator
{
    public static class Constants
    {
        // Constant Values
        public static double MidX = 500;
        public static double MidY = 250;

        // Folders
        public static string PiecesFolder => "\\Pieces\\";
        public static string PointsFolder => "\\Points\\";
        public static string SetsFolder => "\\Sets\\";

        // Reserved Names
        public static string PieceStructure => "ZPieceScaffold";
        public static string PointStructure => "ZPointScaffold";
        public static string SetStructure => "ZSetScaffold";
        public static string WIPName => "ZWIP";

        // Name Validation
        public static string[] ReservedNames = { PieceStructure, PointStructure, SetStructure, WIPName };
        public static string[] InvalidNames = { "", " ", "Piece Name" };
        public static Regex PermittedName = new Regex(@"^[A-Za-z0-9]+$");

        // Characters
        public static char[] Comma = new char[] { ',' };
        public static char[] Colon = new char[] { ':' };
        public static char[] Semi = new char[] { ';' };


        /// <summary>
        /// Takes a folder and item name and returns the directory name to reach that file
        /// </summary>
        /// <param name="folder">The folder the item is in</param>
        /// <param name="name">The item name</param>
        /// <returns></returns>
        public static string GetDirectory(string folder, string name)
        {
            return Environment.CurrentDirectory + folder + name + ".txt";
        }
    }
}
