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

        public string UserType { get; set; }

        private readonly IDapperRepository<Admin> _adminDapperRepository;
        private readonly IDapperRepository<Trainee> _traineeDapperRepository;
        private readonly IDapperRepository<Trainer> _trainerDapperRepository;
        public login_traineeModel(IDapperRepository<Admin> adminDapperRepository, IDapperRepository<Trainee> traineeDapperRepository, IDapperRepository<Trainer> trainerDapperRepository)
        {
            _adminDapperRepository = adminDapperRepository;
            _traineeDapperRepository = traineeDapperRepository;
            _trainerDapperRepository = trainerDapperRepository;
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
            if(Admin.UserType == "Admin")
            {
                string sql = "select * from Admin where Username='" + Admin.Username + "' and Password='" + Admin.Password + "'";
                var list = _adminDapperRepository.GetList(sql, null);
                if (list != null && list.Count() > 0)
                {
                    return RedirectToPage("admin");
                }
                else
                {
                    TempData["Message"] = "Wrong password or account does not exist";
                    return Page();
                }

            }
            else if(Admin.UserType == "Trainee")
            {
                string sql = "select * from Trainee where Username='" + Admin.Username + "' and Password='" + Admin.Password + "'";
                var list = _traineeDapperRepository.GetList(sql, null);
                if (list != null && list.Count() > 0)
                {
                    return RedirectToPage("trainee_profile");
                }
                else
                {
                    TempData["Message"] = "Wrong password or account does not exist";
                    return Page();
                }
            }
            else
            {
                string sql = "select * from Trainer where Username='" + Admin.Username + "' and Password='" + Admin.Password + "'";
                var list = _trainerDapperRepository.GetList(sql, null);
                if (list != null && list.Count() > 0)
                {
                    return RedirectToPage("trainer_profile");
                }
                else
                {
                    TempData["Message"] = "Wrong password or account does not exist";
                    return Page();
                }
            }
           
        }

    }
}
