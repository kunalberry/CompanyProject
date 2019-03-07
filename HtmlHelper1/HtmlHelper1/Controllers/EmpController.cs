using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HtmlHelper1.Models;
using GridMvc;
using System.Data.SqlClient;
using System.Data;
using HtmlHelper1.Database;

namespace HtmlHelper1.Controllers
{
    public class EmpController : Controller
    {
        private SqlConnection conn = new SqlConnection("Server=DOTNET22\\SQLEXPRESS; Database = Employee;User ID=sa; Password=Sql@123456");

        //public string name;
        //public string dateOfBirth;
        //public string phone;
        //public string email;
        //public string department;
        //public string address;
        //public string state;
        //public string city;
        //public string zipcode;
        //public string dateOfJoining;



        public ActionResult EmployeeDetails()
        {
            ViewBag.states = GetStates();
            ViewBag.citys = GetCity();
            ViewBag.departments = GetDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeDetails(Employee model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //TempData["name"] = model.Name;
            //TempData["dateOfBirth"] = String.Format("{0:M/d/yyyy}", model.Dateofbirth);
            //TempData["email"] = model.Email;
            //TempData["department"] = model.Department;
            //TempData["address"] = model.Address;
            //TempData["state"] = model.States;
            //TempData["city"] = model.City;
            //TempData["zipcode"] = model.Zip;
            //TempData["dateOfJoining"] = String.Format("{0:M/d/yyyy}", model.Dateofjoin);

            //name = model.Name;
            //dateOfBirth = String.Format("{0:M/d/yyyy}", model.Dateofbirth);
            //department = model.Department;
            //address = model.Address;
            //state = model.States;
            //city = model.City;
            //zipcode= model.Zip;
            //dateOfJoining = String.Format("{0:M/d/yyyy}", model.Dateofjoin);
            //email = model.Email;

            //ViewBag.Name = model.Name;
            //ViewBag.dateOfBirth = String.Format("{0:M/d/yyyy}",model.Dateofbirth);
            //ViewBag.email = model.Email;
            //ViewBag.department = model.Department;
            //ViewBag.address = model.Address;
            //ViewBag.state = model.States;
            //ViewBag.city = model.City;
            //ViewBag.zipcode = model.Zip;
            //ViewBag.dateOFJoining = String.Format("{0:M/d/yyyy}", model.Dateofjoin);

            //TempData["data"] = model;

            database db = new database();
            string s = "insert into dbo.EmployeeDetailss(Names,DateOfBirth,Phone,Email,Department,Addresss,States,City,Zipcode,DateOfJoin) Values (@name,@dateOfBirth,@phone,@email,@department,@address,@states,@city,@zipCode,@dateOfJoin) ";
            db.insert(s,model);

            //  return View(model1);

            return RedirectToAction("AddEmployee");

        }
        public ActionResult AddEmployee()
        {
           string form = "Select * From EmployeeDetailss";
            var modelList = new List<Employee>();

            database ob = new database();

           modelList = ob.select(form);

            
           return View(modelList);
          
           
        }


        //var model1 = (Employee)TempData["data"];
        //    return View(model1);


        public IEnumerable<SelectListItem> GetStates()
        {
            List<SelectListItem> states = new List<SelectListItem>();
            string query = "select * from dbo.States";
            database ob2 = new database();
            return ob2.dbState(query);
        }
        public IEnumerable<SelectListItem> GetCity()
        {
            List<SelectListItem> citys = new List<SelectListItem>();
            string query = "select * from dbo.Citys";
            database ob2 = new database();
            return ob2.dbCity(query);
       

        }
        public IEnumerable<SelectListItem> GetDepartment()
        {
            List<SelectListItem> citys = new List<SelectListItem>();
            string query = "select * from dbo.Department";
            database ob2 = new database();
            return ob2.dbDepartment(query);

        }
        public ActionResult GridView()
        {
            var modelList = new List<Employee>();
                 SqlConnection con = null;
           SqlCommand com = null;

            try
            {
                string createConnection = "SERVER=DOTNET22\\SQLEXPRESS; DATABASE= Employee;User ID=sa; Password=Sql@123456";//connection string
                con = new SqlConnection(createConnection);
                com = new SqlCommand("select * from dbo.EmployeeDetailss", con);
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
              while (dr.Read())
             {
                    var emp = new Employee();
                   emp.Name = dr["Names"].ToString();
                    emp.Dateofbirth = dr["DateOfBirth"].ToString();
                    emp.Phone = dr["Phone"].ToString();
                    emp.Email = dr["Email"].ToString();
                   emp.Department = dr["Department"].ToString();
                    emp.Address = dr["Addresss"].ToString();
                  emp.States = dr["States"].ToString();
                    emp.City = dr["City"].ToString();
                    emp.Zip = dr["ZipCode"].ToString();
                    emp.Dateofjoin = dr["DateoFJoin"].ToString();
                    modelList.Add(emp);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
           }
        // Closing the connection  
           finally
            {
                con.Close();
            }
            // return View();
                  return View(modelList);
        }
        public ActionResult EditViewGrid()
        {

            string form = "Select * From EmployeeDetailss";
            var modelList = new List<Employee>();

            database ob = new database();

            modelList = ob.select(form);

            return View(modelList);


        }
        public ActionResult EditEmployee(string id)
        {

            string form = "Select * From EmployeeDetailss where empId = " + id;
           // var modelList = new List<Employee>();

            database ob = new database();
            var modelList = new List<Employee>();
            modelList = ob.select(form);

           Employee dataModel = new Employee();

            ViewBag.states = GetStates();
            ViewBag.citys = GetCity();
            ViewBag.departments = GetDepartment();


            dataModel.Name = modelList[0].Name;
            dataModel.Dateofbirth=  modelList[0].Dateofbirth;
            dataModel.Phone = modelList[0].Phone;
            dataModel.Email = modelList[0].Email;
            dataModel.Department = modelList[0].Department;
            dataModel.Address = modelList[0].Address;
            dataModel.States = modelList[0].States;
            dataModel.City = modelList[0].City;
            dataModel.Zip = modelList[0].Zip;
            dataModel.Dateofjoin = modelList[0].Dateofjoin;
                                                      
           
           return View(dataModel);
        }
        [HttpPost]
        public ActionResult EditEmployee(string id, Employee model)
        {
             ViewBag.states = GetStates();
            ViewBag.citys = GetCity();
            ViewBag.departments = GetDepartment();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           

            database db = new database();
         //   string s = "insert into dbo.EmployeeDetailss(Names,DateOfBirth,Phone,Email,Department,Addresss,States,City,Zipcode,DateOfJoin) Values (@name,@dateOfBirth,@phone,@email,@department,@address,@states,@city,@zipCode,@dateOfJoin) ";
            string ore = "UPDATE dbo.EmployeeDetailss Set Names = @name, DateOfBirth = @dateOfBirth, Phone = @phone, Email = @email, Department = @department, Addresss = @address, States = @states, City = @city, Zipcode = @zipCode, DateOfJoin = @dateOfJoin  where empId = " + id; 
            //string ore = "UPDATE dbo.EmployeeDetailss empId = " + id;
            //string form = "select * from dbo.EmployeeDetailss ";

            db.update(ore ,model);
            //db.select(form);

            return RedirectToAction("AddEmployee");
        }
        public ActionResult Delete(string id)
        {
           


            database db = new database();
            //   string s = "insert into dbo.EmployeeDetailss(Names,DateOfBirth,Phone,Email,Department,Addresss,States,City,Zipcode,DateOfJoin) Values (@name,@dateOfBirth,@phone,@email,@department,@address,@states,@city,@zipCode,@dateOfJoin) ";
           // string ore = "UPDATE dbo.EmployeeDetailss Set Names = @name, DateOfBirth = @dateOfBirth, Phone = @phone, Email = @email, Department = @department, Addresss = @address, States = @states, City = @city, Zipcode = @zipCode, DateOfJoin = @dateOfJoin  where empId = " + id;
            string ore = "Delete from dbo.EmployeeDetailss  where empId = " + id;
            //string ore = "UPDATE dbo.EmployeeDetailss empId = " + id;
            //string form = "select * from dbo.EmployeeDetailss ";

            db.delete(ore);
            //db.select(form);

            return RedirectToAction("AddEmployee");
        }

    }
}