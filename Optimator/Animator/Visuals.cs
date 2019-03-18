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
        public static void DrawPiece(Piece piece, Graphics g, Color? outlineColour = null, Color? fillColour = null)
        {
            List<double[]> currentPoints = piece.CurrentPoints();
            if (currentPoints.Count < 1)
                return;

            // Prepare for drawing
            if (outlineColour is null)
                outlineColour = piece.OutlineColour;
            Pen pen = new Pen((Color)outlineColour, (float)piece.OutlineWidth);
            SolidBrush fill = new SolidBrush(fillColour ?? piece.FillColour[0]);
            List<Spot> spots = piece.Data;
            int numCoords = currentPoints.Count;

            // Fill Shape
            GraphicsPath path = new GraphicsPath();
            for (int pointIndex = 0; pointIndex < numCoords && numCoords > 2; pointIndex++)
            {
                // Draw Line Between Final Point and First Point
                if (pointIndex == numCoords - 1)
                    path.AddLine(new Point(Convert.ToInt32(currentPoints[numCoords - 1][0]), Convert.ToInt32(currentPoints[numCoords - 1][1])),
                        new Point(Convert.ToInt32(currentPoints[0][0]), Convert.ToInt32(currentPoints[0][1])));

                // Draw Remaining Lines
                else
                    path.AddLine(new Point(Convert.ToInt32(currentPoints[pointIndex][0]), Convert.ToInt32(currentPoints[pointIndex][1])),
                            new Point(Convert.ToInt32(currentPoints[pointIndex + 1][0]), Convert.ToInt32(currentPoints[pointIndex + 1][1])));
            }
            g.FillPath(fill, path);

            // Draw Outline
            for (int pointIndex = 0; pointIndex < numCoords && numCoords > 1 && piece.OutlineWidth > 0; pointIndex++)
            {
                if (spots[pointIndex].Connector != Consts.connectorOptions[1])
                {
                    Point start; Point end;
                    // Draw Line Between Final Point and First Point
                    if (pointIndex == numCoords - 1)
                    {
                        start = new Point(Convert.ToInt32(currentPoints[0][0]), Convert.ToInt32(currentPoints[0][1]));
                        end = new Point(Convert.ToInt32(currentPoints[numCoords - 1][0]), Convert.ToInt32(currentPoints[numCoords - 1][1]));
                    }
                    // Draw Remaining Lines
                    else
                    {
                        start = new Point(Convert.ToInt32(currentPoints[pointIndex][0]), Convert.ToInt32(currentPoints[pointIndex][1]));
                        end = new Point(Convert.ToInt32(currentPoints[pointIndex + 1][0]), Convert.ToInt32(currentPoints[pointIndex + 1][1]));
                    }

                    // Connected by Line
                    if (spots[pointIndex].Connector == Consts.connectorOptions[0])
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
        /// <param name="drawPanel">If the panel is being reset it is assigned</param>
        public static void DrawParts(List<Part> partsList, Graphics g, PictureBox drawPanel = null)
        {
            if (drawPanel != null)
            {
                drawPanel.Refresh();
                g = drawPanel.CreateGraphics();
            }

            foreach (Part part in partsList)
                part.Draw(g);
        }

        /// <summary>
        /// Draws all pieces in a list, including setting
        /// the graphics and clearing the draw panel.
        /// Also sets a scale on the image.
        /// </summary>
        /// <param name="partsList">Pieces to be drawn</param>
        /// <param name="g">Graphics to draw</param>
        /// <param name="drawPanel">Panel to be drawn on</param>
        /// <param name="scale">Size modifier to entire image</param>
        public static void DrawPartsScaled(List<Part> partsList, Graphics g, PictureBox drawPanel, float scale)
        {
            g.ScaleTransform(scale, scale);
            DrawParts(partsList, g, drawPanel);
        }
    }
}
