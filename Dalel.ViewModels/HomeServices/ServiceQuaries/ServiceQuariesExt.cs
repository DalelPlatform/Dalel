using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class ServiceQuariesExt
    {
        public static Models.HomeService.ServiceQuaries ToModel(this AddServiceQuariesVM vm)
        {
            return new Models.HomeService.ServiceQuaries
            {
                ServiceProviderId = vm.ServiceProviderId,
                ClientId = vm.ClientId,
                Question = vm.Question,
                CategoryServicesId = vm.CategoryServicesId,
                QuestionDate = DateTime.UtcNow
            };
        }

        public static ServiceQuariesDetailsVM ToDetailsModel(this Models.HomeService.ServiceQuaries model)
        {
            return new ServiceQuariesDetailsVM
            {
                Id = model.Id,
                ClientName = model.Client?.User.UserName ?? string.Empty,
                ProviderName = model.ServiceProvider?.AppUser.UserName ?? string.Empty,
                CategoryName = model.CategoryServices?.Name ?? string.Empty,
                Question = model.Question,
                Answer = model.Answer,
                QuestionDate = model.QuestionDate.ToString("yyyy-MM-dd"),
                AnswerDate = model.AnswerDate.ToString("yyyy-MM-dd")
            };
        }
    }
}
