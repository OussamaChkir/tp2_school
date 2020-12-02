using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2_School.Models.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly  StudentContext context;
        public SchoolRepository(StudentContext context)
        {
            this.context = context;
        }
        public void Add(School s)
        {
            context.Schools.Add(s);
            context.SaveChanges();
        }

        public void Delete(School s)
        {
            //School s1 = context.Schools.Where(x => x.SchoolID == s.SchoolID).SingleOrDefault();
            School s1 = context.Schools.Find(s.SchoolID);
            if (s1 != null)
            {
                context.Schools.Remove(s1);
                context.SaveChanges();
            }

        }

        public void Edit(School s)
        {
            School s1 = context.Schools.Find(s.SchoolID);
            if (s1 != null)
            {
                s1.SchoolName = s.SchoolName;
                s1.SchoolAdress = s.SchoolAdress;
                context.SaveChanges();

            }

        }

        public IList<School> GetAll()
        {
            return context.Schools.ToList();

        }

        public School GetById(int id)
        {
            return context.Schools.Find(id);
        }

        public double StudentAgeAverage(int schoolId)
        {
            if (StudentCount(schoolId) == 0)
            {
                return 0;
            }
            else
            {
                return context.Students.Where(s => s.SchoolID == schoolId).Average(e => e.Age);
            }
        }

        public int StudentCount(int schoolId)
        {
            return context.Students.Where(s => s.SchoolID == schoolId).Count();
        }
    }
}
