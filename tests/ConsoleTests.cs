using System;
using System.Collections.Generic;
using hepsiburada_mars_rover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class TestCases
    {
        [TestMethod]
        public void InputCaseOneTest()
        {
            var moveData = new Mover()
            {
                XCoord = 1,
                YCoord = 2,
                Direction = Directions.North
            };

            var boundaries = new KeyValuePair<int, int>(5, 5);
            var moves = "LMLMLMLMM";

            moveData.Go(boundaries, moves);

            var result = $"{moveData.XCoord} {moveData.YCoord} {moveData.Direction.GetDescription()}";
            var expected = "1 3 N";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InputCaseTwoTest()
        {
            var moveData = new Mover()
            {
                XCoord = 3,
                YCoord = 3,
                Direction = Directions.East
            };

            var maxPoints = new KeyValuePair<int, int>(5, 5);
            var moves = "MRRMMRMRRM";

            moveData.Go(maxPoints, moves);

            var actualOutput = $"{moveData.XCoord} {moveData.YCoord} {moveData.Direction.GetDescription()}";
            var expectedOutput = "2 3 S";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void WrongMoveTest()
        {
            var moveData = new Mover()
            {
                XCoord = 12,
                YCoord = 3,
                Direction = Directions.East
            };

            var maxPoints = new KeyValuePair<int, int>(5, 5);
            var moves = "SDFSDFS";

            Assert.IsFalse(moveData.Go(maxPoints, moves));
        }

        [TestMethod]
        public void InputPatternCheckerTest()
        {
            Assert.IsFalse(Mover.CheckInputPattern("LMLMLMLMM", "[^MLR]"));
            Assert.IsTrue(Mover.CheckInputPattern("LMLRTEMLMLMM", "[^MLR]"));
        }

        [TestMethod]
        public void CreateBoundariesTest()
        {
            Assert.IsInstanceOfType(Mover.CreateBoundaries("5 5"), typeof(KeyValuePair<int, int>));
        }

        [TestMethod]
        public void MoveProcessTest()
        {
            try
            {
                Mover.MoveProcess("1 2 N", new KeyValuePair<int, int>(5, 5), "LMLMLMM");
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}