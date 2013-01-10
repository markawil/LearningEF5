﻿using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Domain;

namespace LearningEF5.DataLayer
{
   public class PersonRepository : Repository<Person>
   {
      public override int Save(Person person)
      {
         DbEntityValidationResult validationResult = _context.Entry(person).GetValidationResult();
         if (validationResult.IsValid == false)
         {
            Debugger.Break();
         }
            
         if (person.Id == 0)
         {
            _context.Entry(person).State = EntityState.Added;

            foreach (var personSession in person.Sessions)
            {
               if (personSession.Session.Id > 0)
               {
                  _context.Entry(personSession.Session).State = EntityState.Unchanged;
               }
            }
         }
         else
            _context.Entry(person).State = EntityState.Modified;

         _context.SaveChanges();
         return person.Id;
      }
   }
}