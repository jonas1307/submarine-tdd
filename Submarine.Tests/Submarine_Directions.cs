using Xunit;

namespace Submarine.Tests
{
    public class Submarine_Directions
    {
        [Theory]
        [InlineData("R", "0 0 0 EAST")]
        [InlineData("RR", "0 0 0 SOUTH")]
        [InlineData("RRR", "0 0 0 WEST")]
        [InlineData("RRRR", "0 0 0 NORTH")]
        public void Submarine_Directions_CanTurnClockwise(string command, string expected)
        {
            using (var submarine = new Submarine())
            {
                var output = submarine.Operate(command);

                Assert.Equal(expected, output);
            }
        }

        [Theory]
        [InlineData("L", "0 0 0 WEST")]
        [InlineData("LL", "0 0 0 SOUTH")]
        [InlineData("LLL", "0 0 0 EAST")]
        [InlineData("LLLL", "0 0 0 NORTH")]
        public void Submarine_Directions_CanTurnCounterClockwise(string command, string expected)
        {
            using (var submarine = new Submarine())
            {
                var output = submarine.Operate(command);

                Assert.Equal(expected, output);
            }
        }
    }
}
