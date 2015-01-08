using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using WebApi.Models;

namespace WebApi
{
    [ServiceContract]
    public interface IContactService
    {
        [OperationContract]
        IList<Contact>GetData();

        [OperationContract]
        CompositeContact GetDataUsingDataContract(CompositeContact composite);

        [OperationContract]
        int SaveData(Contact contact);
    }


    [DataContract]
    public class CompositeContact
    {        
        private int? _id;
        private string _fname;
        private string _lname;
        private string _company;
        private string _region;

        [DataMember]
        public int? Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [DataMember]
        public string Region
        {
            get
            {
                return this._region;
            }
            set
            {
                this._region = value;
            }
        }

        [DataMember]
        public string Company
        {
            get
            {
                return this._company;
            }
            set
            {
                this._company = value;
            }
        }

        [DataMember]
        public string LName
        {
            get
            {
                return this._lname;
            }
            set
            {
                this._lname = value;
            }
        }

        [DataMember]
        public string FName
        {
            get
            {
                return this._fname;
            }
            set
            {
                this._fname = value;
            }
        }
    }
}
