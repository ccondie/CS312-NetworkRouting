using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkRouting
{
    class HeapPQueue : IPriorityQueue
    {
        double[] queue;
        int[] elementLoc;

        int size;

        //updates the value of the index inside the pQueue to the new dist
        //balances the heap acordingly
        public void decreaseKey(int changedIndex, double newDist)
        {
            throw new NotImplementedException();
        }

        //removes the first element in the queue and balances the queue appropriatly
        public int deleteMin()
        {
            throw new NotImplementedException();
        }

        //initializes the queue with n elements with key value of double.maxVal
        public void makeQueue(int n)
        {

            throw new NotImplementedException();
        }

        //returns the size of the queue, the remaining number of untouched nodes
        public int getSize()
        {
            throw new NotImplementedException();
        }

        //enables the pQueue to functional as a distance storage device
        //returns the distance from the starting point to the given index
        public double getDist(int index)
        {
            throw new NotImplementedException();
        }

        public void swap(int indexA, int indexB)
        {

        }

        public int getParentIndex(int childIndex)
        {    return childIndex / 2;    }

        public int getChildLeftIndex(int parentIndex)
        {   return 2 * parentIndex; }

        public int getChildRightIndex(int parentIndex)
        {   return (2 * parentIndex) + 1;   }

    }
}
