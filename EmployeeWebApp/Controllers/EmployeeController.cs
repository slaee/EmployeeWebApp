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
            try
            {
                var employees = _context.Employees.ToList();
                return View(employees);
            }
            catch
            {
                ViewBag.Message = "Something went wrong. Please try again.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreationDto employee)
        {
            try
            {
                var existingEmployee = _context.Employees.FirstOrDefault(e => e.FirstName == employee.FirstName && e.LastName == employee.LastName);

                if (existingEmployee != null)
                {
                    ViewBag.Message = "Employee with the same first name and last name already exists.";
                }
                else
                {
                    _context.spEmployee_CreateEmployee(employee.FirstName, employee.LastName, employee.Birthdate, employee.ContactNo, employee.EmailAddress);
                    
                    ViewBag.Message = "New employee created.";
                }

                return View();
            }
            catch
            {
                ViewBag.Message = "Something went wrong. Please try again.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
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
            catch
            {
                ViewBag.Message = "Something went wrong. Please try again.";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeUpdationDto employee)
        {
            try
            {
                var employeeToUpdate = _context.Employees.Where(e => e.ID == employee.ID).FirstOrDefault();
                employeeToUpdate.ContactNo = employee.ContactNo;
                employeeToUpdate.EmailAddress = employee.EmailAddress;
                _context.SaveChanges();

                ViewBag.Message = "Employee updated successfully";
                return View();
            }
            catch
            {
                ViewBag.Message = "Something went wrong. Please try again.";
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var employee = _context.Employees.Where(e => e.ID == id).FirstOrDefault();
                return View(employee);
            }
            catch
            {
                ViewBag.Message = "Something went wrong. Please try again.";
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            { 
                var employee = _context.Employees.Where(e => e.ID == id).FirstOrDefault();
                _context.Employees.Remove(employee);
                _context.SaveChanges();

                ViewBag.Message = "Employee deleted successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Something went wrong. Please try again.";
                return View();
            }
        }
    }
}