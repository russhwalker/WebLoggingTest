namespace LoggingTest.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WebLog")]
    public partial class WebLog
    {
        public int WebLogId { get; set; }
        
        [StringLength(1000)]
        public string Url { get; set; }
        
        public string FormData { get; set; }
        
        public string QueryStringData { get; set; }
        
        [StringLength(500)]
        public string UserName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }
        
        [StringLength(500)]
        public string IpAddress { get; set; }
    }
}
