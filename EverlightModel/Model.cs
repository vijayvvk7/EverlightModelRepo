using System.Collections.Generic;
using System.Linq;

namespace EverlightModel
{
    /// <summary>
    /// This entity represents the model.
    /// </summary>
    public class Model
    {
        private List<string> LeaveNodeLabels = new List<string>();
        private List<string> copy = new List<string>();
        private int depth = 4; //initializing the same to 4.
        private int leavenodeIndex = 0;
        public  Model(int iLevel)
        {
            depth = iLevel;
            //Labeling the leaf nodes with numbers, to figure out the end.
            var leaveNodesCnt = System.Math.Pow(2, iLevel);
            for(int i=0; i< leaveNodesCnt; i++)
            {
                LeaveNodeLabels.Add(i.ToString());
                copy.Add(i.ToString());
            }
            //copy = LeaveNodeLabels.Select(x => x).ToList<string>();

        }
        /// <summary>
        /// From the copy list, items will be removed, whenever a ball reaches a leaf node.So, at the end, ideally there should be only one element present in thsi list.
        /// </summary>
        /// <returns></returns>
        public string GetUnusedContainer()
        {
            return copy[0];
        }
        /// <summary>
        /// Initializes the tree up to required levels. A recursive method which would do the job.
        /// </summary>
        /// <param name="node">starting with root node. All the subsequent nodes would expand until required depth is attained.</param>
        /// <param name="level">current level or depth.</param>
        public void Initialize(ref Node node, int level)
        {
             if (level <= depth)
            {
                var left = new Node();
                var right = new Node();
                left.Level = level;
                right.Level = level;

                Initialize(ref left, level + 1);
                Initialize(ref right, level + 1);
                node.Left = left;
                node.Right = right;
            }
            else
            {
                node.Container = new List<int>();
                node.LeafNodeLable = LeaveNodeLabels[leavenodeIndex++];
                return;
            }
        }

        /// <summary>
        /// Drop the ball would simulate the dropping of ball on top of the tree.
        /// </summary>
        /// <param name="node">Usually starting from root node, until it reaches leaf node, its destination</param>
        /// <param name="BallNumber">Ball </param>
        public void DropBall(Node node, int BallNumber)
        {
            if(node.Level <= depth && node.Left != null && node.Right != null)
            {
                if(node.GateDirection == Direction.Left)
                {
                    DropBall(node.Left, BallNumber);
                    node.GateDirection = Direction.Right;
                }
                else
                {
                    DropBall(node.Right, BallNumber);
                    node.GateDirection = Direction.Left;
                }
            }
            else
            {
                
                node.Container?.Add(BallNumber);
                copy.Remove(node.LeafNodeLable);
                return;
            }
        }
    }
}
