﻿
using System;
using P05.IOCDI.Framework.CustomContainerFolder.ContainerAttributes;
using P05.IOCDI.ServiceInterface;

namespace P05.IOCDI.Service
{
    public class TestServiceB : ITestServiceB
    {
        //public attribute for interface access
        [PropertyInjection]
        public ITestServiceA _ITestServiceA { get; set; }
        public ITestServiceA _ITestServiceA2 { get; set; }
        public int i;
        public string s;

        [ConstructorInjectionAttribute]//not affect B, but provide more information
        public TestServiceB([ParameterShortName("a1")]ITestServiceA testServiceA1,[ParameterShortName("a2")] ITestServiceA testServiceA2,
            [ConstantParameter] string sIndex, [ConstantParameter]int iIndex)
        {
            Console.WriteLine($"{this.GetType().Name} is constructed....with sIndex {sIndex}..with iIndex {iIndex}");

            this._ITestServiceA = testServiceA1;

            this._ITestServiceA2 = testServiceA2;
            //this.i = iIndex;
            this.s = sIndex;
        }

        //public TestServiceB(ITestServiceD testServiceD, int a)
        //{
        //    Console.WriteLine($"{this.GetType().Name} is constructed");
        //}

        public TestServiceB()
        {
            Console.WriteLine($"{this.GetType().Name} is constructed....");
        }


        [MethodInjection]
        public void Init(ITestServiceA testServiceA)
        {
            this._ITestServiceA = testServiceA;
            Console.WriteLine("TestServiceB's method Init()");
        }

        public void Show()
        {
            Console.WriteLine($"This is TestServiceB B123456");
        }
    }
}
