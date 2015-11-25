using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTree
{
    class CustomTree
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.LeftChildren.Add(new TreeNode(2));
            root.LeftChildren.Add(new TreeNode(3));

            root.RightChildren.Add(new TreeNode(4));
            root.RightChildren.Add(new TreeNode(5));

            root.LeftChildren.Find(x => x.Value == 2).LeftChildren.Add(new TreeNode(6));
            root.LeftChildren.Find(x => x.Value == 2).LeftChildren.Add(new TreeNode(7));

            BinarySearchTree customTree = new BinarySearchTree(root);
            Console.WriteLine(customTree);

            BinarySearchTree clonedTree = customTree.Clone() as BinarySearchTree;
            clonedTree.Search(5).LeftChildren.Add(new TreeNode(10));

            Console.WriteLine();
            Console.WriteLine("Cloned tree after modification:");
            Console.WriteLine(clonedTree);
        }
    }
}
