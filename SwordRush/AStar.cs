using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SwordRush
{
    public class AStar
    {
        private List<AStarNode> openList;
        private List<AStarNode> closedList;
        private Vector2 gameAreaSize = new Vector2(1280,768);

        public List<Point> FindPath(Point start, Point goal, List<Rectangle> obstacles)
        {
            // Create the start and goal nodes
            AStarNode startNode = new AStarNode(start);
            AStarNode goalNode = new AStarNode(goal);

            // Create the open and closed lists
            List<AStarNode> openList = new List<AStarNode>();
            HashSet<AStarNode> closedList = new HashSet<AStarNode>();

            // Add the start node to the open list
            openList.Add(startNode);

            // Loop until we find the goal or run out of nodes to search
            while (openList.Count > 0)
            {
                // Get the node with the lowest F cost from the open list
                AStarNode currentNode = openList.OrderBy(n => n.F).First();

                // If we've reached the goal, return the path
                if (currentNode == goalNode)
                {
                    return GetPath(currentNode);
                }

                // Move the current node from the open list to the closed list
                openList.Remove(currentNode);
                closedList.Add(currentNode);

                // Get the neighbors of the current node
                List<AStarNode> neighbors = GetNeighbors(currentNode, obstacles);
                
                // Loop through the neighbors
                foreach (AStarNode neighbor in neighbors)
                {
                    // If the neighbor is already in the closed list, skip it
                    if (closedList.Contains(neighbor))
                    {
                        continue;
                    }

                    // Calculate the G cost of the neighbor node
                    int tentativeGCost = currentNode.G + GetDistanceBetween(currentNode.Position, neighbor.Position);

                    // If the neighbor is not in the open list, add it
                    
                    if (!openList.Contains(neighbor))
                    {
                        openList.Add(neighbor);
                    }
                    // If the tentative G cost is higher than the neighbor's current G cost, skip it
                    else if (tentativeGCost >= neighbor.G)
                    {
                        continue;
                    }

                    // Update the neighbor node
                    neighbor.Parent = currentNode;
                    neighbor.G = tentativeGCost;
                    neighbor.H = GetDistanceBetween(neighbor.Position, goalNode.Position);
                }
            }

            // If we didn't find a path, return null
            return null;
        }

        private int GetDistanceBetween(Point a, Point b)
        {
            int dx = Math.Abs(a.X - b.X);
            int dy = Math.Abs(a.Y - b.Y);
            return (int)(10 * Math.Sqrt(dx * dx + dy * dy));
        }

        private List<Point> GetPath(AStarNode node)
        {
            List<Point> path = new List<Point>();
            AStarNode current = node;
            while (current != null)
            {
                path.Add(current.Position);
                current = current.Parent;
            }
            path.Reverse();
            return path;
        }

        private readonly List<Vector2> _directions = new List<Vector2>()
        {
            new Vector2(0, -1),     // Up
            new Vector2(0, 1),      // Down
            new Vector2(-1, 0),     // Left
            new Vector2(1, 0),      // Right
            new Vector2(-1, -1),    // Up-left
            new Vector2(1, -1),     // Up-right
            new Vector2(-1, 1),     // Down-left
            new Vector2(1, 1)       // Down-right
        };

        private bool IsPositionValid(Vector2 position, List<Rectangle> obstacles)
        {
            // Check if the position is inside the game area
            if (position.X < 0 || position.X >= gameAreaSize.X ||
                position.Y < 0 || position.Y >= gameAreaSize.Y)
            {
                return false;
            }

            // Check if the position overlaps with any obstacle
            foreach (Rectangle obstacle in obstacles)
            {
                if (obstacle.Contains(position))
                {
                    return false;
                }
            }

            return true;
        }

        private List<AStarNode> GetNeighbors(AStarNode node, List<Rectangle> obstacles)
        {
            List<AStarNode> neighbors = new List<AStarNode>();
            HashSet<Vector2> checkedPositions = new HashSet<Vector2>();

            foreach (Vector2 direction in _directions)
            {
                Vector2 neighborPosition = node.Position.ToVector2() + direction;
                Point neighborPoint = new Point((int)neighborPosition.X, (int)neighborPosition.Y);
                
                if (IsPositionValid(neighborPosition, obstacles) && !checkedPositions.Contains(neighborPosition))
                {
                    AStarNode neighbor = new AStarNode(neighborPoint);
                    neighbor.Parent = node;

                    neighbors.Add(neighbor);
                    checkedPositions.Add(neighborPosition);
                }
            }

            return neighbors;
        }
    }
}
