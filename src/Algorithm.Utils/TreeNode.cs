using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Utils
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }
    }
}
