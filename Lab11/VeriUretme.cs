using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab11
{
    class VeriUretme
    {
        public static IVeriGetir getFile(string fileName, int choice)
        {

            switch (choice)
            {
                case 1:
                    {
                        if (fileName.Contains(".") && fileName.Split('.')[1].Equals("dat"))
                        {

                            return new GetBinary(fileName);
                        }
                        else throw new FormatException("Invalid Format");
                    }
                case 2:
                    {
                        if (fileName.Contains(".") && fileName.Split('.')[1].Equals("txt"))
                            return new GetTxt(fileName);
                        else throw new FormatException("Invalid Format");
                    }
                default:
                    {
                        throw new FormatException("Invalid Format");
                    }
            }
        }

    }
}
