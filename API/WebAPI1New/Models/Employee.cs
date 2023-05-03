using System.Data;
using Microsoft.Data.SqlClient;
namespace WebAPI1New.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        public static void Insert(Employee emp)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Yash1;Integrated Security=True;";
            try
            {
                cn.Open();

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployee";
                cmd.Parameters.AddWithValue("@Id", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { cn.Close(); }
        }

        public static void Update(Employee emp)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Yash1;Integrated Security=True;";
            try
            {
                cn.Open();

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "updateEmployee";
                cmd.Parameters.AddWithValue("@Id", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                throw new Exception("Invalid Query");
            }
            finally { cn.Close(); }
        }
        public static void Delete(int EmpNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Yash1;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEmployee";
                cmd.Parameters.AddWithValue("@Id", EmpNo);

                cmd.ExecuteNonQuery();
                //throw new Exception("Execute Query");

            }
            catch
            {
                throw new Exception("Invalid Query");
            }
            finally { cn.Close(); }
        }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmp = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Yash1;Integrated Security=True;";
            try
            {
                cn.Open();

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    lstEmp.Add(new Employee { EmpNo = dr.GetInt32("EmpNo"), Name = dr.GetString("Name"), Basic = dr.GetDecimal("Basic"), DeptNo = dr.GetInt32("DeptNo") });

                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { cn.Close(); }
            return lstEmp;

        }

        public static Employee GetSingleEmployee(int EmpNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Yash1;Integrated Security=True;";
            Employee emp = new Employee();
            try
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo =@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp.EmpNo = dr.GetInt32("EmpNo");
                    emp.Name = dr.GetString("Name");
                    emp.Basic = dr.GetDecimal("Basic");
                    emp.DeptNo = dr.GetInt32("DeptNo");
                }
                else
                    throw new Exception("Invalid Query");

                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { cn.Close(); }
            return emp;
        }

    }
}
