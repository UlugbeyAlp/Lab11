using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab11
{
    class OgrenciGorunum
    {
        public void display(string data)
        {
            Console.WriteLine(data);
        }


        public bool WriteBinary(List<Ogrenci> ogrenci)
        {
            BinaryWriter bw;

            ogrenci.Sort(); 
            try
            {
                bw = new BinaryWriter(new FileStream("StudentData.dat", FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot create file.");
                return false;
            }
            
            try
            {
                for (int i = 0; i < ogrenci.Count; i++)
                {
                    bw.Write(ogrenci[i].name);
                    bw.Write(ogrenci[i].surname);
                    bw.Write(ogrenci[i].no.ToString());
                    bw.Write(ogrenci[i].recordTime.ToString());
                    bw.Write(ogrenci[i].departmentName);
                    bw.Write(ogrenci[i].avgGrade.ToString());

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot write to file.");
                return false;
            }
            bw.Close();
            return true;
        }
    }
}
