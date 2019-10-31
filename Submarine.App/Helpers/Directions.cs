using Submarine.Entities;
using System.Collections.Generic;

namespace Submarine.Helpers
{
    public static class Directions
    {
        public static int MinId { get { return 1; } }

        public static int MaxId { get { return 4; } }

        public static IEnumerable<CardinalDirection> All()
        {
            return new List<CardinalDirection>
            {
                new CardinalDirection { Name = "NORTH", Axis = 'Y', Factor = 1, Id = 1 },
                new CardinalDirection { Name = "EAST", Axis = 'X', Factor = 1, Id = 2 },
                new CardinalDirection { Name = "SOUTH", Axis = 'Y', Factor = -1, Id = 3 },
                new CardinalDirection { Name = "WEST", Axis = 'X', Factor = -1, Id = 4 }
            };
        }
    }
}
