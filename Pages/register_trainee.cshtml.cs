using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_4._0.Common;
using Test_4._0.Data;
using Test_4._0.Data.Model;

namespace TrainDEv.Pages
{
    public class register_traineeModel : PageModel
    {
        private string SetCode { get; set; }
        public string Message { get; set; }
        public string EmailCode { get; set; }
        private readonly IDapperRepository<Trainee> _traineeDapperRepository;
        private readonly ISendMail _sendMail;
        public register_traineeModel(IDapperRepository<Trainee> traineeDapperRepository, ISendMail sendMail)
        {
            _traineeDapperRepository = traineeDapperRepository;
            _sendMail = sendMail;
        }
        [BindProperty]
        public Trainee Trainee { get; set; }

        public List<TraineeModel> InterestingModel { get; set; }
        public List<TraineeModel> GenderModel { get; set; }
        public List<TraineeModel> OptionalModel { get; set; }

        public IActionResult OnGet()
        {
            InterestingModel.Add(new TraineeModel() { Selected = false,Name= "Health" }) ;
            InterestingModel.Add(new TraineeModel() { Selected = false, Name = "Education" });
            InterestingModel.Add(new TraineeModel() { Selected = false, Name = "Arts" });
            InterestingModel.Add(new TraineeModel() { Selected = false, Name = "Sports" });
            InterestingModel.Add(new TraineeModel() { Selected = false, Name = "Business" });

            GenderModel.Add(new TraineeModel() { Selected = false, Name = "Male" });
            GenderModel.Add(new TraineeModel() { Selected = false, Name = "Femail" });
            GenderModel.Add(new TraineeModel() { Selected = false, Name = "Others" });

            OptionalModel.Add(new TraineeModel() { Selected = false, Name = "+61" });
            OptionalModel.Add(new TraineeModel() { Selected = false, Name = "+51" });
            OptionalModel.Add(new TraineeModel() { Selected = false, Name = "+41" });
            OptionalModel.Add(new TraineeModel() { Selected = false, Name = "+31" });
            OptionalModel.Add(new TraineeModel() { Selected = false, Name = "+21" });

            return Page();
        }
        public IActionResult OnPostSave()
        {
            string interestingStr = string.Empty;
            foreach (var item in InterestingModel)
            {
                if (item.Selected)
                {
                    interestingStr += item.Name + ",";
                }
            }
            string genderStr = GenderModel.Where(x => x.Selected).FirstOrDefault().Name;
            string optionStr = OptionalModel.Where(x => x.Selected).FirstOrDefault().Name;
            Trainee.Gender = genderStr;
            Trainee.Interesting = interestingStr;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(SetCode!=EmailCode)
            {
                TempData["Message"] = "Incorrect verification code";
                return Page();
            }

            var adminList = _traineeDapperRepository.Add(Trainee);
            if (adminList != null && adminList.Count() > 0)
            {
                return RedirectToPage("login_trainee");
            }
            else
            {
                TempData["Message"] = "Registration failed, please contact the administrator";
                return Page();
            }
        }

        public string OnPostSendEmail()
        {
            string vc = "";
            Random rNum = new Random();//随机生成类
            int num1 = rNum.Next(0, 9);//返回指定范围内的随机数
            int num2 = rNum.Next(0, 9);
            int num3 = rNum.Next(0, 9);
            int num4 = rNum.Next(0, 9);
            int[] nums = new int[4] { num1, num2, num3, num4 };
            for (int i = 0; i < nums.Length; i++)//循环添加四个随机生成数
            {
                vc += nums[i].ToString();
            }
            _sendMail.SendMailAsync(Trainee.Email, "", "PrivacyDB", vc);
            SetCode = vc;
            return "";
        }
    }


    public class TraineeModel
    {
        public  bool Selected { get; set; }
        public string Name { get; set; }
    }
}
