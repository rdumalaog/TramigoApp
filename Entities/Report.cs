using System;

namespace API.Entities
{
    public class Report
    {
        public int ID { get; set; }
        public int Device_ID { get; set; }
        public string Location { get; set; }
        public DateTime DateCreated { get; set;}
    }
}