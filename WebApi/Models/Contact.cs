using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [Table(Name = "Contacts")]
    public class Contact
    {
        private int _id;
        private string _fname;
        private string _lname;
        private string _company;
        private string _region;

        [Column(Storage = "_id", IsPrimaryKey=true, IsDbGenerated=true)]
        public int Id
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

        [Column(Storage = "_region")]
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

        [Column(Storage = "_company")]
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

        [Column(Storage = "_lname")]
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

        [Column(Storage = "_fname")]
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