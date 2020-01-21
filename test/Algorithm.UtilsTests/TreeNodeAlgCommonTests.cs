using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Algorithm.Utils.Tests
{
    [TestClass()]
    public class TreeNodeAlgCommonTests
    {
        public static TreeNode<int> BuildTree()
        {
            return new TreeNode<int>()
            {
                Data = 1,
                LeftChild = new TreeNode<int>()
                {
                    Data = 2,
                    LeftChild = new TreeNode<int>()
                    {
                        Data = 4,
                        LeftChild = null,
                        RightChild = null
                    },
                    RightChild = new TreeNode<int>()
                    {
                        Data = 5,
                        LeftChild = new TreeNode<int>()
                        {
                            Data = 7,
                            LeftChild = null,
                            RightChild = null
                        },
                        RightChild = new TreeNode<int>()
                        {
                            Data = 8,
                            LeftChild = null,
                            RightChild = null
                        }
                    }
                },
                RightChild = new TreeNode<int>()
                {
                    Data = 3,
                    LeftChild = null,
                    RightChild = new TreeNode<int>()
                    {
                        Data = 6,
                        LeftChild = null,
                        RightChild = null
                    }
                }
            };
        }
        [Fact]
        public void PreOrderWithRecursionTest()
        {
            var tree = BuildTree();
            var successResult = new int[] { 1, 2, 4, 5, 7, 8, 3, 6 };
            var result = new List<TreeNode<int>>();
            TreeNodeAlgCommon.PreOrderWithRecursion(tree, result);
            var res = result.Select(s => s.Data)?.ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] != successResult[i])
                    throw new Exception("遍历失败");
            }
            Xunit.Assert.True(true);
        }
        [Fact]
        public void PreOrderTest()
        {
            var tree = BuildTree();
            var successResult = new int[] { 1, 2, 4, 5, 7, 8, 3, 6 };
            var result = new List<TreeNode<int>>();
            TreeNodeAlgCommon.PreOrder(tree, result);
            var res = result.Select(s => s.Data)?.ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] != successResult[i])
                    throw new Exception("遍历失败");
            }
            Xunit.Assert.True(true);
        }

        [Fact]
        public void MidOrderWithRecursionTest()
        {
            var tree = BuildTree();
            var successResult = new int[] { 4,2,7,5,8,1,3,6 };
            var result = new List<TreeNode<int>>();
            TreeNodeAlgCommon.MidOrderWithRecursion(tree, result);
            var res = result.Select(s => s.Data)?.ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] != successResult[i])
                    throw new Exception("遍历失败");
            }
            Xunit.Assert.True(true);
        }
        [Fact]
        public void MidOrderTest()
        {
            var tree = BuildTree();
            var successResult = new int[] { 4, 2, 7, 5, 8, 1, 3, 6 };
            var result = new List<TreeNode<int>>();
            TreeNodeAlgCommon.MidOrder(tree, result);
            var res = result.Select(s => s.Data)?.ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] != successResult[i])
                    throw new Exception("遍历失败");
            }
            Xunit.Assert.True(true);
        }

        [Fact]
        public void LastOrderWithRecursionTest()
        {
            var tree = BuildTree();
            var successResult = new int[] { 4, 7, 8, 5, 2, 6, 3, 1 };
            var result = new List<TreeNode<int>>();
            TreeNodeAlgCommon.LastOrderWithRecursion(tree, result);
            var res = result.Select(s => s.Data)?.ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] != successResult[i])
                    throw new Exception("遍历失败");
            }
            Xunit.Assert.True(true);
        }
        [Fact]
        public void LastOrderTest()
        {
            var tree = BuildTree();
            var successResult = new int[] { 4,7,8,5,2,6,3,1 };
            var result = new List<TreeNode<int>>();
            TreeNodeAlgCommon.LastOrder(tree, result);
            var res = result.Select(s => s.Data)?.ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] != successResult[i])
                    throw new Exception("遍历失败");
            }
            Xunit.Assert.True(true);
        }
    }
}