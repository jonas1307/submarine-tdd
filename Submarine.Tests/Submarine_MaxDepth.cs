using System;
using Xunit;

namespace Submarine.Tests
{
    public class Submarine_MaxDepth
    {
        [Theory]
        [InlineData("DDDD", null, "0 0 -4 NORTH")]
        [InlineData("DDDD", -3, "0 0 -3 NORTH")]
        public void Submarine_MaxDepth_CantMoveBeyondMaxDepth(string command, int? maxDepth, string expected)
        {
            using (var submarine = new Submarine(maxDepth))
            {
                var output = submarine.Operate(command);

                Assert.Equal(expected, output);
            }
        }

        [Theory]
        [InlineData(-1)]
        public void Submarine_MaxDepth_AcceptsSmallerThanZero(int? maxdepth)
        {
            using (new Submarine(maxdepth))
            { }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Submarine_MaxDepth_RejectsGreaterThanZero(int? maxdepth)
        {
            Assert.Throws<ArgumentOutOfRangeException>("maxdepth", () => new Submarine(maxdepth));
        }
    }
}