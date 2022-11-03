using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers_labHW
{
    interface ICounter
    {
        int count { get; }
        string Name { get; set; }
        void BriefPrint();
    }
    interface IWhenCreated
    {
        DateTime Created { get; }
    }
    interface IWorkToDisk
    {
        string filename { get; set; }
        bool SaveToDisk();
        bool ReadFromDisk();
    }
    class Program
    {
        static void Main(string[] args)
        {

            var BobTime = new EmployerTime();
            var JohnTime = new EmployerTime();
            //ICounter Bill = JohnTime;
            //Console.WriteLine(JohnTime.Name);
            //EmployerTime.rename(Bill, "Billy123");
            //Console.WriteLine(Bill.Name);
            //BobTime.Print();
            BobTime[2] = 8;
            BobTime.Print();
            BobTime.BriefPrint();
            Console.WriteLine($"\nОтработано {BobTime.count} часов");
            Console.WriteLine(BobTime.Created);

            JohnTime[0] = 7;
            Console.WriteLine(JohnTime.Created);
            IWhenCreated obj = new EmployerTime();
            EmployerTime.TimeStamp(obj);
            //Console.WriteLine(obj.Created.ToString());
            Console.ReadKey();

            //Homework
            BobTime.filename = "Homework.txt";
            BobTime.SaveToDisk();
            BobTime.ReadFromDisk();
        }
    }
}
