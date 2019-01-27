using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Animator
{
    /// <summary>
    /// Custom functions for drawing. Replaces use of System.Drawing.Drawing2D
    /// </summary>
    public class Visuals
    {
        /// <summary>
        /// Clears the drawing board and prepares it for new visuals.
        /// </summary>
        /// <param name="g">Board graphics</param>
        /// <param name="DrawPanel">Panel to draw on</param>
        public static void ResetPictureBox(Graphics g, PictureBox DrawPanel)
        {
            DrawPanel.Refresh();
            g = DrawPanel.CreateGraphics();
        }

        /// <summary>
        /// Draws a + at the given coordinate
        /// </summary>
        /// <param name="xcood">X coordinate of + centre</param>
        /// <param name="ycood">Y coordinate of + centre</param>
        /// <param name="colour">Colour of the +</param>
        /// <param name="board">The graphics board to be drawn on</param>
        public static void DrawCross(double xcood, double ycood, Color colour, Graphics board)
        {
            int x = (int)xcood;
            int y = (int)ycood;
            Pen pen = new Pen(colour);
            board.DrawLine(pen, new Point(x - 2, y), new Point(x + 2, y));
            board.DrawLine(pen, new Point(x, y - 2), new Point(x, y + 2));
        }

        /// <summary>
        /// Draws a piece with outline and fill
        /// </summary>
        /// <param name="piece">The piece to be drawn</param>
        /// <param name="g">The graphics to draw to</param>
        public static void DrawPiece(Piece piece, Graphics g)
        {
            // Check piece defined at that point
            int dataRow = piece.FindRow();
            if (dataRow != -1)
            {
                // Prepare for drawing
                Pen pen = new Pen(piece.OutlineColour, (float)piece.OutlineWidth);
                SolidBrush fill = new SolidBrush(piece.FillColour[0]);
                List<double[]> sketchCoords = piece.GetCurrentPoints();
                List<Spot> connectors = piece.Data[dataRow].Spots;
                int numCoords = sketchCoords.Count;

                // Fill Shape
                GraphicsPath path = new GraphicsPath();
                for (int pointIndex = 0; pointIndex < numCoords && numCoords > 2; pointIndex++)
                {
                    // Draw Line Between Final Point and First Point
                    if (pointIndex == numCoords - 1)
                    {
                        path.AddLine(new Point(Convert.ToInt32(sketchCoords[numCoords - 1][0]), Convert.ToInt32(sketchCoords[numCoords - 1][1])),
                            new Point(Convert.ToInt32(sketchCoords[0][0]), Convert.ToInt32(sketchCoords[0][1])));
                    }
                    // Draw Remaining Lines
                    else
                    {
                        path.AddLine(new Point(Convert.ToInt32(sketchCoords[pointIndex][0]), Convert.ToInt32(sketchCoords[pointIndex][1])),
                             new Point(Convert.ToInt32(sketchCoords[pointIndex + 1][0]), Convert.ToInt32(sketchCoords[pointIndex + 1][1])));
                    }
                }
                g.FillPath(fill, path);

                // Draw Connecting Lines
                for (int pointIndex = 0; pointIndex < numCoords && numCoords > 1 && piece.OutlineWidth > 0; pointIndex++)
                {
                    if (connectors[pointIndex].Connector != Constants.connectorOptions[1])
                    {
                        Point start; Point end;
                        // Draw Line Between Final Point and First Point
                        if (pointIndex == numCoords - 1)
                        {
                            start = new Point(Convert.ToInt32(sketchCoords[0][0]), Convert.ToInt32(sketchCoords[0][1]));
                            end = new Point(Convert.ToInt32(sketchCoords[numCoords - 1][0]), Convert.ToInt32(sketchCoords[numCoords - 1][1]));
                        }
                        // Draw Remaining Lines
                        else
                        {
                            start = new Point(Convert.ToInt32(sketchCoords[pointIndex][0]), Convert.ToInt32(sketchCoords[pointIndex][1]));
                            end = new Point(Convert.ToInt32(sketchCoords[pointIndex + 1][0]), Convert.ToInt32(sketchCoords[pointIndex + 1][1]));
                        }

                        // Connected by Line
                        if (connectors[pointIndex].Connector == Constants.connectorOptions[0])
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
        }

        /// <summary>
        /// Draws all parts in a list.
        /// </summary>
        /// <param name="partsList">Parts to be drawn</param>
        /// <param name="g">Graphics to draw</param>
        public static void DrawParts(List<Part> partsList, Graphics g)
        {
            foreach (Part part in partsList)
            {
                part.Draw(g);
            }
        }

        /// <summary>
        /// Draws all pieces in a list, including setting
        /// the graphics and clearing the draw panel.
        /// Also sets a scale on the image.
        /// </summary>
        /// <param name="DrawPanel">Panel to be drawn on</param>
        /// <param name="partsList">Pieces to be drawn</param>
        /// <param name="g">Graphics to draw</param>
        /// <param name="scale">Size modifier to entire image</param>
        public static void DrawPartsScaled(List<Part> partsList, Graphics g, PictureBox DrawPanel, float scale)
        {
            g.ScaleTransform(scale, scale);
            ResetPictureBox(g, DrawPanel);
            DrawParts(partsList, g);
        }
    }
}
