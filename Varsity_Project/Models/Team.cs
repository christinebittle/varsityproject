using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Varsity_Project.Models
{
    public class Team
    {
        public int TeamID { get; set; }

        public string TeamName { get; set; }

        public string TeamBio { get; set; }

        //A team can have many players
        public ICollection<Player> Players { get; set; }

        //A team can have many sponsors
        public ICollection<Sponsor> Sponsors { get; set; }
    }
}