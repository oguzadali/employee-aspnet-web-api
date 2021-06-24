using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"select EmployeeID,EmployeeName,Department,MailID,CONVERT(varchar(10),DOJ,120) as DOJ from dbo.Employees";


            var connect2sql = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB1"].ConnectionString);
            var command = new SqlCommand(query, connect2sql);

            using (var tb = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                tb.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Employees emp)
        {
            try
            {
                DataTable table = new DataTable();

                string doj = emp.DOJ.ToString().Split(' ')[0];

                string query = @"insert into dbo.Employees (EmployeeName,Department,MailID,DOJ) values (
                    '" + emp.EmployeeName + @"',
                    '" + emp.Department + @"',
                    '" + emp.MailID + @"',
                    '" + doj + @"'

            )";

                var connect2sql = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB1"].ConnectionString);
                var command = new SqlCommand(query, connect2sql);

                using (var tb = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    tb.Fill(table);
                }
                return "Added succesfully";
            }
            catch (Exception ex)
            {

                return "Failed to add";
            }

        }
        public string Put(Employees emp)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"update dbo.Employees set 
                    EmployeeName='" + emp.EmployeeName + @"', 
                    Department='" + emp.Department + @"',
                    MailID='" + emp.MailID + @"',
                    DOJ='" + emp.DOJ + @"'
                    where EmployeeID=" + emp.EmployeeID + @" ";



                var connect2sql = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB1"].ConnectionString);
                var command = new SqlCommand(query, connect2sql);

                using (var tb = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    tb.Fill(table);
                }
                return "Updated succesfully";
            }
            catch (Exception ex)
            {

                return "Failed to update";
            }

        }
        

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"delete from dbo.Employees where EmployeeID="+id;
                var connect2sql = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB1"].ConnectionString);
                var command = new SqlCommand(query, connect2sql);

                using (var tb = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    tb.Fill(table);
                }
                return "Deleted succesfully";
            }
            catch (Exception ex)
            {

                return "Failed to delete";
            }

        }


    }
}
