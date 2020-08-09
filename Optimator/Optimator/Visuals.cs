using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Optimator
{
    /// <summary>
    /// Custom functions for drawing. Replaces use of System.Drawing.Drawing2D
    /// </summary>
    public class Visuals
    {
        // ----- DRAWING -----

        /// <summary>
        /// Draws a + at the given coordinate
        /// </summary>
        /// <param name="xcood">X coordinate of + centre</param>
        /// <param name="ycood">Y coordinate of + centre</param>
        /// <param name="colour">Colour of the +</param>
        /// <param name="board">The graphics board to be drawn on</param>
        public static void DrawCross(float xcood, float ycood, Color colour, Graphics board)
        {
            var x = (int)xcood;
            var y = (int)ycood;
            var pen = new Pen(colour);
            board.DrawLine(pen, new Point(x - 2, y), new Point(x + 2, y));
            board.DrawLine(pen, new Point(x, y - 2), new Point(x, y + 2));
        }

        /// <summary>
        /// Draws a x at the given coordinate
        /// </summary>
        /// <param name="xcood">X coordinate of x centre</param>
        /// <param name="ycood">Y coordinate of x centre</param>
        /// <param name="colour">Colour of the x</param>
        /// <param name="board">The graphics board to be drawn on</param>
        public static void DrawX(float xcood, float ycood, Color colour, Graphics board)
        {
            var x = (int)xcood;
            var y = (int)ycood;
            var pen = new Pen(colour);
            board.DrawLine(pen, new Point(x - 2, y - 2), new Point(x + 2, y + 2));
            board.DrawLine(pen, new Point(x + 2, y - 2), new Point(x - 2, y + 2));
        }

        /// <summary>
        /// Draws a piece with outline and fill
        /// </summary>
        /// <param name="piece">The piece to be drawn</param>
        /// <param name="g">The graphics to draw to</param>
        public static void DrawPiece(Piece piece, Graphics g, State state, ColourState colourState = null)
        {
            var currentPoints = piece.GetPoints(state);
            if (currentPoints.Count < 1)
            {
                return;
            }

            // Prepare for Drawing
            if (colourState == null)
            {
                colourState = piece.ColourState;
            }
            var pen = new Pen(colourState.OutlineColour, (float)piece.OutlineWidth);
            // GRADIENT
            var fill = new SolidBrush(colourState.FillColour[0]);
            var numCoords = currentPoints.Count;

            // Fill Shape
            var path = new GraphicsPath();
            for (var pointIndex = 0; pointIndex < numCoords && numCoords > 2; pointIndex++)
            {
                // Draw Line Between Final Point and First Point
                if (pointIndex == numCoords - 1)
                {
                    path.AddLine(new Point(Convert.ToInt32(currentPoints[numCoords - 1].X), Convert.ToInt32(currentPoints[numCoords - 1].Y)),
                        new Point(Convert.ToInt32(currentPoints[0].X), Convert.ToInt32(currentPoints[0].Y)));
                }

                // Draw Remaining Lines
                else
                {
                    path.AddLine(new Point(Convert.ToInt32(currentPoints[pointIndex].X), Convert.ToInt32(currentPoints[pointIndex].Y)),
                            new Point(Convert.ToInt32(currentPoints[pointIndex + 1].X), Convert.ToInt32(currentPoints[pointIndex + 1].Y)));
                }
            }
            g.FillPath(fill, path);

            // Draw Outline
            for (var pointIndex = 0; pointIndex < numCoords && numCoords > 1 && piece.OutlineWidth > 0; pointIndex++)
            {
                if (currentPoints[pointIndex].Connector != Consts.connectorOptions[1])
                {
                    Point start; Point end;
                    // Draw Line Between Final Point and First Point
                    if (pointIndex == numCoords - 1)
                    {
                        start = new Point(Convert.ToInt32(currentPoints[0].X), Convert.ToInt32(currentPoints[0].Y));
                        end = new Point(Convert.ToInt32(currentPoints[numCoords - 1].X), Convert.ToInt32(currentPoints[numCoords - 1].Y));
                    }
                    // Draw Remaining Lines
                    else
                    {
                        start = new Point(Convert.ToInt32(currentPoints[pointIndex].X), Convert.ToInt32(currentPoints[pointIndex].Y));
                        end = new Point(Convert.ToInt32(currentPoints[pointIndex + 1].X), Convert.ToInt32(currentPoints[pointIndex + 1].Y));
                    }

                    // Connected by Line
                    if (currentPoints[pointIndex].Connector == Consts.connectorOptions[0])
                    {
                        g.DrawLine(pen, start, end);
                    }
                    // Connected by Curve
                    else
                    {
                        // CURVE
                    }
                }
            }
        }

        /// <summary>
        /// Draws all parts in a list.
        /// </summary>
        /// <param name="partsList">Parts to be drawn</param>
        /// <param name="g">Graphics to draw</param>
        public static void DrawParts(List<Part> partsList, Graphics g)
        {
            foreach (var part in partsList)
            {
                part.Draw(g);
            }
        }



        // ----- VISUAL MANIPULATION -----

        /// <summary>
        /// Resize a bitmap.
        /// </summary>
        /// <param name="newWidth">Width of resized bitmap</param>
        /// <param name="newHeight">Height of resized bitmap</param>
        /// <param name="original">Original bitmap</param>
        /// <param name="bg">The colour to fill excess space</param>
        /// <returns>Re-scaled Bitmap</returns>
        public static Bitmap ScaleBitmap(int newWidth, int newHeight, Bitmap original, Color bg)
        {
            var brush = new SolidBrush(bg);

            float scale = Math.Min((float)newWidth / original.Width, (float)newHeight / original.Height);
            var newBitmap = new Bitmap(newWidth, newHeight);
            var g = Graphics.FromImage(newBitmap);

            // uncomment for higher quality output
            //g.InterpolationMode = InterpolationMode.High;
            //g.CompositingQuality = CompositingQuality.HighQuality;
            //g.SmoothingMode = SmoothingMode.AntiAlias;

            var scaleWidth = (int)(original.Width * scale);
            var scaleHeight = (int)(original.Height * scale);

            using (g)
            {
                g.FillRectangle(brush, new RectangleF(0, 0, newWidth, newHeight));
                g.DrawImage(original, (newWidth - scaleWidth) / 2, (newHeight - scaleHeight) / 2, scaleWidth, scaleHeight);
            }
            return newBitmap;
        }
    }
}
