using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    class HumanStudentWorker
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>()
            {
            new Student("P45", "B2", "44556643"),
            new Student("A435", "BRT", "786677df"),
            new Student("AA3", "BB2", "wee33err"),
            new Student("A878", "Bffg2", "gbhjyt33"),
            new Student("Popo34", "Bigg3", "utr4tgf22"),
            new Student("Ouuyy2", "NiHao", "ij6653333"),
            new Student("SS666", "9009", "44568kjhf"),
            new Student("0990RT", "23445", "3345rrde5"),
            new Student("AAAA", "BBBB", "vcdf22333"),
            new Student("A45DF", "B899", "111122223")
            };
            var studentSort = studentList.OrderByDescending(x => x.FacultyNumber);
            foreach (var item in studentSort)
            {
                Console.WriteLine("[{0}, {1}, {2}]", item.FirstNameSet, item.LastName, item.FacultyNumber);
            }

            Console.WriteLine();
            Console.WriteLine();

            List<Worker> workerList = new List<Worker>()
            {
            new Worker("P45", "B2", 1232.44m, 34),
            new Worker("AAA", "B2PO", 999.67m, 30),
            new Worker("P4fgh5", "Brty2", 500m, 50),
            new Worker("Plkj45", "ERB2", 455.34m, 31),
            new Worker("ADP45", "DDDB2", 1100.34m, 25),
            new Worker("3456P45", "324B2", 666.66m, 66),
            new Worker("TTP45", "XXB2", 333m, 33),
            };
            var workerSort = workerList.OrderByDescending(x => x.MoneyPerHour());
            foreach (var item in workerSort)
            {
                Console.WriteLine("[{0}, {1}, {2:F2}]", item.FirstNameSet, item.LastName, item.MoneyPerHour());
            }
        }
    }
}
