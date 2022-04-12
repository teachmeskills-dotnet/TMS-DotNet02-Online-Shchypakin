using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto
{
    public class MembershypHistoryRecordsDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int MembershipId { get; set; }
    }
}
