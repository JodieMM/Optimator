using Optimator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace OptimatorTests
{
    [TestClass]
    public class RandomTriangleRTTests
    {
        private Piece RandomTriangle()
        {
            // Arrange
            Piece piece = new Piece();

            // Act
            piece.Data.Add(new Spot(12, 20, 12, -3));
            piece.Data.Add(new Spot(20, -20, 12, -3));
            piece.Data.Add(new Spot(-20, -3, 12, -3));

            Utils.CentrePieceOnAxis(piece);

            return piece;
        }

        private bool CompareLists(List<double[]> correct, List<double[]> actual)
        {
            // Check same lengths
            if (correct.Count != actual.Count)
            {
                return false;
            }

            // Compare individual spots
            for (int index = 0; index < correct.Count; index++)
            {
                for (int coord = 0; coord < 2; coord++)
                {
                    if (Math.Abs(correct[index][coord] - actual[index][coord]) > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        [TestMethod]
        public void RAT_R0T0()
        {
            State state = new State();
            var correct = new List<double[]>
            {
                new double[] {12, 20},
                new double[] {20, -20},
                new double[] {-20, -3}
            };
            var triangle = RandomTriangle().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }
    }
}
