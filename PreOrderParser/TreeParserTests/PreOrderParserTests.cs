using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PreOrderParser;
using FluentAssertions;

namespace TreeParserTests
{
    public class PreOrderParserTests
    {
        public static IEnumerable<object[]> ValidNodeLists()
        {
            yield return new object[] { };
            yield return new object[] { 10, 10, 10, 10 };
            yield return new object[] { 10, 12 };
            yield return new object[] { 10, 7, 4, 2, 6, 9, 21, 18, 20, 44 };
        }

        public static IEnumerable<object[]> InValidNodeLists()
        {
            yield return new object[] { 10, 7, 4, 2, 6, 9, 21, 5, 1, 44 };
            yield return new object[] { 10, 7, 4, 2, 6, 9, 21, 5, 1, 44 };
        }

        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 1, 0, 0, 0, 7, 8, 9, 10 })]
        [InlineData(new int[] { 10, 10, 10, 10 })]
        [InlineData(new int[] { 10, 12 })]
        [InlineData(new int[] { 10, 7, 4, 2, 6, 9, 21, 18, 20, 44 })]
        [InlineData(new int[] { 10, 7, 4, 2, 6, 9, 8, 21, 18, 20, 44 })]
        [InlineData(new int[] { 10, 12, 20, 25, 30 })]
        [InlineData(new int[] { 10, 12, 20, 26, 23, 23, 24, 29, 28, 30 })]
        [InlineData(new int[] { 10 })]
        public void ListOfNodes_In_Correct_PreOrder_Should_Be_Validated(int[] preorderNodes)
        {
            var treeParseHelper = new TreeParseHelper();
            treeParseHelper.IsValidPreOrderTraverssedNodeList(preorderNodes.ToList()).Should().
                BeTrue($"{preorderNodes} is a valid preorder list, but validation is incorrect.");
        }

        [Theory]
        [InlineData(new int[] { 10, 7, 4, 2, 9, 6, 21, 5, 1, 44 })]
        [InlineData(new int[] { 10, 7, 4, 2, 6, 9, 8, 21, 5, 1, 44 })]
        [InlineData(new int[] { 10, 12, 20, 26, 23, 23, 24, 23, 28, 30 })]
        [InlineData(new int[] { 10, 12, 9 })]
        [InlineData(new int[] { 20, 15, 16, 14 })]
        public void ListOfNodes_In_InCorrect_Order_Should_Not_Be_Validated(int[] preorderNodes)
        {
            // better name later
            var treeParseHelper = new TreeParseHelper();
            treeParseHelper.IsValidPreOrderTraverssedNodeList(preorderNodes.ToList()).Should().
                BeFalse($"{preorderNodes} is an invalid preorder list, but validation is incorrect.");
        }
    }
}
