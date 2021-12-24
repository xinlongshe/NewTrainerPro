using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_4._0.Data;
using Test_4._0.Data.Model;

namespace TrainDEv.Pages
{
    public class login_traineeModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly IDapperRepository<Admin> _adminDapperRepository;
        public login_traineeModel(IDapperRepository<Admin> adminDapperRepository)
        {
            _adminDapperRepository = adminDapperRepository;
        }

        [BindProperty]
        public Admin Admin{ get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string sql = "select * from Admin where Username='"+Admin.Username+"' and Password='"+Admin.Password+"'";
           var adminList = _adminDapperRepository.GetList(sql, null);
            if (adminList != null && adminList.Count() > 0)
            {
                return RedirectToPage("admin");
            }
            else
            {
                TempData["Message"] = "Hello ASP.NET MVC";
                return Page();
                //return RedirectToAction(Request.Path); // redirect to the GET
            }
        }

    }
}
