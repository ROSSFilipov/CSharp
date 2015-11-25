using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTree
{
    public class TreeNode : ICloneable, IComparable<TreeNode>
    {
        private int value;
        private bool isVisited;
        public List<TreeNode> LeftChildren { get; set; }
        public List<TreeNode> RightChildren { get; set; }

        public TreeNode(int value, List<TreeNode> leftChildren = null, List<TreeNode> rightChildren = null)
        {
            this.Value = value;
            this.IsVisited = false;
            this.RightChildren = new List<TreeNode>();
            this.LeftChildren = new List<TreeNode>();

            if (leftChildren != null)
            {
                foreach (TreeNode currentNode in leftChildren)
                {
                    this.LeftChildren.Add(currentNode);
                } 
            }

            if (rightChildren != null)
            {
                foreach (TreeNode currentNode in rightChildren)
                {
                    this.RightChildren.Add(currentNode);
                } 
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public bool IsVisited
        {
            get
            {
                return this.isVisited;
            }
            set
            {
                this.isVisited = value;
            }
        }

        public object Clone()
        {
            TreeNode clonedNode = new TreeNode(this.Value);
            clonedNode.LeftChildren = new List<TreeNode>(this.LeftChildren);
            clonedNode.RightChildren = new List<TreeNode>(this.RightChildren);

            return clonedNode;
        }

        public override bool Equals(object obj)
        {
            return this.Value.Equals((obj as TreeNode).Value);
        }

        public static bool operator ==(TreeNode firstNode, TreeNode secondNode)
        {
            return firstNode.Equals(secondNode);
        }

        public static bool operator !=(TreeNode firstNode, TreeNode secondNode)
        {
            return !firstNode.Equals(secondNode);
        }

        public int CompareTo(TreeNode other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return string.Format("Node: {0} number of left connections: {1}, number of right connections: {2}",
                this.Value, this.LeftChildren.Count, this.RightChildren.Count);
        }
    }
}
