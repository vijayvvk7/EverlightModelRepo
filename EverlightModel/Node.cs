using System;
using System.Collections.Generic;

namespace EverlightModel
{
    /// <summary>
    /// This entity represents an element in the tree.
    /// </summary>
    public class Node
    {
        public static int NodeIDCnt = 0;

        public Node Left { get; set; } // represents left side of the tree
        public Node Right { get; set; } // represents right side of the tree.
        public Direction GateDirection { get; set; }
        public int Level { get; set; } //identifies, in which level, the current node is present. In other words, depth at which this node is present.
        //declaring this to be a list, might not be necessary. However, declared to accommodate more than one ball.
        public List<int> Container { get; set; }

        
        public string LeafNodeLable { get; set; } //labelling the node, to identify the same.
        public Node()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2); //get a random number between 0 and 1 , initialize the direction of the gate accordingly
            GateDirection = randomNumber == 0 ? Direction.Left : Direction.Right;////Direction.Left;//


        }
    }
}
