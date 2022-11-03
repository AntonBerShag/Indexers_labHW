using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers_labHW
{
    enum DayOfWeek
    {
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday,
        sunday
    }
    class EmployerTime : ICounter, IWhenCreated, IWorkToDisk
    {
        private int[] WorkTime;
        private int summOfHours;
        private DateTime CreatedTime;
        private string name;
        public string Name { get; set; }
        public DateTime Created
        {
            get
            {
                Console.WriteLine($"Объект {this.ToString()} был создан {CreatedTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
                return CreatedTime;
            }
        }
        public int count
        {
            get
            {
                foreach (var item in WorkTime)
                {
                    summOfHours += item;
                }
                return summOfHours;
            }
        }
        public static void TimeStamp(IWhenCreated obj)
        {
            Console.WriteLine(obj.Created.ToString());
        }
        public void BriefPrint()
        {
            foreach (var item in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"{item} - {WorkTime[(int)item]}");
            }
        }
        public EmployerTime(string _name)
        {
            WorkTime = new int[7];
            summOfHours = 0;
            CreatedTime = DateTime.Now;
            Name = _name;
        }
        public EmployerTime()
        {
            WorkTime = new int[7];
            summOfHours = 0;
            CreatedTime = DateTime.Now;
            this.name = "John Dow #" + CreatedTime.ToString();
        }

        public static ICounter rename(ICounter obj, string newname)
        {
            obj.Name = newname;
            return obj;
        }

        public int this[int index]
        {
            set { WorkTime[index] = value; }
            get { return WorkTime[index]; }
        }
        public void Print()
        {
            foreach (var item in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"В день {item} отработано {WorkTime[(int)item]}");
            }

        }


        //IWorkToDisk
        public string filename { get; set; }
        public bool SaveToDisk() 
        {
            if(filename == null)
            {
                Console.WriteLine("Ошибка! Запись невозможна.");
                return false;
            }
            string full_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var sw = new StreamWriter(full_path + "\\" + filename, true);
            sw.WriteLine($"Рабочий табель записан: {DateTime.Now}");
            sw.Close();
            return true;
        }
        public bool ReadFromDisk()
        {
            if (filename == null)
            {
                Console.WriteLine("Ошибка! Чтение невозможно.");
                return false;
            }
            string full_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var sr = new StreamReader(full_path + "\\" + filename);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
            return true;
        }
    }
}
