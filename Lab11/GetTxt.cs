using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab11
{
    class GetTxt:IVeriGetir
    {
        private string fileName;

        public GetTxt(string fileName)
        {
            this.fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }

        public string getVeri()
        {

            return File.ReadAllText(fileName, Encoding.UTF8);
        }
    }
}
