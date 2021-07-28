using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTravel.Infrastructure.ExternalServices.Models
{
    public class Hotel2
    {
        public int Id { get; set; }
        public string stateName { get; set; }
        public List<Hotel2Cities> Cities { get; set; }
    }
}
