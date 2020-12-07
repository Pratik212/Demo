using System;
using System.Collections.Generic;

namespace Demo.Models
{
    /// <summary>
    /// Camp
    /// </summary>
    public class Camp
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Moniker
        /// </summary>
        public string Moniker { get; set; }
        
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// EventDate
        /// </summary>
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        
        /// <summary>
        /// Length
        /// </summary>
        public int Length { get; set; }
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// RowVersion
        /// </summary>
        public byte[] RowVersion { get;set;}
    }

    
}