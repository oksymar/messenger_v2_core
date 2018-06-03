using System;
using System.ComponentModel.DataAnnotations;

namespace messenger_v2_core.Models
{
    public class GlobalMsgModel
    {
        [Key]
        public long Timestamp { get; set; }
        public String Username { get; set; }
        public String Message { get; set; }
    }
}