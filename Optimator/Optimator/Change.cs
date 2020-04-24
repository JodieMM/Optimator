namespace Optimator
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
        #endregion


        /// <summary>
        /// Generates a Changes instance
        /// </summary>
        /// <param name="startTime">The frame the change start to take effect</param>
        /// <param name="action">What field of the piece will be modified</param>
        /// <param name="affectedPiece">The piece to be changed</param>
        /// <param name="howMuch">How much the change should occur per </param>
        /// <param name="howLong">How many frames the change should continue for</param>
        /// <param name="owner">The scene the change belongs to</param>
        public Change(decimal startTime, string action, Piece affectedPiece, double howMuch, decimal howLong, Scene owner)
        {
            StartTime = startTime;
            Action = action;
            AffectedPiece = affectedPiece;
            HowMuch = howMuch;
            HowLong = howLong;
            host = owner;
        }


        // ----- FUNCTIONS -----

        /// <summary>
        /// Applies the change to the affected piece.
        /// </summary>
        /// <param name="time">Current time of the scene</param>
        public void Run(decimal time)
        {
            if (time <= StartTime)
            {
                return;
            }

            // Full increment if time passed, partial if in progress
            var increment = ((time - StartTime) >= HowLong) ? HowMuch : (double)((time - StartTime) / HowLong) * HowMuch;

            // Update Parts
            switch (Action)
            {
                case "X":
                    AffectedPiece.State.X += increment;
                    break;
                case "Y":
                    AffectedPiece.State.Y += increment;
                    break;
                case "Rotation":
                    AffectedPiece.State.R = (AffectedPiece.State.R + increment) % 360;
                    break;
                case "Turn":
                    AffectedPiece.State.T = (AffectedPiece.State.T + increment) % 360;
                    break;
                case "Spin":
                    AffectedPiece.State.S = (AffectedPiece.State.S + increment) % 360;
                    break;
                case "Size":
                    AffectedPiece.State.SM += increment;
                    break;
            }
        }

        /// <summary>
        /// Converts the change into a saveable string format.
        /// </summary>
        /// <returns>Change in string form</returns>
        public override string ToString()
        {
            return StartTime + Consts.ColonS + Action + Consts.ColonS + host.PartsList.IndexOf(AffectedPiece) 
                + Consts.ColonS + HowMuch + Consts.ColonS + HowLong;
        }
    }
}
