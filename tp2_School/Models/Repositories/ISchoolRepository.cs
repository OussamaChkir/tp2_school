using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2_School.Models.Repositories
{
    interface ISchoolRepository
    {
        IList<School> GetAll();
        School GetById(int id);
        void Add(School s);
        void Edit(School s);
        void Delete(School s);
        double StudentAgeAverage(int schoolId);
        int StudentCount(int schoolId);

    }
}
