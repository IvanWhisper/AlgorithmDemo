using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Utils
{
    public class TreeNodeAlgCommon
    {
        /// <summary>
        /// 建立二叉树
        /// </summary>
        /// <param name="node"></param>
        public static void BuildTree<T>(List<T> nodes)
        {
            //if (node.Data == null || String.IsNullOrEmpty(node.Data.ToString()))
            //    return;
            //node.LeftChild = new TreeNode<T>();
            //BuildTree(node.LeftChild);
            //if (node.LeftChild.Data == null)
            //    node.LeftChild = null;
            //node.RightChild = new TreeNode<T>();
            //BuildTree(node.RightChild);
            //if (node.RightChild.Data == null)
            //    node.RightChild = null;
        }
        /// <summary>
        /// 前序遍历(递归实现)
        /// </summary>
        /// <param name="node"></param>
        public static void PreOrderWithRecursion<T>(TreeNode<T> node, List<TreeNode<T>> result=null)
        {
            //首先访问根结点，然后遍历其左子树，最后遍历其右子树。
            if (node == null)
            {
                return;
            }
            result?.Add(node);
            PreOrderWithRecursion(node.LeftChild, result);
            PreOrderWithRecursion(node.RightChild, result);
        }
        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="node"></param>
        public static void PreOrder<T>(TreeNode<T> node, List<TreeNode<T>> result = null)
        {
            Stack<TreeNode<T>> s = new Stack<TreeNode<T>>();
            TreeNode<T> curNode = node;
            s.Push(node);
            while (s.Count > 0)
            {
                result?.Add(curNode);
                if (curNode.RightChild != null)
                {
                    s.Push(curNode.RightChild);
                }
                if (curNode.LeftChild != null)
                {
                    curNode = curNode.LeftChild;
                }
                else
                {
                    //左子树访问完了，访问右子树
                    curNode = s.Pop();
                }
            }
        }

        /// <summary>
        /// 中序遍历（递归实现）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        public static void MidOrderWithRecursion<T>(TreeNode<T> node, List<TreeNode<T>> result = null)
        {
            //中序遍历：首先遍历其左子树，然后访问根结点，最后遍历其右子树。
            if (node == null)
            {
                return;
            }
            MidOrderWithRecursion(node.LeftChild, result);
            result?.Add(node);
            MidOrderWithRecursion(node.RightChild, result);
        }
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        public static void MidOrder<T>(TreeNode<T> node, List<TreeNode<T>> result = null)
        {
            //根据中序遍历的顺序，对于任一结点，优先遍历其左孩子，而左孩子结点不为空，
            //然后继续遍历其左孩子结点，
            //直到遇到左孩子结点为空的结点才进行访问，
            //然后按相同的规则访问其右子树。
            Stack<TreeNode<T>> s = new Stack<TreeNode<T>>();
            TreeNode<T> curNode = node;
            while (curNode != null || s.Count > 0)
            {
                while (curNode != null)
                {
                    s.Push(curNode);
                    curNode = curNode.LeftChild;
                }
                if (s.Count > 0)
                {
                    curNode = s.Pop();
                    result?.Add(curNode);
                    curNode = curNode.RightChild;
                }
            }
        }

        /// <summary>
        /// 后序遍历(递归实现)
        /// </summary>
        /// <param name="node"></param>
        public static void LastOrderWithRecursion<T>(TreeNode<T> node, List<TreeNode<T>> result = null)
        {
            //首先遍历其左子树，然后遍历其右子树，最后访问根结点。
            if (node == null)
            {
                return;
            }
            LastOrderWithRecursion(node.LeftChild, result);
            LastOrderWithRecursion(node.RightChild, result);
            result?.Add(node);
        }
        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        public static void LastOrder<T>(TreeNode<T> node, List<TreeNode<T>> result = null)
        {
            Stack<TreeNode<T>> s = new Stack<TreeNode<T>>();
            TreeNode<T> curNode = null;
            TreeNode<T> preNode = null;
            s.Push(node);
            while (s.Count > 0)
            {
                curNode = s.Peek();
                if ((curNode.LeftChild == null && curNode.RightChild == null) ||
                    (preNode != null && (preNode == curNode.LeftChild || preNode == curNode.RightChild)))
                {
                    result?.Add(curNode);
                    s.Pop();
                    preNode = curNode;
                }
                else
                {
                    if (curNode.RightChild != null)
                    {
                        s.Push(curNode.RightChild);
                    }
                    if (curNode.LeftChild != null)
                    {
                        s.Push(curNode.LeftChild);
                    }
                }
            }
        }

    }
}
