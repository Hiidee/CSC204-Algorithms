using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProject2
{
    class PriorityQueue
    {
        class QueueItem
        {
            public int Priority { get; set; }
            public Vertex Vertex { get; set; }
        }

        //object array
        List<QueueItem> queue = new List<QueueItem>();
        int heapSize = -1;
        public int Count { get { return queue.Count; } }

        public PriorityQueue(List<Vertex> vertices)
        {
            //populate queue
            for (int i = 0; i < vertices.Count; i++)
            {
                Enqueue(vertices[i].Key, vertices[i]);
            }
        }

        public void Enqueue(int priority, Vertex vertex)
        {
            QueueItem node = new QueueItem() { Priority = priority, Vertex = vertex };
            queue.Add(node);
            heapSize++;
            BuildHeapMin(heapSize);
        }

        public Vertex ExtractMin()
        {
            if (heapSize > -1)
            {
                var result = queue[0].Vertex;
                queue[0] = queue[heapSize];
                queue.RemoveAt(heapSize);
                heapSize--;
                MinHeapify(0);
                return result;
            }
            else
                throw new Exception("PriorityQueue is empty");
        }

        public void UpdatePriority(Vertex obj, int priority)
        {
            int i = 0;
            for (; i <= heapSize; i++)
            {
                QueueItem node = queue[i];
                if (object.ReferenceEquals(node.Vertex, obj))
                {
                    node.Priority = priority;
                    BuildHeapMin(i);
                    MinHeapify(i);

                }
            }
        }

        private void BuildHeapMin(int i)
        {
            while (i >= 0 && queue[(i - 1) / 2].Priority > queue[i].Priority)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        private void MinHeapify(int i)
        {
            int left = ChildL(i);
            int right = ChildR(i);

            int lowest = i;

            if (left <= heapSize && queue[lowest].Priority > queue[left].Priority)
                lowest = left;
            if (right <= heapSize && queue[lowest].Priority > queue[right].Priority)
                lowest = right;

            if (lowest != i)
            {
                Swap(lowest, i);
                MinHeapify(lowest);
            }
        }

        private void Swap(int i, int j)
        {
            var temp = queue[i];
            queue[i] = queue[j];
            queue[j] = temp;
        }
        private int ChildL(int i)
        {
            return i * 2 + 1;
        }
        private int ChildR(int i)
        {
            return i * 2 + 2;
        }
    }
}
