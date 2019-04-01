using System;
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
    }
}
