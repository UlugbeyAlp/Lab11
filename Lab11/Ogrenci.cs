using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab11
{
    class Ogrenci:IComparable
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int no { get; set; }
        public DateTime recordTime { get; set; }
        public string departmentName { get; set; }
        public double avgGrade { get; set; }

        public Ogrenci(string name, string surname, int no, DateTime recordTime, string departmentName, double avgGrade)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.surname = surname ?? throw new ArgumentNullException(nameof(surname));
            if (no > 0) { this.no = no; }
            else { this.no = -1 * no; }

            this.recordTime = recordTime;
            this.departmentName = departmentName ?? throw new ArgumentNullException(nameof(departmentName));
            if (avgGrade >= 0 && avgGrade <= 4.0)
                this.avgGrade = avgGrade;
            else this.avgGrade = 0.0;
        }

        public Ogrenci()
        {
        }
        
        public override string ToString()
        {
            return $"Name : {name}\nSurname : {surname}\nNo : {no}\nRecord Time : {recordTime.ToString("MM/dd/yyyy")}\nDepartment Name : {departmentName}\nAverage Grade : \n";

        }

        public int CompareTo(object obj)
        {
            return no.CompareTo((obj as Ogrenci).no);
        }
    }
}
