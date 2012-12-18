﻿using System.Data.Entity;
using System.Linq;
using Domain;

namespace LearningEF5.DataLayer
{
   public class ConferencesContext : DbContext
   {
      public DbSet<Person> Persons { get; set; }
      public DbSet<Session> Sessions { get; set; }
      public DbSet<Workshop> Workshops { get; set; }
   }
}