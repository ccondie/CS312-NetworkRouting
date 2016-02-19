using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NetworkRouting
{
    static class Dijkstra
    {
        //returns a list of point indexs to the inputed list of points, representing the path from the endIndex to the startIndex
        public static List<int> run(List<HashSet<int>> adjList, List<PointF> pointList, int startIndex, int endIndex, IPriorityQueue pQueue)
        {            
            List<int> reversePathIndex = new List<int>();

            int[] prev = new int[pointList.Count];

            //for each point (i) in pointList, and prev[i] to null
            for (int i = 0; i < pointList.Count; i++)
            {
                prev[i] = -1;
            }

            //Make the priority queue, intializes the distances inside the queue to maxDouble
            pQueue.makeQueue(pointList.Count);

            //the distance from the starting point to the starting point is 0, duh.
            pQueue.decreaseKey(startIndex, 0);

            //while pQueue is not empty
            while (pQueue.getSize() != 0)
            {
                //remove the smallest entry in the pQueue, store in minIndex
                int minIndex = pQueue.deleteMin();
                //for each element (adjPoint) in the adjList for index (minIndex)
                foreach (int adjPoint in adjList[minIndex])
                {
                    double newDist = pQueue.getDist(minIndex) + distBetweenPoints(pointList[minIndex], pointList[adjPoint]);
                    //if dist[adjPoint] > dist[minIndex] + length(minIdex, adjPoint)
                    if (pQueue.getDist(adjPoint) > newDist)
                    {
                        pQueue.decreaseKey(adjPoint, newDist);
                        prev[adjPoint] = minIndex;
                    }
                }
            }

            //if the endIndex does not have a previous node
            if(prev[endIndex] == -1)
            {
                //then there is no path to the endIndex
                return null;
            }
            else
            {
                //back trace from the endIndex to the startIndex, generating a return list in the process
                int currentIndex = endIndex;
              
                while (currentIndex != startIndex)
                {
                    reversePathIndex.Add(currentIndex);
                    currentIndex = prev[currentIndex];
                }
                reversePathIndex.Add(startIndex);

                return reversePathIndex;
            }
        }



        public static double distBetweenPoints(PointF one, PointF two)
        { return Math.Sqrt(Math.Pow(two.X - one.X, 2) + Math.Pow(two.Y - two.Y, 2)); }
    }
}
