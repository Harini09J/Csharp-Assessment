using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Program2 : Controller
    {
        public ViewResult Display()
        {
            var context = new DatabaseEntities1();
            var model = context.Employee.ToList();
            return View(model);
        }
        public ActionResult Find(string id)
        {
            int EmpId = int.Parse(id);
            var context = new DatabaseEntities1();
            var model = context.Employee.FirstOrDefault((e) => e.EmpId == EmpId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Find(Employee emp)
        {
            var context = new DatabaseEntities1();
            var model = context.Employee.FirstOrDefault((e) => e.EmpId == emp.EmpId);
            model.EmpName = emp.EmpName;
            model.EmpAddress = emp.EmpAddress;
            model.EmpSalary = emp.EmpSalary;
            context.SaveChanges();
            return RedirectToAction("Display");
        }
        public ViewResult AddEmployee()
        {
            var model = new Employee();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            var context = new DatabaseEntities1();
            context.Employee.Add(emp);
            context.SaveChanges();
            return RedirectToAction("Display");
        }
        public ActionResult DeleteEmployee(string id)
        {
            int EmpId = int.Parse(id);
            var context = new DatabaseEntities1();
            var model = context.Employee.FirstOrDefault((e) => e.EmpId == EmpId);
            context.Employee.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Display");
        }
    }
}