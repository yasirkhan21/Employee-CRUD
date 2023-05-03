using Microsoft.AspNetCore.Mvc;
using WebAPI1New.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI1New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // GET: api/<EmployeesController>
        [HttpGet]
        #region cors
        //[EnableCors]  //enable the default policy for this method
        //[EnableCors("PolicyNameHere")]  //enable the specific policy for this method
        //[DisableCors] //disable cors
        //can also be done for the controller instead of method
        #endregion
        public IEnumerable<Employee> Get()
        {
            IEnumerable<Employee> emps = Employee.GetAllEmployees();
            return emps;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            Employee emp = Employee.GetSingleEmployee(id);
            return emp;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employee emp)
        {
            Employee.Insert(emp);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
            Employee.Update(emp);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Employee.Delete(id);
        }
    }
}
