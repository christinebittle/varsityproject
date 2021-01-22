using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Varsity_Project.Models
{
    public class Sponsor
    {
        [Key]
        public int SponsorID { get; set; }

        public string SponsorName { get; set; }


        //Utilizes the inverse property to specify the "Many"
        //https://www.entityframeworktutorial.net/code-first/inverseproperty-dataannotations-attribute-in-code-first.aspx
        //One Sponsor Many Teams
        public ICollection<Team> Teams { get; set; }

    }
}