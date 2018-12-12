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
        public Change(decimal startTime, string action, Piece affectedPiece, double howMuch, decimal howLong, Scene owner)
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
        public Change(decimal startTime, string action, Piece affectedPiece, double howMuch, decimal howLong, string options, Scene owner)
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
        /// <param name="time">Current time of the scene</param>
        public void Run(decimal time)
        {
            if (time <= StartTime) { return; }

            // Allow for subtraction/ going back in time
            double increment;
            if ((time - StartTime) >= HowLong)
            {
                increment = HowMuch;
            }
            else
            {
                increment = (double)((time - StartTime) / HowLong) * HowMuch;
            }

            // Update Parts
            switch (Action)
            {
                case "X":
                    AffectedPiece.X += increment;
                    break;
                case "Y":
                    AffectedPiece.Y += increment;
                    break;
                case "Rotation":
                    AffectedPiece.SetRotation(AffectedPiece.R + increment);
                    break;
                case "Turn":
                    AffectedPiece.SetTurn(AffectedPiece.T + increment);
                    break;
                case "Spin":
                    AffectedPiece.SetSpin(AffectedPiece.S + increment);
                    break;
                case "Size":
                    AffectedPiece.SM += increment;
                    break;
            }
        }
    }
}
