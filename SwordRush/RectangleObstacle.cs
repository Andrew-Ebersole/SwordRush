using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SwordRush
{
    public class RectangleObstacle
    {
        public Rectangle Rectangle { get; set; }

        public RectangleObstacle(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

        public bool Contains(Point point)
        {
            return Rectangle.Contains(point);
        }
    }
}
