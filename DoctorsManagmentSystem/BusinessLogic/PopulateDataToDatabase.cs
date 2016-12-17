using System.Collections.Generic;
using System.Linq;
using DoctorsManagmentSystem.Interface;
using DoctorsManagmentSystem.Models;

namespace DoctorsManagmentSystem.BusinessLogic
{
    public class PopulateDataToDatabase : IPopulateDataToDatabase
    {
        private Models.DoctorsManagementSystemEntities db;

        public PopulateDataToDatabase(DoctorsManagementSystemEntities db)
        {
            // TODO: Complete member initialization
            this.db = db;
        }
        public void BatchInsertion(List<Doctor> doctors, string tableTable)
        {
            switch (tableTable.ToLower())
            {
                case "doctor":
                    db.Doctors.AddRange(doctors);
                    break;
                    
            }
            db.SaveChanges();
        }
    }
}