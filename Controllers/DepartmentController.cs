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
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"select ID,DepartmentName from dbo.Departments";

            var connect2sql = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB1"].ConnectionString);
            var command = new SqlCommand(query, connect2sql);

            using (var tb = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                tb.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Department dep)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"insert into dbo.Departments values ('" + dep.DepartmentName + @"')";

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
        public string Put(Department dep)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @" update dbo.Departments set DepartmentName='"+dep.DepartmentName+@"' where ID='"+dep.ID+@"' ";

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

                string query = @"delete from dbo.Departments where ID=" + id;
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
