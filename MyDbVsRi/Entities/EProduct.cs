using System;
using System.Collections.Generic;
using System.IO;

namespace DAL.Entities
{
    public class Product : Entity
    {
        public static readonly string TableName = "Products";
        public static readonly string[] TableColumns = { "Id", "Name", "Price", "Status", "MerchantId", "CreatedAt" };


        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public int MerchantId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Product()
        {

        }
        public Product(int Id, string Name, double Price, string Status, int MerchantId, DateTime CreatedAt)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Status = Status;
            this.MerchantId = MerchantId;
            this.CreatedAt = CreatedAt;
        }
        public Object[] GetObjectArray()
        {
            List<Object> objects = new List<object>();
            objects.Add(Id);
            objects.Add(Name);
            objects.Add(Price);
            objects.Add(Status);
            objects.Add(MerchantId);
            objects.Add(CreatedAt);

            return objects.ToArray();
        }
        public string GetTableName()
        {
            return TableName;
        }
        public string[] GetTableColumns()
        {
            return TableColumns;
        }
    }
}