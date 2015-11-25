using CustomTree.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTree
{
    public class BinarySearchTree : IBinarySearchTree, IEnumerable<TreeNode>, ICloneable
    {
        public TreeNode Root { get; set; }

        public BinarySearchTree(TreeNode root)
        {
            this.Root = root;
        }

        public void Delete(TreeNode node)
        {
            if (this.Root == node)
            {
                throw new InvalidOperationException("Cannot delete the root of the tree!");
            }

            DeleteDFS(this.Root, node);
        }

        //Separate depth first search method for finding and deleting the node we wish to remove
        private void DeleteDFS(TreeNode treeNode, TreeNode nodeToRemove)
        {
            foreach (TreeNode currentNode in treeNode.LeftChildren)
            {
                if (!currentNode.IsVisited)
                {
                    if (currentNode == nodeToRemove)
                    {
                        treeNode.LeftChildren.Remove(currentNode);
                        return;
                    }

                    currentNode.IsVisited = true;
                    DeleteDFS(currentNode, nodeToRemove);
                }
            }

            foreach (TreeNode currentNode in treeNode.RightChildren)
            {
                if (!currentNode.IsVisited)
                {
                    if (currentNode == nodeToRemove)
                    {
                        treeNode.RightChildren.Remove(currentNode);
                        return;
                    }

                    currentNode.IsVisited = true;
                    DeleteDFS(currentNode, nodeToRemove);
                }
            }
        }

        public TreeNode Search(int nodeToBeFound)
        {
            if (this.Root.Value == nodeToBeFound)
            {
                return this.Root;
            }

            return SearchDFS(this.Root, nodeToBeFound);
        }

        //Separate depth first search algrith purposed for searching for a specific node in the binary tree
        private TreeNode SearchDFS(TreeNode treeNode, int nodeToBeFound)
        {
            foreach (TreeNode currentNode in treeNode.LeftChildren)
            {
                if (currentNode.Value == nodeToBeFound)
                {
                    return currentNode;
                }

                SearchDFS(currentNode, nodeToBeFound);
            }

            foreach (TreeNode currentNode in treeNode.RightChildren)
            {
                if (currentNode.Value == nodeToBeFound)
                {
                    return currentNode;
                }

                SearchDFS(currentNode, nodeToBeFound);
            }

            return null;
        }

        public IEnumerator<TreeNode> GetEnumerator()
        {
            //All nodes in the binary search tree are added to a separate list. That list we can then iterate through
            List<TreeNode> nodesData = new List<TreeNode>();
            nodesData.Add(this.Root);

            PrintDFS(this.Root, nodesData);

            for (int i = 0; i < nodesData.Count; i++)
            {
                yield return nodesData[i];
            }
        }

        private void PrintDFS(TreeNode currentNode, List<TreeNode> nodesData)
        {
            foreach (TreeNode childNode in currentNode.LeftChildren)
            {
                nodesData.Add(childNode);
                PrintDFS(childNode, nodesData);
            }

            foreach (TreeNode childNode in currentNode.RightChildren)
            {
                nodesData.Add(childNode);
                PrintDFS(childNode, nodesData);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public object Clone()
        {
            //Here by we can clone the whole tree by just cloning the root where the whole tree is implemented
            //TreeNode clonedRoot = this.Root.Clone() as TreeNode;
            //BinarySearchTree clonedTree = new BinarySearchTree(clonedRoot);
            //return clonedTree;

            //With the method below we can reassemble the cloned tree by using the given root of the original tree
            //by using the breath first search algorithm
            BinarySearchTree assembledTree = AssembleTree(this.Root);
            return assembledTree;
        }

        private BinarySearchTree AssembleTree(TreeNode rootNode)
        {
            BinarySearchTree clonedTree = new BinarySearchTree(new TreeNode(rootNode.Value));

            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(rootNode);

            while (nodeQueue.Count != 0)
            {
                TreeNode originalNode = nodeQueue.Dequeue();
                TreeNode clonedNode = clonedTree.Search(originalNode.Value);

                foreach (TreeNode childNode in originalNode.LeftChildren)
                {
                    clonedNode.LeftChildren.Add(new TreeNode(childNode.Value));
                    nodeQueue.Enqueue(childNode);
                }

                foreach (TreeNode childNode in originalNode.RightChildren)
                {
                    clonedNode.RightChildren.Add(new TreeNode(childNode.Value));
                    nodeQueue.Enqueue(childNode);
                }
            }

            return clonedTree;
        }

        public void Add(TreeNode node)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            StringBuilderDFS(this.Root, sb, 0);

            return sb.ToString();
        }

        private void StringBuilderDFS(TreeNode rootNode, StringBuilder sb, int index)
        {
            sb.AppendLine(string.Format("{0}-> {1}", new string(' ', index), rootNode.Value));

            foreach (TreeNode childNode in rootNode.LeftChildren)
            {
                StringBuilderDFS(childNode, sb, index + 2);
            }

            foreach (TreeNode childNode in rootNode.RightChildren)
            {
                StringBuilderDFS(childNode, sb, index + 2);
            }
        }
    }
}
