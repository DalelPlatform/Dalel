using Dalel.ViewModels.HomeServices;
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
                ChatId = vm.ChatId,
                ClientId = vm.ClientId,
                CategoryServicesId = vm.CategoryServicesId,
                ServiceProviderId = vm.ServiceProviderId,
                Comment = vm.Comment,
                CommentDate = DateTime.Now,
                IsSenderClient = vm.IsSenderClient,
            };
        }
        public static ServiceQuaries ToEditModel(this AddServiceQuariesVM vm, ServiceQuaries existing)
        {
            existing.ChatId = vm.ChatId;
            existing.ClientId = vm.ClientId;
            existing.CategoryServicesId = vm.CategoryServicesId;
            existing.ServiceProviderId = vm.ServiceProviderId;
            existing.Comment = vm.Comment;
            return existing;
        }
        public static ServiceQuariesDetailsVM ToDetailsViewModel(this ServiceQuaries model)
        {
            return new ServiceQuariesDetailsVM
            {
                Id = model.Id,
                ChatId = model.ChatId,
                ClientId = model.ClientId,
                ClientName = model.Client?.User.UserName ?? "Not Provided",
                CategoryServicesId = model.CategoryServicesId,
                ServiceProviderId = model.ServiceProviderId,
                ServiceProviderName = model.ServiceProvider?.AppUser?.UserName ?? "Not Provided",
                Comment = model.Comment,
                CommentDate = model.CommentDate,
                IsSenderClient = model.IsSenderClient
            };
        }
    }
}
