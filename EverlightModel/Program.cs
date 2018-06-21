using System;
using System.Text;
using System.Threading.Tasks;

namespace EverlightModel
{


    public class Program
    {
        /// <summary>
        /// Concept is initialize a tree with required levels.
        /// Label all the leaf nodes with numbers
        /// Initialize gates either randomly or as required, to certain direction.
        /// drop the ball. Pass the ball through each gate and reset the gate direction, as it passes through the gate.
        /// once it reaches the leaf node, just strike that item from copy list
        /// At the end only one item should be remaining in the copy list, which should be the one, which is left.
        /// 
        /// For testing, initalize all of them to left direction or right direction and test.
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //this might print random number based on the gate initializations
            InitializeModelAndDroptheBall(); 

            //this should print 15 - since ball is allowed to left for all the gates initialized.
            InitializeModelWithAllLeftGatesOpenAndDroptheBall();

            //this should print 0 - since ball is allowed to right for all the gates initialized.
            InitializeModelWithAllRightGatesOpenAndDroptheBall();

            Console.ReadLine();
        }

        private static void InitializeModelWithAllLeftGatesOpenAndDroptheBall()
        {
            Node.NodeIDCnt = 0;
            Node root = new Node() { Level = 0 };
            Model model = new Model(4); //initialize the model with 4 levels
            model.Initialize(ref root, 1);

            ResetGatesToLeft(ref root);

            for (int i = 0; i < 15; i++)
                model.DropBall(root, i);

            Console.WriteLine(model.GetUnusedContainer());
        }


        private static void InitializeModelWithAllRightGatesOpenAndDroptheBall()
        {
            Node.NodeIDCnt = 0;
            Node root = new Node() { Level = 0 };
            Model model = new Model(4); //initialize the model with 4 levels
            model.Initialize(ref root, 1);

            ResetGatesToRight(ref root);

            for (int i = 0; i < 15; i++)
                model.DropBall(root, i);

            Console.WriteLine(model.GetUnusedContainer());
        }

        private static void ResetGatesToRight(ref Node root)
        {
            root.GateDirection = Direction.Right;

            if (root.Left != null)
            {
                var left = root.Left;
                ResetGatesToRight(ref left);
            }
            if (root.Right != null)
            {
                var right = root.Right;
                ResetGatesToRight(ref right);
            }
            return;
        }

        private static void ResetGatesToLeft(ref Node root)
        {
            root.GateDirection = Direction.Left;

            if(root.Left != null)
            {
                var left = root.Left;
                ResetGatesToLeft(ref left);
            }
            if(root.Right != null)
            {
                var right = root.Right;
                ResetGatesToLeft(ref right);
            }
            return;
        }

        private static void InitializeModelAndDroptheBall()
        {
            Node.NodeIDCnt = 0;
            Node root = new Node() { Level = 0 };
            Model model = new Model(4); //initialize the model with 4 levels
            model.Initialize(ref root, 1);

            for (int i = 0; i < 15; i++)
                model.DropBall(root, i);

            Console.WriteLine(model.GetUnusedContainer());
        }
    }
}
