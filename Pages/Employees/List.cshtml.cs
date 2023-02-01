using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDemos.Data;
using RazorDemos.Models.Domain;

namespace RazorDemos.Pages.Employees
{
    public class ListModel : PageModel
    {

        private readonly RazorPagesDemoDbContext dbContext;
        public List<Employee> Employess { get; set; }

        public ListModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {

            Employess  = dbContext.Employees.ToList();

        }
    }
}
