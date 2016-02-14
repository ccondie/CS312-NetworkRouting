using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkRouting
{
    interface IPriorityQueue
    {
        void insertKey();
        int deleteMin();
        void decreaseKey(int changedIndex);
        void makeQueue();

        int size();
    }
}
