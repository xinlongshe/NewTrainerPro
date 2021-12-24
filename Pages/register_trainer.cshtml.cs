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
    public class register_trainerModel : PageModel
    {

        private string SetCode { get; set; }
        public string Message { get; set; }
        public string EmailCode { get; set; }
        private readonly IDapperRepository<Trainer> _trainerDapperRepository;
        private readonly ISendMail _sendMail;
        public register_trainerModel(IDapperRepository<Trainer> trainerDapperRepository, ISendMail sendMail)
        {
            _trainerDapperRepository = trainerDapperRepository;
            _sendMail = sendMail;
        }
        [BindProperty]
        public Trainer Trainer { get; set; }

        public List<TrainerModel> InterestingModel { get; set; }
        public List<TrainerModel> GenderModel { get; set; }
        public List<TrainerModel> OptionalModel { get; set; }
        public List<TrainerModel> TrainingModel { get; set; }

        public IActionResult OnGet()
        {
            InterestingModel.Add(new TrainerModel() { Selected = false, Name = "Health" });
            InterestingModel.Add(new TrainerModel() { Selected = false, Name = "Education" });
            InterestingModel.Add(new TrainerModel() { Selected = false, Name = "Arts" });
            InterestingModel.Add(new TrainerModel() { Selected = false, Name = "Sports" });
            InterestingModel.Add(new TrainerModel() { Selected = false, Name = "Business" });

            GenderModel.Add(new TrainerModel() { Selected = false, Name = "Male" });
            GenderModel.Add(new TrainerModel() { Selected = false, Name = "Femail" });
            GenderModel.Add(new TrainerModel() { Selected = false, Name = "Others" });

            OptionalModel.Add(new TrainerModel() { Selected = false, Name = "+61" });
            OptionalModel.Add(new TrainerModel() { Selected = false, Name = "+51" });
            OptionalModel.Add(new TrainerModel() { Selected = false, Name = "+41" });
            OptionalModel.Add(new TrainerModel() { Selected = false, Name = "+31" });
            OptionalModel.Add(new TrainerModel() { Selected = false, Name = "+21" });


            TrainingModel.Add(new TrainerModel() { Selected = false, Name = "Online" });
            TrainingModel.Add(new TrainerModel() { Selected = false, Name = "In person" });
            TrainingModel.Add(new TrainerModel() { Selected = false, Name = "Both" });

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
            Trainer.Gender = genderStr;
            Trainer.KindOfTrainer = interestingStr;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (SetCode != EmailCode)
            {
                TempData["Message"] = "Incorrect verification code";
                return Page();
            }

            var adminList = _trainerDapperRepository.Add(Trainer);
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
            _sendMail.SendMailAsync(Trainer.Email, "", "PrivacyDB", vc);
            SetCode = vc;
            return "";
        }
    }


    public class TrainerModel
    {
        public bool Selected { get; set; }
        public string Name { get; set; }
    }
}

