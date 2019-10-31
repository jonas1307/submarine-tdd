using Xunit;

namespace Submarine.Tests
{
    public class Submarine_Axis
    {
        [Theory]
        [InlineData("RMMM", "3 0 0 EAST")]
        [InlineData("LMMM", "-3 0 0 WEST")]
        public void Submarine_XAxis_CanMoveAnywhere(string command, string expected)
        {
            using (var submarine = new Submarine())
            {
                var output = submarine.Operate(command);

                Assert.Equal(expected, output);
            }
        }

        [Theory]
        [InlineData("MMM", "0 3 0 NORTH")]
        [InlineData("RRMMM", "0 -3 0 SOUTH")]
        public void Submarine_YAxis_CanMoveAnywhere(string command, string expected)
        {
            using (var submarine = new Submarine())
            {
                var output = submarine.Operate(command);

                Assert.Equal(expected, output);
            }
        }

        [Theory]
        [InlineData("U", "0 0 0 NORTH")]
        [InlineData("UDU", "0 0 0 NORTH")]
        public void Submarine_ZAxis_CantMoveOverZero(string command, string expected)
        {
            using (var submarine = new Submarine())
            {
                var output = submarine.Operate(command);

                Assert.Equal(expected, output);
            }
        }

        [Theory]
        [InlineData("DU", "0 0 0 NORTH")]
        [InlineData("DDU", "0 0 -1 NORTH")]
        public void Submarine_ZAxis_CanMoveBelowZero(string command, string expected)
        {
            using (var submarine = new Submarine())
            {
                var output = submarine.Operate(command);

                Assert.Equal(expected, output);
            }
        }
    }
}
