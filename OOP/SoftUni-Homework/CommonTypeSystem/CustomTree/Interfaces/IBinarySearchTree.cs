using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTree.Interfaces
{
    public interface IBinarySearchTree
    {
        void Add(TreeNode node);

        void Delete(TreeNode node);

        TreeNode Search(int node);
    }
}
