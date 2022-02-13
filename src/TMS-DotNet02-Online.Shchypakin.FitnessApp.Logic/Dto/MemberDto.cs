﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Dto
{
    public class MemberDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime Birthday { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public ICollection<MembershipDto> Memberships { get; set; }
    }
}
