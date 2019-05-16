using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    class OgrenciKontrolcusu
    {
        public Ogrenci modelInstance { get; set; }

        public OgrenciGorunum viewInstance { get; set; }

        public OgrenciKontrolcusu(Ogrenci modelInstance, OgrenciGorunum viewInstance)
        {
            this.modelInstance = modelInstance ?? throw new ArgumentNullException(nameof(modelInstance));
            this.viewInstance = viewInstance ?? throw new ArgumentNullException(nameof(viewInstance));
        }

        public void changeName(string newName) => modelInstance.name = newName ?? modelInstance.name;
        public void changeSurname(string newSurname) => modelInstance.name = newSurname ?? modelInstance.surname;
        public void changeRecordTime(DateTime newRecordTime) => modelInstance.recordTime = (newRecordTime != null) ? newRecordTime : modelInstance.recordTime;
        public void changeAvgGrade(double newAvgGrade) => modelInstance.avgGrade = (newAvgGrade > 0) ? newAvgGrade : modelInstance.avgGrade;
        public void changeNo(int newNo) => modelInstance.no = (newNo > 0) ? newNo : modelInstance.no;
        public void changeDepartmentName(string newDepartmentName) => modelInstance.departmentName = newDepartmentName ?? modelInstance.departmentName;

        private string getStudentInfo() { return modelInstance.ToString(); }
        public void display() => viewInstance.display(getStudentInfo());
        public bool writeBinary(List<Ogrenci> data) { return viewInstance.WriteBinary(data); }
    }
}
