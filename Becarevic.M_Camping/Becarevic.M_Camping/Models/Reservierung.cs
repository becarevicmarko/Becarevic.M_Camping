using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Becarevic.M_Camping.Models
{
    public enum Category
    {
        singletrack, multitrack, notSpecified 
    }
    public class Reservierung
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Street { get; set; }

        public int Phonenumber { get; set; }
        public DateTime Birthdate { get; set; }
        public Category Category { get; set; }


        public Reservierung() : this(0, "", "", "",0,DateTime.MinValue,Category.notSpecified) { }

        public Reservierung(int id, string firsname, string lastname, string street, int phonenumber, DateTime birthdate, Category category)
        {
            this.Id = id;
            this.Firstname = firsname;
            this.Lastname = lastname;
            this.Street = street;
            this.Phonenumber = phonenumber;
            this.birthdate = birthdate;
            this.Category = category;
            
        }
    }
}