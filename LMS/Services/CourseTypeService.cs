using LMS.Data;
using LMS.Models;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Services
{
    public class CourseTypeService
    {
     
        LMSDbContext context = new LMSDbContext();
        public void AddCourseType(CourseType courseType)
        {
            context.courseTypes.Add(courseType);
            context.SaveChanges();
        }

        public CourseType GetBankByCode(string strTypeCode)
        {
            return context.courseTypes.Where(a => a.TypeCode.Equals(strTypeCode)).FirstOrDefault();
        }

        public void UpdateBank(CourseType courseType)
        {
            context.Entry(courseType).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteBank(CourseType courseType)
        {
            this.context.Remove(courseType);
            context.SaveChanges();
        }

        public DataTable GetAllActiveBanksDataTable()
        {
            DataTable tbl = new DataTable();
            var query = from a in context.courseTypes select new { a.Name,a.TypeCode, a.Status };
            return tbl = query.ToDataTable();
        }

    }
}
