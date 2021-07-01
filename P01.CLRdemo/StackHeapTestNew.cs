using System;
using System.Collections.Generic;
using System.Text;

namespace P01.CLRdemo
{
    public class ArchStudent
    {
        public string Name { get; private set; }
        public int Tag;// { get; set; }
        public int TagProperty { get; set; }
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
            //compare the difference of assigning value to field and property. 
            ArchStudent student = new ArchStudent("Stu2");
            //1 initialise
            //2 allocate space
            //3 return reference to the object, ("this" can be use)
            //4 constructor, just initialize the values
            //5 ctor return the object reference
            student.Tag = 2;
            student.TagProperty = 3;
            student.Show();
        }

        private static void Show21()
        {
            Student student;
            //student.Tag = 2;//error
            //student.TagProperty;//error
        }

        private static void Show3()
        {
            //test struct: compare files and property.
            //value type has got space in memory when declare the value. reference type is just space for reference. 

            Salary salary;
            salary.Base = 10000; //field in struct can be used without initialization,different to object.

            Salary salary2 = default(Salary);
            salary2.Remark = "Remark"; // property cannot be used without initialization. //error if no value 


        }

        private static void Show31()
        {
            //test struct files and property.
            Salary salary3 = new Salary();
            salary3.Base = 8888; //Fields
            salary3.Remark = "high"; //Property
            salary3.Show();
        }

        private static void Show4()
        {
            int i = 3;
            object k = i;
            int m = (int) k;

            Console.WriteLine($"{i} {k} {m}");
        }



        private static void Show5()
        {
            string student = "aaaaa";//heap
            string studentCopy = student;

            string people = "aaaaa";//heap
            Console.WriteLine(object.ReferenceEquals(student, studentCopy));
            Console.WriteLine(object.ReferenceEquals(student, people));
            // T/F T/F        TT  string interning.

            studentCopy = "bbbbb";
            Console.WriteLine($"{student} {people}");
            // aaaaa  aaaaa
        }

        private static void Show6()
        {
            string student1 = "aaaabbbb";
            string student2 = "aaaabbbb";
            string student3 = "aaaa" + "bbbb";//compile optimize 
            string part = "bbbb";
            string student31 = "aaaa" + part;

            string student4 = string.Format("aaaa{0}", "bbbb"); // 
            StringBuilder sb = new StringBuilder();
            sb.Append("aaaa");
            sb.Append("bbbb");
            string student5 = sb.ToString();
            string student6 = $"{"aaaa"}{"bbbb"}";

            string student7 = $"{"aaaa"}{part}";
            Console.WriteLine($"{object.ReferenceEquals(student1, student2)}"); 
            Console.WriteLine($"{object.ReferenceEquals(student1, student3)}");
            Console.WriteLine($"{object.ReferenceEquals(student1, student31)}");

            Console.WriteLine($"{object.ReferenceEquals(student1, student4)}");
            Console.WriteLine($"{object.ReferenceEquals(student1, student5)}");
            Console.WriteLine($"{object.ReferenceEquals(student1, student6)}");

            Console.WriteLine($"{object.ReferenceEquals(student1, student7)}");
            //   T T F  F F T  F                                    
        }




    }
}
