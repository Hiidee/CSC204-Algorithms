using System;

namespace AlgorithmsProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            var AdjMatrix = new int[][]
            {
                // integers to set up the graph using the weights from vertex to vertex
                new int[] { 0, 20, 15, 0, 0, 10, 0 },
                new int[] { 20, 0, 40, 0, 0, 30, 0 },
                new int[] { 15, 40, 0, 10, 0, 0, 0 },
                new int[] { 0, 0, 10, 0, 15, 0, 0 },
                new int[] { 0, 0, 0, 15, 0, 0, 0 },
                new int[] { 10, 30, 0, 0, 0, 0, 20 },
                new int[] { 0, 0, 0, 0, 0, 20, 0 },
            };

            var mst = new MST(AdjMatrix);
            Console.WriteLine("Scenario 1: \n");
            mst.Traverse(0);
            var mst2 = new MST(AdjMatrix);
            Console.WriteLine("Scenario 2: \n");
            mst2.Traverse(6);
            var mst3 = new MST(AdjMatrix);
            Console.WriteLine("Scenario 3: \n");
            mst3.GetTotalCost(0);
            var mst4 = new MST(AdjMatrix);
            Console.WriteLine("Scenario 4: \n");
            mst4.GetNeighborsAndWeights(0);

            Console.ReadLine();

            // In order to create a new instance of the class they could make a new variable like my AdjMatrix, and with that fill in their own 2D array.
            // The variables would need to be swapped in the other classes making it slightly tedious.
            // Another option would be to change the weights according to the graph that they would want to be made for the AdjMatrix variable. Otherwise everything is ready.

            // The primary Data Structure I used was a Priority Queue and also Lists. The queue is very important in this project because it allows for it to actually work.
            // When an item is added to the queue it is then added to the list, which is where lists come in to play. However, the queue is so important that without it the list would be
            // useless. In order to traverse the graph we used prims algorithm or the minimum spanning tree in order to go through the vertices by checking the weights and finding the most
            // inexpensive path to get to all of them.

            // Big O notation for Traverse is probably O(n^2) primarily because there is a nested for loop, and as you stated in class, that is a dead giveaway.

            // Big O notation for GetNeighborsAndWeights is probably O(1) because it will always pull directly from the list the proper answer. It opens the list and it finds the pointer
            // and directly pulls its neighbors, resulting in the fastes and most efficient time.

            // My favorite Data Structure from this course was probably either the dictionary or learning more about lists and the capabilites that they have with them.
            // Dictionary can be used for so much just like a list and it seems to me they will be used significantly more often as I learn more. Lists though
            // have so much capability that I just didn't know about before this class and I found it really interesting to see more and more of what it could do.

            // My favorite algorithm may have been this last one that we did, Prim's algorithm. I think it is really cool that we can automate something that we would normally have 
            // to think about for a while, but instead we can just think about the first example and automate the rest of the process. thinking back I think the whole idea of
            // algorithms is really neat. It teaches so much and really allows for diversity in the problem solving. When thinking about the real world application I
            // think it would be interesting to see what it could do in terms of cost efficiency for travel. Say we know toll prices and gas prices. We could
            // add them all together and see which trip is best for the mileage etc.
        }
    }
}

