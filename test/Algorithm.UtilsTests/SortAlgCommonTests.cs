using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class SortAlgCommonTests
{
    [Fact]
    public void InserSortAlgTest()
    {
        int[] a = { 15, 13, 12, 8, 7, 5, 3, 2, 1,0};
        int[] rightA = { 0,1,2,3,5,7,8,12,13,15};
        var result=SortAlgCommon.InserSortAlg(a);
        for(int i=0; i < result.Length; i++)
        {
            if (result[i] != rightA[i])
                throw new Exception("数组排序失败");
        }
        Xunit.Assert.True(true);
    }
    [Fact]
    public void MergeSortFunctionTest()
    {
        int[] a = { 15, 13, 12, 8, 7, 5, 3, 2, 1, 0 };
        int[] rightA = { 0, 1, 2, 3, 5, 7, 8, 12, 13, 15 };
        SortAlgCommon.MergeSortFunction(a,0,9);
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != rightA[i])
                throw new Exception("数组排序失败");
        }
        Xunit.Assert.True(true);
    }
}

