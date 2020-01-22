using Optimator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            piece.Data.Add(new Spot(10, 10));
            piece.Data.Add(new Spot(10, 10));
            piece.Data.Add(new Spot(10, 10));

            return piece;
        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
