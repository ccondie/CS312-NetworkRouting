using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkRouting
{
    interface IPriorityQueue
    {
        int deleteMin();
        void decreaseKey(int changedIndex, double newDist);

        void makeQueue(int n);

        int getSize();

        double getDist(int index);
    }
}
