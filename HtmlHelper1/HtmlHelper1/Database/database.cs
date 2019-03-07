using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlHelper1.Models;

namespace HtmlHelper1.Database
{
    public class database
    {

        string sqlConnections = "Server=DOTNET22\\SQLEXPRESS; Database = Employee;User ID=sa; Password=Sql@123456";

        public void insert(string command, Employee model)
        {
            SqlConnection con = null;
            try
            {
               
                con = new SqlConnection(sqlConnections);

                SqlCommand com = new SqlCommand(command, con);
                //  SqlCommand com = new SqlCommand("select * from dbo.EmployeeDetailss", con);


                con.Open();


                com.Parameters.Add("@name", SqlDbType.VarChar, 40).Value = model.Name;
                com.Parameters.Add("@dateOfBirth", SqlDbType.VarChar, 10).Value = model.Dateofbirth;
                com.Parameters.Add("@phone", SqlDbType.VarChar, 15).Value = model.Phone;
                com.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = model.Email;
                com.Parameters.Add("@department", SqlDbType.VarChar, 30).Value = model.Department;
                com.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = model.Address;
                com.Parameters.Add("@states", SqlDbType.VarChar, 20).Value = model.States;
                com.Parameters.Add("@city", SqlDbType.VarChar, 20).Value = model.City;
                com.Parameters.Add("@zipCode", SqlDbType.VarChar, 10).Value = model.Zip;
                com.Parameters.Add("@dateOfJoin", SqlDbType.VarChar, 20).Value = model.Dateofjoin;


                com.ExecuteNonQuery();

                //////////////////////////////States and City Validation /////////////////////////////////////


                // SqlConnection conn = new SqlConnection("Server=DOTNET22\\SQLEXPRESS; Database = Employee;User ID=sa; Password=Sql@123456");



            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            finally
            {
                con.Close();
            }

        }

    public List<Employee> select(string command)
    {
        SqlConnection con = null;
            SqlDataReader dr = null;
        var modelList = new List<Employee>();
        con = new SqlConnection(sqlConnections);
       
       
        con.Open();
            SqlCommand sqlCommand = new SqlCommand(command, con);
            dr = sqlCommand.ExecuteReader();
            while (dr.Read())
           {
               var emp = new Employee();
                emp.EmpId =(int) dr["EmpId"];
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
           
    
    
    
           
            con.Close();
       
        return (modelList);
    }

        public void update(string command, Employee model)
        {
            SqlConnection con = null;


            con = new SqlConnection(sqlConnections);


            con.Open();
            SqlCommand com= new SqlCommand(command, con);
            com.Parameters.Add("@name", SqlDbType.VarChar, 40).Value = model.Name;
            com.Parameters.Add("@dateOfBirth", SqlDbType.VarChar, 10).Value = model.Dateofbirth;
            com.Parameters.Add("@phone", SqlDbType.VarChar, 15).Value = model.Phone;
            com.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = model.Email;
            com.Parameters.Add("@department", SqlDbType.VarChar, 30).Value = model.Department;
            com.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = model.Address;
            com.Parameters.Add("@states", SqlDbType.VarChar, 20).Value = model.States;
            com.Parameters.Add("@city", SqlDbType.VarChar, 20).Value = model.City;
            com.Parameters.Add("@zipCode", SqlDbType.VarChar, 10).Value = model.Zip;
            com.Parameters.Add("@dateOfJoin", SqlDbType.VarChar, 20).Value = model.Dateofjoin;
            com.ExecuteNonQuery();
            
            con.Close();

            
        }
        public void delete(string command)
        {
            SqlConnection con = null;


            con = new SqlConnection(sqlConnections);


            con.Open();
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();

            con.Close();


        }
        //public Employee mySelect(string command)
        //{
        //    SqlConnection con = null;
        //    //   var modelList = new List<Employee>();

        //    Employee my = new Employee();

        //    con = new SqlConnection(sqlConnections);
        //    SqlCommand sqlCommand = new SqlCommand(command, con);
        //    try
        //    {
        //        con.Open();
        //        SqlDataReader dr = sqlCommand.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            var emp = new Employee();
        //            emp.Name = dr["Names"].ToString();
        //            emp.Dateofbirth = dr["DateOfBirth"].ToString();
        //            emp.Phone = dr["Phone"].ToString();
        //            emp.Email = dr["Email"].ToString();
        //            emp.Department = dr["Department"].ToString();
        //            emp.Address = dr["Addresss"].ToString();
        //            emp.States = dr["States"].ToString();
        //            emp.City = dr["City"].ToString();
        //            emp.Zip = dr["ZipCode"].ToString();
        //            emp.Dateofjoin = dr["DateoFJoin"].ToString();
        //            my = emp;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return (my);
        //}
        //public dataset select(string command)
        //{
        //    dataset dataset = new dataset();
        //    sqlconnection con = null;
        //    using (con = new sqlconnection(sqlconnections))
        //    {
        //        sqldataadapter adapter = new sqldataadapter();
        //        adapter.selectcommand = new sqlcommand(command, con);
        //        adapter.fill(dataset);

        //    }
        //}



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
        public IEnumerable<SelectListItem> dbState(string command)
        {
            SqlConnection con = null;
            con = new SqlConnection(sqlConnections);
            List<SelectListItem> states = new List<SelectListItem>();
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(command, con);
            SqlDataReader read = sqlCommand.ExecuteReader();
            while (read.Read())
            {
                states.Add(new SelectListItem
                {
                    Text = read["States"].ToString(),
                    Value = read["StateId"].ToString()
                });
            }


            con.Close();

            return states;
        }
        public IEnumerable<SelectListItem> dbCity(string command)
        {
            SqlConnection con = null;
            con = new SqlConnection(sqlConnections);
            con.Open();
            try
            {
                List<SelectListItem> citys = new List<SelectListItem>();
                SqlCommand sqlCommand = new SqlCommand(command, con);
           
               SqlDataReader read = sqlCommand.ExecuteReader();
                while (read.Read())
                {
                    citys.Add(new SelectListItem
                    {
                        Text = read["CName"].ToString(),
                        Value = read["cityId"].ToString()
                    });
                }
                return citys;
            }
            catch (Exception e) { throw e; }
            finally
            {
                con.Close();
            }

        }
        
      public IEnumerable<SelectListItem> dbDepartment(string command)
      {
            SqlConnection con = null;
            con = new SqlConnection(sqlConnections);
         try
          {
             List<SelectListItem> department = new List<SelectListItem>();
              SqlCommand sqlCommand = new SqlCommand(command, con);
              con.Open();
              SqlDataReader read = sqlCommand.ExecuteReader();
              while (read.Read())
              {
                  department.Add(new SelectListItem
                  {
                     Text = read["Dname"].ToString(),
                      Value = read["Did"].ToString()
                 });
              }
              return department;
          }
          catch (Exception e) { throw e; }
          finally
         {
              con.Close();
          }

        }
    }
}