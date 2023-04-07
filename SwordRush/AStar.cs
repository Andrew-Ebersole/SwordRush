using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace SwordRush
{
    internal class Astar
    {
        //the grid of the 
        List<List<AStarNode>> Grid;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="grid">the grid</param>
        public Astar(List<List<AStarNode>> grid)
        {
            Grid = grid;
        }

        /// <summary>
        /// pass in the start and end point
        /// </summary>
        /// <param name="Start">the position of the enemy</param>
        /// <param name="End">the position of the player</param>
        /// <returns>the path</returns>
        public Stack<AStarNode> FindPath(Vector2 Start, Vector2 End)
        {
            AStarNode start = new AStarNode(new Vector2((int)(Start.X), (int)(Start.Y)), true);
            AStarNode end = new AStarNode(new Vector2((int)(End.X), (int)(End.Y)), true);

            Stack<AStarNode> Path = new Stack<AStarNode>();
            PriorityQueue<AStarNode, float> OpenList = new PriorityQueue<AStarNode, float>();
            List<AStarNode> ClosedList = new List<AStarNode>();
            List<AStarNode> adjacencies;
            AStarNode current = start;

            // add start AStarNode to Open List
            OpenList.Enqueue(start, start.F);

            while (OpenList.Count != 0 && !ClosedList.Exists(x => x.Position == end.Position))
            {
                current = OpenList.Dequeue();
                ClosedList.Add(current);
                adjacencies = GetAdjacentNodes(current);

                foreach (AStarNode n in adjacencies)
                {
                    if (!ClosedList.Contains(n) && n.Walkable)
                    {
                        bool isFound = false;
                        foreach (var oLNode in OpenList.UnorderedItems)
                        {
                            if (oLNode.Element == n)
                            {
                                isFound = true;
                            }
                        }
                        if (!isFound)
                        {
                            n.Parent = current;
                            n.DistanceToTarget = Math.Abs(n.Position.X - end.Position.X) + Math.Abs(n.Position.Y - end.Position.Y);
                            n.Cost = n.Weight + n.Parent.Cost;
                            OpenList.Enqueue(n, n.F);
                        }
                    }
                }
            }

            //if enemy couldn't get to player, this should never happen
            if (!ClosedList.Exists(x => x.Position == end.Position))
            {
                return null;
            }


            //return the path
            AStarNode temp = ClosedList[ClosedList.IndexOf(current)];

            if (temp == null) return null;
            do
            {
                Path.Push(temp);
                temp = temp.Parent;
            } while (temp != start && temp != null);

            return Path;
        }


        private List<AStarNode> GetAdjacentNodes(AStarNode n)
        {
            List<AStarNode> temp = new List<AStarNode>();

            int row = (int)n.Position.Y / 32;
            int col = (int)n.Position.X / 32;

            if (row + 1 < Grid[0].Count)
            {
                temp.Add(Grid[col][row + 1]);
            }
            if (row - 1 >= 0)
            {
                temp.Add(Grid[col][row - 1]);
            }
            if (col - 1 >= 0)
            {
                temp.Add(Grid[col - 1][row]);
            }
            if (col + 1 < Grid.Count)
            {
                temp.Add(Grid[col + 1][row]);
            }

            return temp;
        }
    }
}
