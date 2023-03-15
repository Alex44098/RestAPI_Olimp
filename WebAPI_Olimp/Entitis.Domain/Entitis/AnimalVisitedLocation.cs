using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entitis
{
    public class AnimalVisitedLocation
    {
        public long id {  get; set; }
        public long locationPointId { get; set; }
        public DateTime dateTimeOfVisitLocationPoint { get; set; }

    }
}
