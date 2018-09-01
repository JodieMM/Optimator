using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animator
{

    /// <summary>
    /// A class to hold animations changes.
    /// 
    /// Author Jodie Muller
    /// </summary>


    public class Changes
    {
        // Initialise Variables
        private int startFrame;
        private string action;
        private Piece affectedPiece;
        private double howMuch;
        private int howLong;
        private string options = null;



        /// <summary>
        /// Generates a Changes instance
        /// </summary>
        /// <param name="startFrame">The frame the change start to take effect</param>
        /// <param name="action">What field of the piece will be modified</param>
        /// <param name="affectedPiece">The piece to be changed</param>
        /// <param name="howMuch">How much the change should occur per </param>
        /// <param name="howLong">How many frames the change should continue for</param>

        public Changes(int startFrame, string action, Piece affectedPiece, double howMuch, int howLong)
        {
            this.startFrame = startFrame;
            this.action = action;
            this.affectedPiece = affectedPiece;
            this.howMuch = howMuch;
            this.howLong = howLong;
        }

        /// <summary>
        /// Generates a Changes instance with special options
        /// </summary>
        /// <param name="startFrame">The frame the change start to take effect</param>
        /// <param name="action">What field of the piece will be modified</param>
        /// <param name="affectedPiece">The piece to be changed</param>
        /// <param name="howMuch">How much the change should occur per </param>
        /// <param name="howLong">How many frames the change should continue for</param>
        /// <param name="options">Any additional notes for implementation</param>

        public Changes(int startFrame, string action, Piece affectedPiece, double howMuch, int howLong, string options)
        {
            this.startFrame = startFrame;
            this.action = action;
            this.affectedPiece = affectedPiece;
            this.howMuch = howMuch;
            this.howLong = howLong;
            this.options = options;
        }

        // Get Functions

        public int GetStartFrame()
        {
            return startFrame;
        }

        public string GetAction()
        {
            return action;
        }

        public Piece GetPiece()
        {
            return affectedPiece;
        }

        public double GetHowMuch()
        {
            return howMuch;
        }

        public int GetHowLong()
        {
            return howLong;
        }

        // General Function

        public void Run(Boolean forward)
        {
            // Allow for subtraction/ going back in time
            int multiplier;
            if (forward)
            {
                multiplier = 1;
            }
            else
            {
                multiplier = -1;
            }

            // Update Parts
            if (action == "X")
            {
                affectedPiece.SetX(affectedPiece.GetCoords()[0] + multiplier * howMuch);
            }
            else if (action == "Y")
            {
                affectedPiece.SetY(affectedPiece.GetCoords()[1] + multiplier * howMuch);
            }
            else if (action == "Rotation")
            {
                affectedPiece.SetRotation((int)affectedPiece.GetAngles()[0] + multiplier * howMuch);
            }
            else if (action == "Turn")
            {
                affectedPiece.SetTurn((int)affectedPiece.GetAngles()[1] + multiplier * howMuch);
            }
            else if (action == "Spin")
            {
                affectedPiece.SetSpin((int)affectedPiece.GetAngles()[2] + multiplier * howMuch);
            }
            else if (action == "Size")
            {
                affectedPiece.SetSizeMod(affectedPiece.GetSizeMod() + multiplier * howMuch);
            }
        }
    }
}
