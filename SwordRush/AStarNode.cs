using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SwordRush
{
    internal class AStarNode
    {
        public Point Position { get; set; }
        public AStarNode Parent { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F { get; set; }
        public List<AStarNode> Neighbors { get; set; }

        public AStarNode(Point position)
        {
            Position = position;
            G = 0;
            H = 0;
            Parent = null;
        }

        public float CalculateH(AStarNode goal)
        {
            return Vector2.Distance(Position.ToVector2(), goal.Position.ToVector2());
        }


    }
}
