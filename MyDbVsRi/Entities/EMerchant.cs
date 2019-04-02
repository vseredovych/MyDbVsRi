using System;
using System.Collections.Generic;
using System.IO;

namespace DAL.Entities
{
    public class Merchant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string CurrentSity { get; set; }

        public Merchant()
        {
        }

        public Merchant(int Id, string FirstName, string LastName, DateTime Dob, string CurrentSity)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Dob = Dob;
            this.CurrentSity = CurrentSity;
        }
        public Object[] GetObjectArray()
        {
            List<Object> objects = new List<object>();
            objects.Add(Id);
            objects.Add(FirstName);
            objects.Add(LastName);
            objects.Add(Dob);
            objects.Add(CurrentSity);

            return objects.ToArray();

        }
        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4}", Id, FirstName, LastName, Dob.ToString(), CurrentSity);
        }
    }
}

