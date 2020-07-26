﻿namespace Optimator
{
    /// <summary>
    /// A class to hold animations changes.
    /// 
    /// Author Jodie Muller
    /// </summary>
    public class Change
    {
        #region Changes Variables
        public Piece AffectedPiece { get; set; }
        public readonly Scene host;

        public decimal StartTime { get; set; }
        public float HowMuch { get; set; }
        public decimal HowLong { get; set; }
        public string Action { get; set; }
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
        public Change(decimal startTime, string action, Piece affectedPiece, float howMuch, decimal howLong, Scene owner)
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
            var increment = ((time - StartTime) >= HowLong) ? HowMuch : (float)((time - StartTime) / HowLong) * HowMuch;

            // Update Parts
            var affectedState = host.GetPieceState(AffectedPiece);

            switch (Action)
            {
                case "X":
                    affectedState.X += increment;
                    break;
                case "Y":
                    affectedState.Y -= increment;
                    break;
                case "Rotation":
                    affectedState.R = (affectedState.R + increment) % 360;
                    break;
                case "Turn":
                    affectedState.T = (affectedState.T + increment) % 360;
                    break;
                case "Spin":
                    affectedState.S = (affectedState.S + increment) % 360;
                    break;
                case "Size":
                    affectedState.SM += increment / 100;
                    break;
            }
        }

        /// <summary>
        /// Converts the change into a saveable string format.
        /// </summary>
        /// <returns>Change in string form</returns>
        public override string ToString()
        {
            return StartTime + Consts.ColonS + Action + Consts.ColonS + host.PiecesList.IndexOf(AffectedPiece) 
                + Consts.ColonS + HowMuch.ToString() + Consts.ColonS + HowLong;
        }

        /// <summary>
        /// Finds the index of the action text.
        /// </summary>
        /// <returns></returns>
        public int ActionIndex()
        {
            for (int index = 0; index < Consts.possibleChanges.Length; index++)
            {
                if (Action == (string)Consts.possibleChanges[index])
                {
                    return index;
                }
            }
            return -1; //Error
        }
    }
}
