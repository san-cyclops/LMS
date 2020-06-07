using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LMS.Data;
using LMS.Models;
using LMS.Services;
using Microsoft.AspNetCore.Mvc;
using MoreLinq;
using Newtonsoft.Json;

namespace LMS.Controllers
{
    public class DataController : Controller
    {
        LMSDbContext _context = new LMSDbContext();
        public IActionResult Index()
        {
            return View();
        } 
         

        [HttpPost]
        public string Save(string strJson,string type)
        {
            if (type == "CourseType")
            {
                CourseType obj = JsonConvert.DeserializeObject<CourseType>(strJson);
                GenericRepository<CourseType> genericRepository = new GenericRepository<CourseType>(_context);
                genericRepository.Insert(obj);
                return "True";
            }

            return "false";
        }

        [HttpPost]
        public string Update(string strJson,int id, string type)
        {
            if (type == "CourseType")
            {
                CourseType obj = JsonConvert.DeserializeObject<CourseType>(strJson);
                obj.CourseTypeID = id;
                GenericRepository<CourseType> genericRepository = new GenericRepository<CourseType>(_context);
                genericRepository.Update(obj);
                return "True";
            }
            return "false";
        }

        [HttpPost]
        public string Delete(string strJson, int id, string type)
        {
            if (type == "CourseType")
            {
                CourseType obj = JsonConvert.DeserializeObject<CourseType>(strJson);
                obj.IsDelete = true;
                obj.CourseTypeID = id;
                GenericRepository<CourseType> genericRepository = new GenericRepository<CourseType>(_context);
                genericRepository.Delete(obj);
                return "True";
            }
            return "false";
        }
        public string GetAll(string type)
        {
            if (type == "CourseType")
            {
                DataTable tbl = new DataTable();
                var query = from a in _context.courseTypes where a.IsDelete == false select new { ID = a.CourseTypeID , a.Name, a.TypeCode, a.Status };
                string result = JsonConvert.SerializeObject(query.ToDataTable(), Newtonsoft.Json.Formatting.None);
                return result;
            }

            return "false";
        }


    }
}