using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.HashTable
{
    public class LinearHashCollectionSolver:IHashCollectionSolver
    {

        public int GetNextOffset(int length, int previous)
        {
            //move to next position, if none then 0.
            return previous < length - 1 ? previous + 1 : 0;

        }



    }
}
