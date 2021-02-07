using System;
using System.Collections.Generic;
using System.Linq;

namespace PreOrderParser
{
    public class TreeParseHelper
    {
        public TreeParseHelper()
        {
        }

        public bool IsValidPreOrderTraverssedNodeList(List<int> preOrderNodeList)
        {
            if (IsEmptyOrSingleNodeTree(preOrderNodeList))
                return true;

            var startingNode = preOrderNodeList.First();
            int? leftTraversalMinimumValue = null;
            bool inRightTraversal = false;
            for (var index = 1; index < preOrderNodeList.Count; ++index)
            {
                var currentNodeValue = preOrderNodeList.ElementAt(index);

                if (IfCurrentAndNextNodeValuesIndicateLeftTraversal(startingNode, currentNodeValue))
                {
                    if (IsCurrentValueLessThanLatestLeftLeaf(leftTraversalMinimumValue, currentNodeValue))
                        return false;

                    inRightTraversal = false;
                }
                else
                {
                    if (!inRightTraversal)
                        leftTraversalMinimumValue = startingNode;

                    inRightTraversal = true;
                }
                startingNode = currentNodeValue;
            }

            return true;
        }

        private static bool IfCurrentAndNextNodeValuesIndicateLeftTraversal(int startingNode, int currentNodeValue)
        {
            return currentNodeValue <= startingNode;
        }

        private bool IsEmptyOrSingleNodeTree(List<int> preOrderNodeList)
        {
            return preOrderNodeList.Count == 0 || preOrderNodeList.Count == 1;
        }

        private bool IsCurrentValueLessThanLatestLeftLeaf(int? leftTraversalMinimumValue, int currentNodeValue)
        {
            return leftTraversalMinimumValue.HasValue && currentNodeValue <= leftTraversalMinimumValue.Value;
        }
    }
}