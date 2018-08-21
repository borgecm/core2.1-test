﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Interfaces;
using Test2.Models;

namespace Test2.Repositories
{
    public class InterviewRepository : Repository<Interview>, IInterview
    {
        public InterviewRepository(recruitment_testContext context) : base(context)
        {

        }
    }
}
