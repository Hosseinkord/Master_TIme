using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Pr_UniContext:DbContext
    {
       public  DbSet<Master> Masters { get; set; }
       public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<MasterDate> MasterDates { get; set; }
        public DbSet<MasterLesson> MasterLessons { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<Help2> Help2s { get; set; }

        public DbSet<Enter> Enters { get; set; }
        public DbSet<Cal_End> Cal_Ends { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Labratoryy> Labrators { get; set; }
        public DbSet<LEHe>  LEHes { get; set; }
        public DbSet<MAHe> MAHes { get; set; }

    }
}
