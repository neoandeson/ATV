using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisment.ViewModel
{
    public class CostRuleViewModel
    {
        public int Id { get; set; }

        public int TimeSlotId { get; set; }

        public int Length { get; set; }

        public string Price { get; set; }
    }
}
