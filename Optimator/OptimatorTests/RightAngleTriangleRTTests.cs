using System.Collections.Generic;
using Optimator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OptimatorTests
{
    [TestClass]
    public class RightAngleTriangleRTTests
    {
        private Piece RightAngledTriangleShapeTest()
        {
            // Arrange
            Piece piece = new Piece();

            // Act
            piece.Data.Add(new Spot(100, 100, 100, 50));
            piece.Data.Add(new Spot(150, 50, 100, 50));
            piece.Data.Add(new Spot(100, 50));

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
                new double[] {-25, 25},
                new double[] {25, -25},
                new double[] {-25, -25}
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R90T0()
        {
            State state = new State(new State(), 1, 90);
            var correct = new List<double[]>
            {
                new double[] {0, 25},
                new double[] {0, -25},
                new double[] {0, -25}
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R0T90()
        {
            State state = new State(new State(), 2, 90);
            var correct = new List<double[]>
            {
                new double[] {-25, 0},
                new double[] {25, 0},
                new double[] {-25, 0}
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R90T90()
        {
            State state = new State(new State(), 3, 90, 90);
            var correct = new List<double[]>
            {
                new double[] {0, 0},
                new double[] {0, 0},
                new double[] {0, 0}
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R45T0()
        {
            State state = new State(new State(), 1, 45);
            var correct = new List<double[]>
            {
                new double[] {-12.5, 25},
                new double[] { 12.5, -25},
                new double[] {-12.5, -25}
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R0T45()
        {
            State state = new State(new State(), 2, 45);
            var correct = new List<double[]>
            {
                new double[] {-25, 12.5},
                new double[] {25, -12.5},
                new double[] {-25, -12.5 }
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R45T45()
        {
            State state = new State(new State(), 3, 45, 45);
            var correct = new List<double[]>
            {
                new double[] {-12.5, 12.5},
                new double[] { 12.5, -12.5},
                new double[] {-12.5, -12.5 }
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R180T0()
        {
            State state = new State(new State(), 1, 180);
            var correct = new List<double[]>
            {
                new double[] {25, 25},
                new double[] {25, -25},
                new double[] {-25, -25}
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R180T90()
        {
            State state = new State(new State(), 3, 180, 90);
            var correct = new List<double[]>
            {
                new double[] {25, 0},
                new double[] {25, 0},
                new double[] {-25, 0}
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }

        [TestMethod]
        public void RAT_R315T45()
        {
            State state = new State(new State(), 3, 315, 45);
            var correct = new List<double[]>
            {
                new double[] {-12.5, 12.5},
                new double[] {12.5, -12.5},
                new double[] {-12.5, -12.5}
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }
    }
}
