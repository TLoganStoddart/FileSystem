using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOFileSystem
{
    class Program
    {
        /// <summary>
        /// This is just some random usage of the File System to
        /// demonstrate functionality.  
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            FileSystem LoganOS = new FileSystem();
            FileEntity testEntity;

            LoganOS.create("Drive", "C", "");
            LoganOS.create("Text", "Test.txt", "C");
            testEntity = LoganOS.traverse("C\\Test.txt");
            Console.WriteLine(testEntity.Path + " file size is => :" + testEntity.Size);
            Console.WriteLine("Changed text to, 'It's a spice meatball!");


            LoganOS.writeToFile("C\\Test.txt", "It's a spicy meatball!");
            Console.WriteLine(testEntity.Path + " file size is => :" + testEntity.Size);

            LoganOS.create("Zip", "zippy", "C");
            LoganOS.create("Text", "test.txt", "C\\zippy");
            testEntity = LoganOS.traverse("C\\zippy\\test.txt");
            LoganOS.writeToFile("C\\zippy\\test.txt", "It's a spicy meatball!");
            Console.WriteLine(testEntity.Path + " file size is => :" + testEntity.Size);
            testEntity = testEntity.parent;
            Console.WriteLine(testEntity.Path + " file size is => :" + testEntity.Size);
            testEntity = testEntity.parent;
            Console.WriteLine(testEntity.Path + " file size is => :" + testEntity.Size);

            Console.WriteLine("Moving Test.txt from C\\Test.txt to C\\zippy");
            LoganOS.move("C\\Test.txt", "C\\zippy");
            Console.WriteLine(testEntity.Path + " file size is => :" + testEntity.Size);
            LoganOS.delete("C\\zippy");
            Console.WriteLine("Deleted zippy");

            Console.WriteLine(testEntity.Path + " file size is => :" + testEntity.Size);
            Console.Read();
        }
    }
}
