using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2_School.Models.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        StudentContext Context;
        public StudentRepository(StudentContext context)
        {
            this.Context = context;
        }
        public void Add(Student s)
        {
            Context.Students.Add(s);
            Context.SaveChanges();
        }

        public void Delete(Student s)
        {
           Student st1 = Context.Students.Find(s.StudentId);
            if (st1 != null)
            {
                Context.Students.Remove(st1);
                 Context.SaveChanges();
            }
        }

        public void Edit(Student newstudent)
        {
            Student oldstudent = Context.Students.Find(newstudent.StudentId);
            if (oldstudent != null)
            {
                oldstudent.StudentName = newstudent.StudentName;
                oldstudent.Age = newstudent.Age;
                oldstudent.BirthDate = newstudent.BirthDate;
                oldstudent.SchoolID = newstudent.SchoolID;
                Context.SaveChanges();
            }

        }

        public IList<Student> FindByName(string name)
        {
            return Context.Students.Where(s => s.StudentName.Contains(name)).Include(std =>std.School).ToList();
        }

        public IList<Student> GetAll()
        {
            return Context.Students.Include(x => x.School).ToList();
        }

        public Student GetById(int id)
        {
            return Context.Students.Where(x=>x.StudentId==id).Include(x => x.School).SingleOrDefault();
            
        }

        public IList<Student> GetStudentsBySchoolID(int? schoolId)
        {
            return Context.Students.Where(s => s.SchoolID.Equals(schoolId))
                .OrderBy(s => s.StudentName)
                .Include(std => std.School).ToList();
        }
    }
}
