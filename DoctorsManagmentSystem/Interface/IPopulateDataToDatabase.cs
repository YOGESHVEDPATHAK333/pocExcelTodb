using System.Collections.Generic;
using DoctorsManagmentSystem.Models;

namespace DoctorsManagmentSystem.Interface
{
    interface IPopulateDataToDatabase
    {
        void BatchInsertion(List<Doctor> doctors,string tableType);
    }
}
