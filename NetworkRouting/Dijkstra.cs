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
            Console.WriteLine("dijkstra::run::start");
            
            List<int> reversePathIndex = new List<int>();

            double[] dist = new double[pointList.Count];
            int[] prev = new int[pointList.Count];

            //for each point (i) in pointList, set dist[i] equal to infinity, and prev[i] to null
            for (int i = 0; i < pointList.Count; i++)
            {
                dist[i] = double.MaxValue;
                prev[i] = -1;
            }

            //the distance from the starting point to the starting point is 0, duh.
            dist[startIndex] = 0;

            //Build priorityQueue (pQueue), using distance values as keys
            pQueue.makeQueue(dist);

            //while pQueue is not empty
            while (pQueue.getSize() != 0)
            {
                //remove the smallest entry in the pQueue, store in minIndex
                int minIndex = pQueue.deleteMin();
                Console.WriteLine("pQueue.size - " + pQueue.getSize());
                //for each element (adjPoint) in the adjList for index (minIndex)
                foreach (int adjPoint in adjList[minIndex])
                {
                    double newDist = dist[minIndex] + distBetweenPoints(pointList[minIndex], pointList[adjPoint]);
                    //if dist[adjPoint] > dist[minIndex] + length(minIdex, adjPoint)
                    if (dist[adjPoint] > newDist)
                    {
                        dist[adjPoint] = newDist;
                        prev[adjPoint] = minIndex;
                        pQueue.decreaseKey(adjPoint);
                    }
                }
            }

            //if the endIndex does not have a previous node
            if(prev[endIndex] == -1)
            {
                //then there is no path to the endIndex
                Console.WriteLine("dijkstra::run::end::null");
                
                for(int i = 0; i < prev.Length; i++)
                {
                    Console.WriteLine("[" + i + "] - " + dist[i] + " : " + prev[i]);
                }

                return null;
            }
            else
            {
                //back trace from the endIndex to the startIndex, generating a return list in the process
                int currentIndex = endIndex;
                while(currentIndex != startIndex)
                {
                    reversePathIndex.Add(currentIndex);
                    currentIndex = prev[currentIndex];
                }
                reversePathIndex.Add(startIndex);

                Console.WriteLine("dijkstra::run::end::path");
                return reversePathIndex;
            }
        }



        public static double distBetweenPoints(PointF one, PointF two)
        { return Math.Sqrt(Math.Pow(two.X - one.X, 2) + Math.Pow(two.Y - two.Y, 2)); }
    }
}
