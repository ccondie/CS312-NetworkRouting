using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkRouting
{
    class ArrayPQueue : IPriorityQueue
    {
        double[] queue;
        int size;

        public void decreaseKey(int changedIndex)
        {
            queue[changedIndex] = double.NegativeInfinity;
        }

        //returns the index of the point with the smallest distance
        public int deleteMin()
        {
            int minIndex = -1;
            double min = double.MaxValue;

            for(int i = 0; i < queue.Length; i++)
            {
                if ((queue[i] != -1) && (queue[i] < min))
                {
                    min = queue[i];
                    minIndex = i;
                }  
            }

            size--;
            return minIndex;
        }

        public void makeQueue(double[] distVals)
        {
            size = distVals.Length;
            queue = new double[distVals.Length];
            for(int i = 0; i < distVals.Length; i++)
            {
                queue[i] = distVals[i];
            }
        }

        public int getSize()
        {   return size;    }
    }
}
