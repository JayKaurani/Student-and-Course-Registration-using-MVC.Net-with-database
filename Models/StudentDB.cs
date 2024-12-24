using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Xml.Linq;
namespace DataBase_MVC.NET.Models
{
    public class StudentDB
    {
        private string _connectionString 
    = ConfigurationManager.ConnectionStrings["CollegeConnection"].ConnectionString;
        public DataTable GetStudents()
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = _connectionString;
            String query = "Select StudentId,S.Name as " +
                "Name,Gender,Address,S.CourseId,C.Name as Course " +
                "from Student as S inner join Course as C " +
                "on S.CourseId = C.CourseId;";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }
        public DataRow GetStudentById(int id)
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = _connectionString;
            String query = "Select * from Student where StudentId = @StudentId";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConn);
            sqlCommand.Parameters.Add("@StudentId",SqlDbType.Int).Value = id;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt.Rows[0];
        }
        public void UpdateStudent(Student update)
        {
            String query = "Update Student set Name = @Name,Address = @Address,Gender = @Gender,CourseId = @CourseId where StudentId = @StudentId";
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = _connectionString;
            SqlCommand sqlCommand = new SqlCommand(query,sqlConn);
            sqlCommand.Parameters.Add("@StudentId", SqlDbType.Int).Value = update.StudentId;
            sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = update.Name;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = update.Gender;
            sqlCommand.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = update.Address;
            sqlCommand.Parameters.Add("@CourseId", SqlDbType.Int).Value = update.CourseId;
            sqlConn.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConn.Close();
            sqlConn.Dispose();
            sqlCommand.Dispose();
        }
        public void DeleteStudent(int studentId)
        {
            String query = "delete from Student where StudentId = @StudentId";
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = _connectionString;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConn);
            sqlCommand.Parameters.Add("@StudentId", SqlDbType.Int).Value = studentId;

            sqlConn.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConn.Close();
            sqlConn.Dispose();
            sqlCommand.Dispose();
        }
        public void AddStudent(Student newStudent)
        {
            String query = "insert into Student(Name,Address,Gender,CourseId) values(@Name,@Address,@Gender,@CourseId)";
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = _connectionString;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConn);
           
            sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = newStudent.Name;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = newStudent.Gender;
            sqlCommand.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = newStudent.Address;
            sqlCommand.Parameters.Add("@CourseId", SqlDbType.Int).Value = newStudent.CourseId;
            sqlConn.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConn.Close();
            sqlConn.Dispose();
            sqlCommand.Dispose();
        }
        public DataTable GetCourse()
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = _connectionString;
            String query = "Select CourseId,Name from Course";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }
    }
}