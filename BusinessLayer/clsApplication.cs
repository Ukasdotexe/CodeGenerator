using CodeGenerator.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.BusinessLayer
{
    class clsApplication
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.Update;

        public int ApplicationID { get; set; }
        public string ApplicationNo { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PersonID { get; set; }
        public int ServiceID { get; set; }
        public int? LicenceClassID { get; set; }
        public byte ApplicationStatus { get; set; }

        public clsApplication()
        {
            _Mode = enMode.AddNew;
            ApplicationID = -1;
            ApplicationNo = null;
            ApplicationDate = DateTime.Now;
            PersonID = -1;
            ServiceID = -1;
            LicenceClassID = null;
            ApplicationStatus = 0;
        }
        public clsApplication(int ApplicationID, string ApplicationNo, DateTime ApplicationDate, int PersonID, int ServiceID, int? LicenceClassID, byte ApplicationStatus)
        {
            _Mode = enMode.AddNew;
            this.ApplicationID = ApplicationID;
            this.ApplicationNo = ApplicationNo;
            this.ApplicationDate = ApplicationDate;
            this.PersonID = PersonID;
            this.ServiceID = ServiceID;
            this.LicenceClassID = LicenceClassID;
            this.ApplicationStatus = ApplicationStatus;
        }
        public static clsApplication Find(int ApplicationID)
        {
            string ApplicationNo = null;
            DateTime ApplicationDate = DateTime.Now;
            int PersonID = -1;
            int ServiceID = -1;
            int? LicenceClassID = null;
            byte ApplicationStatus = 0;
            if (ApplicationDataLayer.GetApplicationInfoByApplicationID(ApplicationID, ref ApplicationNo, ref ApplicationDate, ref PersonID, ref ServiceID, ref LicenceClassID, ref ApplicationStatus))
            {
                return new clsApplication(ApplicationID, ApplicationNo, ApplicationDate, PersonID, ServiceID, LicenceClassID, ApplicationStatus);

            }
            return null;
        }
        public static clsApplication Find(string ApplicationNo)
        {
            int ApplicationID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int PersonID = -1;
            int ServiceID = -1;
            int? LicenceClassID = null;
            byte ApplicationStatus = 0;
            if (ApplicationDataLayer.GetApplicationInfoByApplicationNo(ref ApplicationID, ApplicationNo, ref ApplicationDate, ref PersonID, ref ServiceID, ref LicenceClassID, ref ApplicationStatus))
            {
                return new clsApplication(ApplicationID, ApplicationNo, ApplicationDate, PersonID, ServiceID, LicenceClassID, ApplicationStatus);

            }
            return null;
        }
        public bool _AddNewApplication()
        {
            this.ApplicationID = ApplicationDataLayer.AddNewApplication(ApplicationNo, ApplicationDate, PersonID, ServiceID, LicenceClassID, ApplicationStatus);

            return this.ApplicationID != -1;
        }
        public bool _UpdateApplication()
        {
            return ApplicationDataLayer.UpdateApplication(ApplicationID, ApplicationNo, ApplicationDate, PersonID, ServiceID, LicenceClassID, ApplicationStatus);
        }
        public bool save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewApplication())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    return _UpdateApplication();
            }
            return false;
        }
        public static bool Delete(int ApplicationID)
        {
            return ApplicationDataLayer.Delete(ApplicationID);
        }
        public static bool Delete(string ApplicationNo)
        {
            return ApplicationDataLayer.Delete(ApplicationNo);
        }
        public bool IsExist(int ApplicationID)
        {
            return ApplicationDataLayer.IsExist(ApplicationID);
        }
        public bool IsExist(string ApplicationNo)
        {
            return ApplicationDataLayer.IsExist(ApplicationNo);
        }
        public static DataTable GetApplicationsList()
        {
            return ApplicationDataLayer.GetApplicationsList();
        }



    }
}
