using Dalel.ViewModels.HomeServices.ServiceQuaries;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class ServiceQuariesExt
    {
        //public static ServiceQuaries ToModel(this AddAnswerQueryVM vm, ServiceQuaries existingQuery)
        //{
        //    existingQuery.Answer = vm.Answer;
        //    existingQuery.AnswerDate = DateTime.Now;
        //    return existingQuery;
        //}
        public static ServiceQuaries ToModel(this AddServiceQuariesVM vm)
        {
            return new ServiceQuaries
            {
                ClientId = vm.ClientId,
                CategoryServicesId = vm.CategoryServicesId,
                ServiceProviderId = vm.ServiceProviderId,
                Question = vm.Question,
                QuestionDate = DateTime.Now
            };
        }
        public static ServiceQuaries ToEditModel(this AddServiceQuariesVM vm, ServiceQuaries existing)
        {
            existing.ClientId = vm.ClientId;
            existing.CategoryServicesId = vm.CategoryServicesId;
            existing.ServiceProviderId = vm.ServiceProviderId;
            existing.Question = vm.Question;
            return existing;
        }
        public static ServiceQuariesDetailsVM ToDetailsViewModel(this ServiceQuaries model)
        {
            return new ServiceQuariesDetailsVM
            {
                Id = model.Id,
                ClientId = model.ClientId,
                ClientName = model.Client?.User.UserName ?? "Not Provided",
                CategoryServicesId = model.CategoryServicesId,
                CategoryName = model.CategoryServices?.Name ?? "Not Provided",
                ServiceProviderId = model.ServiceProviderId,
                ServiceProviderName = model.ServiceProvider?.AppUser?.UserName ?? "Not Provided",
                Question = model.Question,
                Answer = model.Answer,
                QuestionDate = model.QuestionDate,
                AnswerDate = model.AnswerDate
            };
        }
    }
}
