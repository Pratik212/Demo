using System;
using System.Collections.Generic;

namespace Demo.Models
{
    public class Camp
    {
        public int Id { get; set; }
        public string Moniker { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; }
        public string Description { get; set; }
        public byte[] RowVersion { get;set;}
    }

    
}