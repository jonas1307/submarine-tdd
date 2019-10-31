using Xunit;

namespace Submarine.Tests
{
    public class Submarine_Commands
    {
        [Theory]
        [InlineData("DDUDUMMRM", "1 2 -1 EAST")]
        [InlineData("DDDDDMLMM", "-2 1 -5 WEST")]
        public void Submarine_Commands_AcceptsValidCommands(string command, string expected)
        {
            using (var submarine = new Submarine())
            {
                var output = submarine.Operate(command);

                Assert.Equal(expected, output);
            }
        }

        [Theory]
        [InlineData("QDDUDUMMRM", "0 0 0 NORTH")]
        [InlineData("XPTOMMENE4", "0 0 0 NORTH")]
        public void Submarine_Commands_RejectsInvalidCommands(string command, string expected)
        {
            using (var submarine = new Submarine())
            {
                var output = submarine.Operate(command);

                Assert.Equal(expected, output);
            }
        }
    }
}
