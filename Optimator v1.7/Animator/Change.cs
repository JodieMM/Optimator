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
        public Piece AffectedPiece { get; }
        private readonly Scene host;

        public decimal StartTime { get; }
        public double HowMuch { get; }
        public decimal HowLong { get; }

        public string Action { get; }
        private readonly string Options = null;
        #endregion


        // ----- CONSTRUCTORS -----

        /// <summary>
        /// Generates a Changes instance
        /// </summary>
        /// <param name="startTime">The frame the change start to take effect</param>
        /// <param name="action">What field of the piece will be modified</param>
        /// <param name="affectedPiece">The piece to be changed</param>
        /// <param name="howMuch">How much the change should occur per </param>
        /// <param name="howLong">How many frames the change should continue for</param>
        public Change(decimal startTime, string action, Piece affectedPiece, double howMuch, int howLong, Scene owner)
        {
            StartTime = startTime;
            Action = action;
            AffectedPiece = affectedPiece;
            HowMuch = howMuch;
            HowLong = howLong;
            host = owner;
        }

        /// <summary>
        /// Generates a Changes instance with special options
        /// </summary>
        /// <param name="startTime">The frame the change start to take effect</param>
        /// <param name="action">What field of the piece will be modified</param>
        /// <param name="affectedPiece">The piece to be changed</param>
        /// <param name="howMuch">How much the change should occur per </param>
        /// <param name="howLong">How many frames the change should continue for</param>
        /// <param name="options">Any additional notes for implementation</param>
        public Change(decimal startTime, string action, Piece affectedPiece, double howMuch, int howLong, string options, Scene owner)
        {
            StartTime = startTime;
            Action = action;
            AffectedPiece = affectedPiece;
            HowMuch = howMuch;
            HowLong = howLong;
            Options = options;
            host = owner;
        }



        // ----- RUN CHANGES -----

        /// <summary>
        /// Applies the change to the affected piece.
        /// </summary>
        /// <param name="forward">Whether the change is being applied or removed</param>
        public void Run(bool forward, decimal time)
        {
            if (time <= StartTime || (time - StartTime) > HowLong) { return; }

            // Allow for subtraction/ going back in time
            int multiplier = (forward) ? 1 : -1;
            double increment = multiplier * (double)(time / (time - StartTime));

            // Update Parts
            switch (Action)
            {
                case "X":
                    AffectedPiece.X = AffectedPiece.GetCoords()[0] + increment * HowMuch;
                    break;
                case "Y":
                    AffectedPiece.Y = AffectedPiece.GetCoords()[1] + increment * HowMuch;
                    break;
                case "Rotation":
                    AffectedPiece.SetRotation((int)AffectedPiece.GetAngles()[0] + increment * HowMuch);
                    break;
                case "Turn":
                    AffectedPiece.SetTurn((int)AffectedPiece.GetAngles()[1] + increment * HowMuch);
                    break;
                case "Spin":
                    AffectedPiece.SetSpin((int)AffectedPiece.GetAngles()[2] + increment * HowMuch);
                    break;
                case "Size":
                    AffectedPiece.SM = AffectedPiece.GetSizeMod() + increment * HowMuch;
                    break;
            }
        }
    }
}
