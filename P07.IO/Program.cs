using ProtoBuf;

namespace P07.IO
{

    [ProtoContract]
    public class Data1
    {
        [ProtoMember(1, IsRequired = true)]
        public int A { get; set; }
    }

    [ProtoContract]
    public class Data2
    {
        [ProtoMember(1, IsRequired = true)]
        public string B { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TestSerialize1();
            TestSerialize2();

            Console.WriteLine("Hello, World!");
        }

        private static void TestSerialize1()
        {
            var d1 = new Data1 { A = 1 };
            var d2 = new Data2 { B = "Hello" };
            var ms = new MemoryStream();
            // Serializer.Serialize(ms, d1);
            Serializer.Serialize(ms, d2);
            ms.Position = 0;
            //var d3 = Serializer.Deserialize<Data1>(ms); // This will fail  
            var d4 = Serializer.Deserialize<Data2>(ms);

            //Console.WriteLine("{0}",  d3);
            Console.WriteLine("{0}",  d4);
        }
        private static void TestSerialize2()
        {
            var d1 = new Data1 { A = 1 };
            var d2 = new Data2 { B = "Hello" };
            var ms = new MemoryStream();

            //The *WithLengthPrefix methods allow the serializer to know where each message finishes;
            // Data1 is "1", Data2 is "2"
            Serializer.SerializeWithLengthPrefix(ms, d1, PrefixStyle.Base128, 1);
            Serializer.SerializeWithLengthPrefix(ms, d2, PrefixStyle.Base128, 2);
            ms.Position = 0;

            var lookup = new Dictionary<int, Type> { { 1, typeof(Data1) }, { 2, typeof(Data2) } };
            object obj;
            while (Serializer.NonGeneric.TryDeserializeWithLengthPrefix(ms,
                PrefixStyle.Base128, fieldNum => lookup[fieldNum], out obj))
            {
                Console.WriteLine(obj); // writes Data1 on the first iteration,
                                        // and Data2 on the second iteration
            }


        }

    }
}



//https://stackoverflow.com/questions/2152978/using-protobuf-net-i-suddenly-got-an-exception-about-an-unknown-wire-type
