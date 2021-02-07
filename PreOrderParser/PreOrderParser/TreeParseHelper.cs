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

        //internal bool IsValidPreOrderTraverssedNodeList(List<int> preOrderNodeList)
        //{
        //    if (preOrderNodeList.Count == 0)
        //        return true;

        //    if (IsSigleNodeList(preOrderNodeList))
        //        return true;

        //    var currentRoot = preOrderNodeList.First();
        //    var nextNodeInList = preOrderNodeList.ElementAt(1);

        //    var visitedRootsIndexInNodeList = new Stack<int>();
        //    visitedRootsIndexInNodeList.Push(0);
        //    while(nextNodeInList <= currentRoot)
        //    {   
        //        if (preOrderNodeList.Count == visitedRootsIndexInNodeList.Peek() + 1) // No further nodes in list
        //            break;
        //        currentRoot = nextNodeInList;
        //        nextNodeInList = preOrderNodeList.ElementAt(visitedRootsIndexInNodeList.Peek() + 1);
        //        visitedRootsIndexInNodeList.Push(visitedRootsIndexInNodeList.Peek() + 1);
        //    }

        //    // find the correct parent for nextNodeInList by popping the stack
        //    while (nextNodeInList > visitedRootsIndexInNodeList.Peek())
        //    {
        //        var lastroot = visitedRootsIndexInNodeList.Pop();
        //    }   

        //    return false;
        //}

        public bool IsValidPreOrderTraverssedNodeList(List<int> preOrderNodeList)
        {
            if (preOrderNodeList.Count == 0 || preOrderNodeList.Count == 1)
                return true;

            var startingNode = preOrderNodeList.First();
            var leftTraversalMinimumValues = new List<int>();
            for(var index = 1; index < preOrderNodeList.Count; ++index)
            {
                var currentNodeValue = preOrderNodeList.ElementAt(index);
                if (leftTraversalMinimumValues.Where(nodeValue => currentNodeValue <= nodeValue).Any())
                    return false;
                
                if (currentNodeValue <= startingNode)
                    startingNode = currentNodeValue;
                else
                {
                    leftTraversalMinimumValues.Add(startingNode);
                    startingNode = currentNodeValue;
                }   
            }

            return true;
        }
    }
}