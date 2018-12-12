using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCWeb.Models;
using ProjectVIS.DataLayer.DataMapper;
using ProjectVIS.Models;

namespace MVCWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult AutomatickeVytvoreni(string SPZ, int speed, bool isInCity)
        {
            Vehicle vehicle = VehicleDataMapper.FindBySPZ(SPZ);
            if (vehicle == null) return RedirectToAction("Index", "Home");
            Driver driver = DriverDataMapper.FindByID(vehicle.driverID);

            Record record = new Record();
            record.Ammount = 0;
            record.DateOfEntry = DateTime.Now;
            record.PaidDate = null;
            record.ExpireDate = record.DateOfEntry.AddDays(30);
            record.driverID = driver.ID;
            record.PointsTaken = 0;
            record.employeeID = 1;
            record.fineTypeID = 6;


            if (speed < 10 && isInCity == true)
            {
                record.Ammount = 500;
                record.PointsTaken = 0;
            }
            else if (speed >= 10 && speed < 30 && isInCity == true)
            {
                record.Ammount = 2000;
                record.PointsTaken = 1;
            }
            else if (speed >= 30 && isInCity == true)
            {
                record.Ammount = 5000;
                record.PointsTaken = 3;
            }
            else if (speed < 10 && isInCity == false)
            {
                record.Ammount = 500;
                record.PointsTaken = 0;
            }
            else if (speed >= 10 && speed < 30 && isInCity == false)
            {
                record.Ammount = 2000;
                record.PointsTaken = 2;
            }
            else if (speed >= 30 && isInCity == false)
            {
                record.Ammount = 5000;
                record.PointsTaken = 4;
            }


            RecordDataMapper.Save(record);

            driver.RemainingPoints -= record.PointsTaken;
            if(driver.RemainingPoints <= 0)
            {
                driver.State = false;
                ViewBag.driverState = false;
            }

            DriverDataMapper.Update(driver);

            return RedirectToAction("Login", "Home");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(int login, string password)
        {
            Driver selectedDriver = DriverDataMapper.FindByLicenseNumber(login);

            if (selectedDriver == null)
            {
                Employee employee = EmployeeDataMapper.FindByID(login);
                if (employee == null)
                {
                    ModelState.AddModelError("Login", "User not found in DB");
                }
                else if (employee.Password != password)
                {
                    ModelState.AddModelError("Password", "Wrong password");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        HttpContext.Session.SetString("user", employee.ID.ToString());
                        HttpContext.Session.SetString("userType", "employee");
                        return RedirectToAction("EmployeeInterface", "Home");
                    }
                }
            }
            else if (selectedDriver.Password != password)
            {
                ModelState.AddModelError("Password", "Wrong password");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    HttpContext.Session.SetString("user", selectedDriver.ID.ToString());
                    HttpContext.Session.SetString("userType", "driver");
                    return RedirectToAction("DriverInterface", "Home");
                }
            }
            
            return View();
        }


        public IActionResult EmployeeInterface()
        {
            if (HttpContext.Session.GetString("userType") != "employee")
            {
                return RedirectToAction("Error");
            }
            
            return View();
        }

        
        public IActionResult DriverInterface()
        {
            if(HttpContext.Session.GetString("userType") != "driver")
            {
                return RedirectToAction("Error");
            }

            int loggedUser = Int32.Parse(HttpContext.Session.GetString("user"));

            List<Record> recordsList = RecordDataMapper.FindAllByID(loggedUser);

            ViewBag.recordsList = recordsList;

            
            return View();
        }



        public IActionResult Payment(int ID)
        {
            Record record = RecordDataMapper.FindByID(ID);

            ViewBag.record = record;

            return View();
        }

        [HttpPost]
        public IActionResult Pay(int ID, int number, int CSV)
        {
            Record record = RecordDataMapper.FindByID(ID);
            
            //pseudo validace karty...
            Random rnd = new Random();
            int value = rnd.Next(10);
            if (value < 5)
            {
                //uspesna platba - pridat PaidDate do Record
                record.PaidDate = DateTime.Now;
                RecordDataMapper.Update(record);

                return RedirectToAction("DriverInterface", "Home");
            }
            else
            {
                //neuspesna platba
                ModelState.AddModelError("Ammount", "Platba se nezdarila");
            }
            
            return RedirectToAction("Payment", "Home", new { ID = record.ID });
        }





        [HttpPost]
        public IActionResult AutomatickeVytvoreniXML(string SPZ, int speed, bool isInCity)
        {
            VehicleDataMapper.LoadXMLDocument("../XML/Vehicle.xml");
            DriverDataMapper.LoadXMLDocument("../XML/Driver.xml");
            RecordDataMapper.LoadXMLDocument("../XML/Record.xml");


            Vehicle vehicle = VehicleDataMapper.XMLSelect(SPZ);
            if (vehicle == null) return RedirectToAction("Index", "Home");
            Driver driver = DriverDataMapper.XMLSelect(vehicle.driverID);
            if (driver == null) return RedirectToAction("Index", "Home");

            Record record = new Record();
            record.Ammount = 0;
            record.DateOfEntry = DateTime.Now;
            record.PaidDate = null;
            record.ExpireDate = record.DateOfEntry.AddDays(30);
            record.driverID = driver.ID;
            record.PointsTaken = 0;
            record.employeeID = 1;
            record.fineTypeID = 6;


            if (speed < 10 && isInCity == true)
            {
                record.Ammount = 500;
                record.PointsTaken = 0;
            }
            else if (speed >= 10 && speed < 30 && isInCity == true)
            {
                record.Ammount = 2000;
                record.PointsTaken = 1;
            }
            else if (speed >= 30 && isInCity == true)
            {
                record.Ammount = 5000;
                record.PointsTaken = 3;
            }
            else if (speed < 10 && isInCity == false)
            {
                record.Ammount = 500;
                record.PointsTaken = 0;
            }
            else if (speed >= 10 && speed < 30 && isInCity == false)
            {
                record.Ammount = 2000;
                record.PointsTaken = 2;
            }
            else if (speed >= 30 && isInCity == false)
            {
                record.Ammount = 5000;
                record.PointsTaken = 4;
            }


            RecordDataMapper.XMLInsert(record);

            driver.RemainingPoints -= record.PointsTaken;
            if (driver.RemainingPoints <= 0)
            {
                driver.State = false;
                ViewBag.driverState = false;
            }

            DriverDataMapper.XMLUpdate(driver);

            return RedirectToAction("Login", "Home");
        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
