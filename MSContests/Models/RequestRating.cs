using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSContests.Models
{
    public class RequestRating
    {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            
            public int RequestID { get; set; }
            public int Rating { get; set; }
            public int TotalRaters { get; set; }
            public double AverageRating { get; set; }
    }
}