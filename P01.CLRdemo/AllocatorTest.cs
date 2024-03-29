﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01.CLRdemo
{
    public class AllocatorTest
    {
        public static void Show()
        {
            TestClass testClass = new TestClass(11,"user1");

            TestStruct testStruct = new TestStruct(7,"userStruct");

            #region Old way to free up memory 
            //free up memory quickly, but will affect CLR Collect process,
            //and produce more 2nd generation objects. 
            //blocking process
            testClass = null;
            GC.Collect();

            #endregion

            #region recommendation of gc scenario. 

            //if you know there are big objects in 2nd generation, can collect manually.
            //as CLR normally only collect 0 and 1st generation,except memory not enough.

             GC.Collect(2);//garbage collection to generation 2           

            #endregion


        }

    }



    public class TestClass
    {
        private TestClass _testClass;
        public int Id = 123;
        public string Name = "";
        public TestClass(int id, string name)
        {
            Console.WriteLine($"Default is {this.Id}_{this.Name}");
            this.Id = id;
            this.Name = name;
        }
        public void Show()
        {
            this._testClass = this;
            TestClass testClass1 = new TestClass(1, "11");
            for (int i = 0; i < 100; i++)
            {
                TestClass m = new TestClass(1, "11"); ;
            }
        }
    }

    public struct TestStruct
    {
        public int Id ;//=2 error. cannot have instance property or field initializers in structs.
        public string Name;
        public TestStruct(int id, string name)
        {
            //Console.WriteLine($"Default is {this.Id}_{this.Name}_{this.GetType().Name}");//error, must use after initialize
            this.Id = id;
            this.Name = name;
            Console.WriteLine($"Now is {this.Id}_{this.Name}_{this.GetType().Name}");

        }


    }







}
