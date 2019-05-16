using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab11
{
    class GetBinary : IVeriGetir
    {
        private string fileName;

        public GetBinary(string fileName)
        {
            this.fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }

        public string getVeri()
        {
            string data = "";
            using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length) data += reader.ReadString() + "\n";
            }

            return data;
        }
    }
}
