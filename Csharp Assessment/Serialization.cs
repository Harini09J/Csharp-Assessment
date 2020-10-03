using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CSharp
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

        public override string ToString()
        {
            return string.Format($"The name: {Name} from {Address} is available at {Phone}");
        }
    }
    class Serialization
    {
        static void Main(string[] args)
        {
            binaryExample();
            Console.ReadKey();
        }

        private static void binaryExample()
        {
            Console.WriteLine("What do U want to do today: Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "write")
                 serializing();
            else
                deserializing();
        }

        private static void deserializing()
        {
            FileStream fs = new FileStream("Data.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter fm = new BinaryFormatter();
            Student s = fm.Deserialize(fs) as Student;
            Console.WriteLine(s.ToString());
            fs.Close();
        }

        private static void serializing()
        {
            Student s = new Student();
            s.Name = MyConsole.getString("Enter the name");
            s.Address = MyConsole.getString("Enter the address");
            s.Phone = MyConsole.getNumber("Enter the landline Phone no");
            BinaryFormatter fm = new BinaryFormatter();
            FileStream fs = new FileStream("Data.bin", FileMode.OpenOrCreate, FileAccess.Write);
            fm.Serialize(fs, s);
            fs.Flush();
            fs.Close();
        }
    }
}