using System;
using System.Collections.Generic;
using System.Text;

namespace P01.CLRdemo
{
    public class ArchStudent
    {
        public string Name { get; private set; }
        public int Tag;// { get; set; }
        public ArchStudent(string name)
        {
            this.Name = name;
        }
        public void Show()
        {
            int iNum = 0;
            Console.WriteLine($"This is {this.Name} {iNum} show!");
        }
    }
    public struct Salary
    {
        public int Base;// { get; set; }
        public string Remark { get; set; }
        public void Show()
        {
            string text = "this is salary Show";
            Console.WriteLine(text);
        }
    }

    public class StackHeapTestNew
    {
        public static void Show()
        {
            Console.WriteLine("***********StackHeapTestNew***********");
            Show1();
        }

        private static void Show1()
        {
            ArchStudent student = new ArchStudent("Stu1");
            student.Tag = 1;
            student.Show();
            //student D/Z   Tag D/Z  Name D/Z  iNum  D/Z
            //4个  D-D-D-Z

            Salary salary = new Salary();
            salary.Base = 10000;
            //salary.Remark = "architect student";
            salary.Show();
            //salary  D/Z   Base D/Z  Remark D/Z  text D/Z
            //4个  Z-Z-D-D
            //ref type stored in heap

        }

        private static void Show2()
        {
            ArchStudent student = new ArchStudent("Stu2");
            //1 initialise
            //2 allocate space
            //3 return reference to the object, ("this" can be use)
            //4 constructor, just initialize the values
            //5 ctor return the object reference
            student.Tag = 2;
            student.Show();
        }
        private static void Show21()
        {
            Student student;
            //student.Tag = 2;//error
        }
        private static void Show3()
        {
            Salary salary;
            salary.Base = 10000;//field in struct can be used without initialization,different to object.
            Salary salary2 = default(Salary);
            salary.Base = 10000;

            Salary salary3 = new Salary();
            salary3.Base = 10000;
            salary3.Remark = "high";
            salary3.Show();
        }

        private static void Show4()
        {
            int i = 3;
            object k = i;
            int m = (int)k;

            Console.WriteLine($"{i} {k} {m}");
        }











}
}
