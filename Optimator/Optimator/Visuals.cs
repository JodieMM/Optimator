﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

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
            board.SmoothingMode = SmoothingMode.AntiAlias;
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
            board.SmoothingMode = SmoothingMode.AntiAlias;
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
            if (currentPoints.Count < 2)
            {
                return;
            }

            // Prepare for Drawing
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (colourState == null)
            {
                colourState = piece.ColourState;
            }
            var pen = new Pen(colourState.OutlineColour, (float)piece.OutlineWidth);
            var fill = new SolidBrush(colourState.FillColour[0]); // GRADIENT

            // Draw
            if (currentPoints.Count > 1)
            {
                DrawShape(g, currentPoints, fill);
            }
            if (piece.OutlineWidth > 0)
            {
                DrawOutline(g, currentPoints, pen);
            }
        }

        /// <summary>
        /// Draws the constant colour section of a piece.
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        /// <param name="currentPoints">Shape outline</param>
        /// <param name="fill">Brush to colour the section</param>
        public static void DrawShape(Graphics g, List<Spot> currentPoints, Brush fill)
        {
            var path = new GraphicsPath();
            for (var index = 0; index < currentPoints.Count; index++)
            {
                var nextIndex = Utils.NextIndex(currentPoints, index);
                path.AddLine(new Point(Convert.ToInt32(currentPoints[index].X), Convert.ToInt32(currentPoints[index].Y)),
                    new Point(Convert.ToInt32(currentPoints[nextIndex].X), Convert.ToInt32(currentPoints[nextIndex].Y)));
            }
            g.FillPath(fill, path);
        }

        /// <summary>
        /// Draws the outline of the piece.
        /// </summary>
        /// <param name="piece">Piece holding spot coordinates to draw</param>
        /// <param name="connected">False if shape is a line</param>
        public static void DrawOutline(Graphics g, List<Spot> currentPoints, Pen pen, bool connected = true)
        {
            // Draw Outline
            var maxIndex = connected ? currentPoints.Count : currentPoints.Count - 1;
            for (var index = 0; index < maxIndex; index++)
            {
                if (currentPoints[index].Connector != Consts.connectorOptions[1])
                {
                    Point start; Point end;
                    var nextIndex = Utils.NextIndex(currentPoints, index);
                    start = new Point(Convert.ToInt32(currentPoints[index].X), Convert.ToInt32(currentPoints[index].Y));
                    end = new Point(Convert.ToInt32(currentPoints[nextIndex].X), Convert.ToInt32(currentPoints[nextIndex].Y));

                    // Connected by Line
                    if (currentPoints[index].Connector == Consts.connectorOptions[0])
                    {
                        g.DrawLine(pen, start, end);
                    }
                    // Connected by Curve
                    else if (currentPoints[index].Connector == "Curve")
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

            g.InterpolationMode = InterpolationMode.High;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;

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
