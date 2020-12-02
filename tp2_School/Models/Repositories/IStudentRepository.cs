﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2_School.Models.Repositories
{
   public interface IStudentRepository

    {
        IList<Student> GetAll();
        Student GetById(int id);
        void Add(Student s);
        void Edit(Student s);
        void Delete(Student s);
        IList<Student> GetStudentsBySchoolID(int? schoolId);
        IList<Student> FindByName(string name);


    }
}
