using System;
using System.Collections.Generic;
using Animator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                    if (correct[index][coord] != actual[index][coord])
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
                new double[] {100, 100},
                new double[] {150, 50},
                new double[] {100, 50}
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
                new double[] {100, 100},
                new double[] {100, 50},
                new double[] {100, 50}
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
                new double[] {100, 50},
                new double[] {150, 50},
                new double[] {100, 50}
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
                new double[] {100, 50},
                new double[] {100, 50},
                new double[] {100, 50}
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
                new double[] {100, 100},
                new double[] {125, 50},
                new double[] {100, 50}
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
                new double[] {100, 75},
                new double[] {150, 50},
                new double[] {100, 50}
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
                new double[] {100, 75},
                new double[] {125, 50},
                new double[] {100, 50}
            };
            var triangle = RightAngledTriangleShapeTest().GetPoints(state);
            Assert.IsTrue(CompareLists(correct, triangle));
        }
    }
}
