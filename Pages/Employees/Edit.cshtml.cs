using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDemos.Data;
using RazorDemos.Models.Domain;
using RazorDemos.Models.ViewModels;

namespace RazorDemos.Pages.Employees
{

    public class EditModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        [BindProperty]
        public EditEmployeeViewModel _EditEmployeeViewModel { get; set; }

        public EditModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(Guid id)
        {

            var employee = dbContext.Employees.Find(id);
            if(employee != null) 
            {
                 _EditEmployeeViewModel = new EditEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Department = employee.Department
                };
            }

        }


        public void OnPostUpdate() 
        {
            if(_EditEmployeeViewModel!= null)
            {
                var existingEmployee = dbContext.Employees.Find(_EditEmployeeViewModel.Id);

                if(existingEmployee != null)
                {
                    existingEmployee.Id = _EditEmployeeViewModel.Id;
                    existingEmployee.Name = _EditEmployeeViewModel.Name;
                    existingEmployee.Email = _EditEmployeeViewModel.Email;
                    existingEmployee.Salary = _EditEmployeeViewModel.Salary;
                    existingEmployee.Department = _EditEmployeeViewModel.Department;
                    existingEmployee.DateOfBirth = _EditEmployeeViewModel.DateOfBirth;

                    dbContext.SaveChanges();

                }
            }

        }

        public IActionResult OnPostDelete()
        {
            var employee = dbContext.Employees.Find(_EditEmployeeViewModel.Id);
            if(employee != null)
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
                return RedirectToPage("/Employees/list");
            }
            return Page();

        }
    }
}
