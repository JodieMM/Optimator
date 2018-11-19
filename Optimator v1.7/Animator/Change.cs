namespace Animator
{
    /// <summary>
    /// A class to hold animations changes.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Change
    {
        #region Changes Variables
        public int StartFrame { get; }
        public string Action { get; }
        public Piece AffectedPiece { get; }
        public double HowMuch { get; }
        public int HowLong { get; }
        private readonly string Options = null;
        #endregion


        // ----- CONSTRUCTORS -----

        /// <summary>
        /// Generates a Changes instance
        /// </summary>
        /// <param name="startFrame">The frame the change start to take effect</param>
        /// <param name="action">What field of the piece will be modified</param>
        /// <param name="affectedPiece">The piece to be changed</param>
        /// <param name="howMuch">How much the change should occur per </param>
        /// <param name="howLong">How many frames the change should continue for</param>
        public Change(int startFrame, string action, Piece affectedPiece, double howMuch, int howLong)
        {
            StartFrame = startFrame;
            Action = action;
            AffectedPiece = affectedPiece;
            HowMuch = howMuch;
            HowLong = howLong;
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
        public Change(int startFrame, string action, Piece affectedPiece, double howMuch, int howLong, string options)
        {
            StartFrame = startFrame;
            Action = action;
            AffectedPiece = affectedPiece;
            HowMuch = howMuch;
            HowLong = howLong;
            Options = options;
        }



        // ----- RUN CHANGES -----

        /// <summary>
        /// Applies the change to the affected piece.
        /// </summary>
        /// <param name="forward">Whether the change is being applied or removed</param>
        public void Run(bool forward)
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
            if (Action == "X")
            {
                AffectedPiece.X = AffectedPiece.GetCoords()[0] + multiplier * HowMuch;
            }
            else if (Action == "Y")
            {
                AffectedPiece.Y = AffectedPiece.GetCoords()[1] + multiplier * HowMuch;
            }
            else if (Action == "Rotation")
            {
                AffectedPiece.SetRotation((int)AffectedPiece.GetAngles()[0] + multiplier * HowMuch);
            }
            else if (Action == "Turn")
            {
                AffectedPiece.SetTurn((int)AffectedPiece.GetAngles()[1] + multiplier * HowMuch);
            }
            else if (Action == "Spin")
            {
                AffectedPiece.SetSpin((int)AffectedPiece.GetAngles()[2] + multiplier * HowMuch);
            }
            else if (Action == "Size")
            {
                AffectedPiece.SM = AffectedPiece.GetSizeMod() + multiplier * HowMuch;
            }
        }
    }
}
