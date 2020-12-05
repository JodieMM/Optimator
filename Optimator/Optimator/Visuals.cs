using System;
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
            //var pen = new Pen(colourState.Outline, (float)piece.OutlineWidth);
            var fill = colourState.DrawingTools();

            // Draw
            if (currentPoints.Count > 1 && piece.ColourState.IsVisible())
            {
                DrawShape(g, currentPoints, fill);
            }
            DrawOutline(g, currentPoints);
        }

        /// <summary>
        /// Draws the constant colour section of a piece.
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        /// <param name="currentPoints">Shape outline</param>
        /// <param name="fill">Brush to colour the section</param>
        public static void DrawShape(Graphics g, List<Spot> currentPoints, Brush[] fill)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            for (var index = 0; index < currentPoints.Count; index++)
            {
                var nextIndex = Utils.NextIndex(currentPoints, index);
                var start = Utils.ConvertSpotToPoint(currentPoints[index]);
                var end = Utils.ConvertSpotToPoint(currentPoints[nextIndex]);

                // Connected by Line
                if (currentPoints[index].Connector == Consts.SpotOption.Corner &&
                    currentPoints[nextIndex].Connector == Consts.SpotOption.Corner)
                {
                    path.AddLine(start, end);
                }
                // Starts with Curve
                else if (currentPoints[index].Connector == Consts.SpotOption.Curve)
                {
                    var count = 0;
                    var foundNonCurve = false;
                    while (count < currentPoints.Count && !foundNonCurve)
                    {
                        if (currentPoints[count].Connector != Consts.SpotOption.Curve)
                        {
                            foundNonCurve = true;
                        }
                        count++;
                    }
                    // All Curve - ClosedCurve Required
                    if (!foundNonCurve)
                    {
                        var curvePoints = new PointF[currentPoints.Count];
                        for (int currentPoint = 0; currentPoint < currentPoints.Count; currentPoint++)
                        {
                            curvePoints[currentPoint] = Utils.ConvertSpotToPoint(currentPoints[currentPoint]);
                        }
                        path.AddClosedCurve(curvePoints, currentPoints[0].Tension);
                        index = currentPoints.Count;
                    }
                    // Else skip- will be drawn in a curve loop
                }
                // Start of Curve
                else if (currentPoints[index].Connector == Consts.SpotOption.Corner &&
                    currentPoints[nextIndex].Connector == Consts.SpotOption.Curve)
                {
                    var curvePoints = new List<PointF>() { start, end };
                    var newIndex = nextIndex;
                    while (currentPoints[newIndex].Connector == Consts.SpotOption.Curve)
                    {
                        newIndex = Utils.NextIndex(currentPoints, newIndex);
                        curvePoints.Add(Utils.ConvertSpotToPoint(currentPoints[newIndex]));
                    }
                    path.AddCurve(Utils.ConvertPointListToArray(curvePoints), currentPoints[nextIndex].Tension);
                    index = newIndex <= index ? currentPoints.Count : newIndex - 1;                    
                }
            }
            path.CloseFigure();
            foreach (var brush in fill)
            {
                g.FillPath(brush, path);
            }            
        }

        /// <summary>
        /// Draws a shape within the bounds of another shape.
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        /// <param name="currentPoints">Shape outline</param>
        /// <param name="fill">Brush to colour the section</param>
        /// <param name="onto">Piece to use for bounds</param>
        public static void DrawDecal(Graphics g, List<Spot> currentPoints, Brush fill, Piece onto)
        {
            // TODO: Decals
        }

        /// <summary>
        /// Draws the outline of the piece.
        /// </summary>
        /// <param name="piece">Piece holding spot coordinates to draw</param>
        /// <param name="connected">False if shape is a line</param>
        public static void DrawOutline(Graphics g, List<Spot> currentPoints, bool connected = true)
        {
            // Draw Outline
            var maxIndex = connected ? currentPoints.Count : currentPoints.Count - 1;
            for (var index = 0; index < maxIndex; index++)
            {
                var nextIndex = Utils.NextIndex(currentPoints, index);
                var start = Utils.ConvertSpotToPoint(currentPoints[index]);
                var end = Utils.ConvertSpotToPoint(currentPoints[nextIndex]);
                var pen = new Pen(currentPoints[index].Line.Colour[0], currentPoints[index].Line.Width[0]);
                // TODO: GRADIENT LINE COLOUR AND WIDTH ^^

                // Line is Visible
                if (currentPoints[index].Line.IsVisible())
                {
                    // Connected by Line
                    if (currentPoints[index].Connector == Consts.SpotOption.Corner &&
                        currentPoints[nextIndex].Connector == Consts.SpotOption.Corner)
                    {
                        g.DrawLine(pen, start, end);
                    }
                    // Starts with Curve
                    else if (currentPoints[index].Connector == Consts.SpotOption.Curve)
                    {
                        var count = 0;
                        var foundNonCurve = false;
                        while (count < currentPoints.Count && !foundNonCurve)
                        {
                            if (currentPoints[count].Connector != Consts.SpotOption.Curve)
                            {
                                foundNonCurve = true;
                            }
                            count++;
                        }
                        // All Curve - ClosedCurve Required
                        if (!foundNonCurve)
                        {
                            var curvePoints = new PointF[currentPoints.Count];
                            for (int currentPoint = 0; currentPoint < currentPoints.Count; currentPoint++)
                            {
                                curvePoints[currentPoint] = Utils.ConvertSpotToPoint(currentPoints[currentPoint]);
                            }
                            g.DrawClosedCurve(pen, curvePoints, currentPoints[0].Tension, FillMode.Alternate);
                            index = maxIndex;
                        }
                        // Else skip- will be drawn in a curve loop
                    }
                    // Start of Curve
                    else if (currentPoints[index].Connector == Consts.SpotOption.Corner &&
                        currentPoints[nextIndex].Connector == Consts.SpotOption.Curve)
                    {
                        var curvePoints = new List<PointF>() { start, end };
                        var newIndex = nextIndex;
                        while (currentPoints[newIndex].Connector == Consts.SpotOption.Curve)
                        {
                            newIndex = Utils.NextIndex(currentPoints, newIndex);
                            curvePoints.Add(Utils.ConvertSpotToPoint(currentPoints[newIndex]));
                        }
                        index = newIndex <= index ? maxIndex : newIndex - 1;
                        g.DrawCurve(pen, Utils.ConvertPointListToArray(curvePoints), currentPoints[nextIndex].Tension);
                    }

                    // Smooth Corner
                    g.FillEllipse(new SolidBrush(pen.Color), end.X - (pen.Width / 2), end.Y - (pen.Width / 2), pen.Width, pen.Width);
                }
            }
            // Smooth Start for Lines
            if (!connected && currentPoints[0].Line.Visible)
            {
                var penWidth = currentPoints[0].Line.Width[0];
                g.FillEllipse(new SolidBrush(currentPoints[0].Line.Colour[0]), currentPoints[0].X - (penWidth / 2), 
                    currentPoints[0].Y - (penWidth / 2), penWidth, penWidth);
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
