using System;
using System.Collections.Generic;

namespace DevelopexTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node { n = 1 };
            root.left = new Node { n = 2 };
            root.right = new Node { n = 3 };
            root.left.left = new Node { n = 4 };
            root.left.right = new Node { n = 5 };
            root.right.left = new Node { n = 6};
            root.right.right = new Node { n = 7};

            LinkSameLevel(root);
        }

        public static void LinkSameLevel(Node t) // t is a root
        {
            var levels = new List<List<Node>>();
            var queue = new Queue<Node>();

            if (t == null)
                return;

            queue.Enqueue(t);

            while (queue.Count > 0)
            {
                // every node that we currently have in queue is level size
                // so exactly that amount of nodes we should dequeue and add them to level list

                var count = queue.Count;
                var level = new List<Node>();

                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    level.Add(node);

                    if (node.left != null)
                        queue.Enqueue(node.left);

                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                levels.Add(level);

                // after this iteration all previous level is dequeued and all new level is enqueued
            }

            // after while loop we recieve list of levels in which nodes sorted from left to right

            foreach (var level in levels)
            {
                var count = level.Count;

                for (int i = 0; i < count - 1; i++)
                {
                    level[i].level = level[i + 1];
                }
            }
        }
    }
}
