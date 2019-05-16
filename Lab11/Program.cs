using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ogrenci> model = new List<Ogrenci>(10);
            Ogrenci hasMaxNo;

            hasMaxNo = readFile(out model);

            OgrenciGorunum view = new OgrenciGorunum();
            OgrenciKontrolcusu controller = new OgrenciKontrolcusu(hasMaxNo, view);

            controller.viewInstance.WriteBinary(model); 
            
            controller.display();
            controller.changeName("Ulugbey");
            controller.changeNo(-64946664);
            controller.changeAvgGrade(2.99);
            controller.display();

            try
            {
                Console.WriteLine(VeriUretme.getFile("MyStdData.txt", 2).getVeri()); //succesfuly
                Console.WriteLine(VeriUretme.getFile("StudentData.dat", 1).getVeri()); //succesfuly

                Console.WriteLine(VeriUretme.getFile("MyStdData.txt", 1).getVeri()); // fail throw Format exception cause 1 - get binary file
                Console.WriteLine(VeriUretme.getFile("StudentData.dat", 2).getVeri()); //fail throw Format exception cause  2 - get txt file
                Console.WriteLine(VeriUretme.getFile("MyStdData", 1).getVeri()); // fail not found file
                Console.WriteLine(VeriUretme.getFile("sadasdas.sadasdasd", -11).getVeri()); // fail Invalid format


            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }


        public static Ogrenci readFile(out List<Ogrenci> data)
        {
            List<Ogrenci> readedData = new List<Ogrenci>(10);
            string[] allLines = File.ReadAllLines("MyStdData.txt", Encoding.UTF8);
            for (int i = 0; i < allLines.Length; i++)
            {
                if (i % 6 == 0) readedData.Add(new Ogrenci());

                switch (i % 6)
                {
                    case 0:
                        {
                            readedData.Last().name = allLines[(i % 6) + ((readedData.Count - 1) * 6)];
                            break;
                        }
                    case 1:
                        {
                            readedData.Last().surname = allLines[(i % 6) + ((readedData.Count - 1) * 6)];
                            break;
                        }
                    case 2:
                        {
                            readedData.Last().no = Convert.ToInt32(allLines[(i % 6) + ((readedData.Count - 1) * 6)]);
                            break;
                        }
                    case 3:
                        {
                            CultureInfo provider = CultureInfo.InvariantCulture;
                            string dateString = allLines[((i % 6) + ((readedData.Count - 1) * 6))];
                            DateTime dateTime;
                            bool isSuccess6 = DateTime.TryParseExact(dateString, new string[] { "MM/dd/yyyy", "MM-dd-yyyy", "MM.dd.yyyy" }, provider, DateTimeStyles.None, out dateTime);
                            readedData.Last().recordTime = dateTime;

                            break;
                        }
                    case 4:
                        {
                            readedData.Last().departmentName = allLines[(i % 6) + ((readedData.Count - 1) * 6)];
                            break;
                        }
                    case 5:
                        {
                            readedData.Last().avgGrade = Convert.ToDouble(allLines[(i % 6) + ((readedData.Count - 1) * 6)]);
                            break;
                        }
                }

            }
            readedData.Sort();
            data = readedData;
            return readedData.Last();
        }
    }
}
