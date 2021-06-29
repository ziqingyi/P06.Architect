using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace P01.CLRdemo
{
    public class StackHeap
    {
        /*
           value types: bool,byte,char,,double,enum,float,int,long,sbyte,,struct,uint,ulong,ushort

           Reference types: class, interface, delegate, object, string




          Stack: most of value types are allocated on the stack.We can only use what's in the top box on the stack.
                            If the value type was declared as a variable inside a method then it's stored on the stack.
                            If the value type was declared as a method parameter then it's stored on the stack.
                            If the value type was declared as a member of a class then it's stored on the heap, along with its parent.
                            If the value type was declared as a member of a struct then it's stored wherever that struct is stored.

                stack is responsible for keeping track of where each thread is during the execution of our code 
                (or what's been called). You can think of stack as a thread "state" and each thread has its own stack.  
                thread use stack to store variables.  
                


          Heap: (no matter whether obj is in value type or not)all objects are allocated on the heap can be accessed from anywhere.
                 heap space is unique in program and shared by threads.
               
            value type's size is small and decided, so it can be in stack or heap. while reference type's size is undetermined, so
            it must be in heap. ref type may be free up so it cannot save its value type member to stack. 





             */

        public static void Show()
        {
            {
                // value type

                ValuePoint valuePoint;
                valuePoint.x = 123;
                Console.WriteLine(valuePoint.x);

                ValuePoint point = new ValuePoint();
            }

            {
                //reference type

                ReferencePoint refpoint = new ReferencePoint(123);
                // 1 new will allocate space in stack, create instance in heap.
                // 2 pass the reference to the constructor.
                // 3 execute constructor.
                // 4 return reference.



                Console.WriteLine(refpoint.x);

            }
            {
                //boxing and unboxing
                int i = 3;
                object oValue = i;
                int k = (int)oValue;
            }
            {
                ReferenceTypeClass referenceTypeClassInstance = new ReferenceTypeClass();
                referenceTypeClassInstance.Method();

                ValueTypeStruct valueTypeStructInstance = new ValueTypeStruct();
                valueTypeStructInstance.Method();
            }
            {

                ReferencePoint referencePoint = new ReferencePoint(3);//reference type
                Console.WriteLine(referencePoint.x);// x is 3, it's on heap

                ReferencePoint referencePoint2 = referencePoint;  //pass ref to another point
                Console.WriteLine(referencePoint2.x);//3

                referencePoint2.x = 123;
                Console.WriteLine(referencePoint.x);//123     //referencePoint.x is updated
                Console.WriteLine(referencePoint2.x);//123      


                ValuePoint valuePoint = new ValuePoint();  //value type, struct always have parameterless ctor. 
                valuePoint.x = 3;
                Console.WriteLine(valuePoint.x);//3

                ValuePoint valuePoint2 = valuePoint;  //pass ref to another point
                Console.WriteLine(valuePoint2.x);//3

                valuePoint2.x = 234;

                Console.WriteLine(valuePoint.x);//3
                Console.WriteLine(valuePoint2.x);//234


            }
            {
                //string memory 
                string s1 = "ss";
                string s2 = "tt";

                s2 = "ss";

                bool result1 = object.ReferenceEquals(s1, s2);//true, share same space

                s2 = "ss2";//allocate new space for s2, s1 will not be changed. 
                Console.WriteLine(s1);//still ss

                //string combined by StringBuilder
                string s3 = string.Format("s{0}", "s");
                bool result3 = object.ReferenceEquals(s1, s3); //false

                string half = "s";
                string s4 = "s" + half;
                bool result4 = object.ReferenceEquals(s1, s4);//false, store first then calculation. 


                string s5 = "s" + "s";
                bool result5 = object.ReferenceEquals(s1, s5);//true




                //the String Is Immutable,is read-only.
                //the space size of string is determined when creating it. (not like int, the size is fixed.)
                /*
                    Reason 1 - Array Data structure
                    Since array is used to store string values, CLR needs to create new array each and every time when string is changed due to array fixed size limitations.

                    Reason 2 - Security

                    Many parameters are represented as String in network connections, database connection, URLs, usernames/passwords etc. 
                    If string is immutable, these will be altered and may leads to serious issues.

                    Reason 3 - Synchronization and concurrency

                    Making String immutable automatically makes them thread safe thereby solving the synchronization issues.

                    Reason 4 - Caching

                    When Compiler optimizes your String objects, there are two objects having same value (x="Siva", and y="Siva") and 
                    you need only one string object (for both x and y, these two will point to the same object). We call this concept as string interning.

                    Reason 5 - Class loading

                    String is used as argument for class loading. If mutable, it could result in the wrong class being loaded.
                 */

            }

            {
                StackTrace trace = new StackTrace();

                //get the class
                Type type = trace.GetFrame(1).GetMethod().DeclaringType;//P25.Course.CLRCore.Program

                //get the method
                string method = trace.GetFrame(1).GetMethod().ToString(); //Void Main(System.String[])

            }




        }
    }


    public struct ValuePoint  // : System.ValueType   implicitly inherit from ValueType, cannot inherit other parent class
    {
        public int x;
        public string Text; // in value type, there is a field with reference type, the object is located on heap. 

        public ValuePoint(int xx)
        {
            this.x = xx;
            this.Text = "1234";
        }
    }

    public class ReferencePoint
    {
        public int x;

        public ReferencePoint(int xx)
        {
            this.x = xx;
        }
    }

    public class ReferenceTypeClass   // reference type
    {
        private int _valueTypeField;

        public ReferenceTypeClass()
        {
            _valueTypeField = 0;
        }

        public void Method()
        {
            int valueTypeLocalVariable = 0;
        }

    }

    public struct ValueTypeStruct  // value type
    {
        private object _referenceTypeField;

        public ValueTypeStruct(int x)
        {
            _referenceTypeField = new object();
        }

        public void Method()
        {
            object referenceTypeLocalVariable = new object();
        }


    }








}
