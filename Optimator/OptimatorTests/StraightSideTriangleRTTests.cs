using Optimator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace OptimatorTests
{
    [TestClass]
    public class StraightSideTriangleRTTests
    {
        private Piece RandomTriangle()
        {
            // Arrange
            Piece piece = new Piece();

            // Act
            piece.Data.Add(new Spot(0, 240));
            piece.Data.Add(new Spot(100, 100));
            piece.Data.Add(new Spot(0, 0));

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

            //// Compare individual spots
            //for (int index = 0; index < correct.Count; index++)
            //{
            //    for (int coord = 0; coord < 2; coord++)
            //    {
            //        if (Math.Abs(correct[index][coord] - actual[index][coord]) > 1)
            //        {
            //            return false;
            //        }
            //    }
            //}

            while (correct.Count > 0)
            {
                for (int index = 0; index < correct.Count; index++)
                {
                    if (correct[0][0] == actual[index][0] && correct[0][1] == actual[index][1])
                    {
                        actual.RemoveAt(index);
                        index = 100;
                    }
                }
                if (correct.Count == actual.Count)
                {
                    return false;
                }
                else
                {
                    correct.RemoveAt(0);
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
                new double[] {-50, -20},
                new double[] {-50, 120},
                new double[] {50, -20},
                new double[] {-50, -120}
            };
            var triangle = RandomTriangle().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R180T0()
        {
            State state = new State(new State(), 1, 180);
            var correct = new List<double[]>
            {
                new double[] {50, -20},
                new double[] {50, 120},
                new double[] {-50, -20},
                new double[] {50, -120}
            };
            var triangle = RandomTriangle().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R0T180()
        {
            State state = new State(new State(), 2, 180);
            var correct = new List<double[]>
            {
                new double[] {-50, 20},
                new double[] {-50, -120},
                new double[] {50, 20},
                new double[] {-50, 120}
            };
            var triangle = RandomTriangle().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R180T180()
        {
            State state = new State(new State(), 3, 180, 180);
            var correct = new List<double[]>
            {
                new double[] {50, 20},
                new double[] {50, -120},
                new double[] {-50, 20},
                new double[] {50, 120}
            };
            var triangle = RandomTriangle().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }
    }
}
