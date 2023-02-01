using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDemos.Data;
using RazorDemos.Models.Domain;
using RazorDemos.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace RazorDemos.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        public AddModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddEmployeeViewModel AddEmployeeRequest { get; set; }
        public RazorPagesDemoDbContext DbContext { get; }

        public void OnGet()
        {
        }

        public void OnPost() 
        {

            var employeDomainModel = new Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
                Department = AddEmployeeRequest.Department
            };

            dbContext.Employees.Add(employeDomainModel);
            dbContext.SaveChanges();
            ViewData["Message"] = "Employee created succesfully";
        }
    }
}
