using EmployeeWebApp.DTOs;
using EmployeeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDBEntities _context = new EmployeeDBEntities();
        
        public ActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreationDto employee)
        {
            // use the stored proc
            _context.spEmployee_CreateEmployee(employee.FirstName, employee.LastName, employee.Birthdate, employee.ContactNo, employee.EmailAddress);

            ViewBag.Message = "Employee created successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.Where(e => e.ID == id).FirstOrDefault();

            var employeeUpdation = new EmployeeUpdationDto
            {
                ID = employee.ID,
                ContactNo = employee.ContactNo,
                EmailAddress = employee.EmailAddress
            };
            return View(employeeUpdation);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeUpdationDto employee)
        {
            var employeeToUpdate = _context.Employees.Where(e => e.ID == employee.ID).FirstOrDefault();
            employeeToUpdate.ContactNo = employee.ContactNo;
            employeeToUpdate.EmailAddress = employee.EmailAddress;
            _context.SaveChanges();

            ViewBag.Message = "Employee updated successfully";
            return View();
        }

        public ActionResult Details(int id)
        {
            var employee = _context.Employees.Where(e => e.ID == id).FirstOrDefault();
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            var employee = _context.Employees.Where(e => e.ID == id).FirstOrDefault();
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            ViewBag.Message = "Employee deleted successfully";
            return RedirectToAction("Index");
        }
    }
}