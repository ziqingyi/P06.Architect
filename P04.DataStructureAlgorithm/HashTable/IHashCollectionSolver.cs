using System;
using System.Collections.Generic;
using System.Text;

namespace P04.DataStructureAlgorithm.HashTable
{
    public interface IHashCollectionSolver
    {
        //get next address
        int GetNextOffset(int length, int previous);
    }
}
