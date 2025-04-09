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
        public static ServiceQuaries ToModel(this AddAnswerQueryVM vm, ServiceQuaries existingQuery)
        {
            existingQuery.Answer = vm.Answer;
            existingQuery.AnswerDate = DateTime.Now;
            return existingQuery;
        }

        public static ServiceQuariesDetailsVM ToDetailsModel(this ServiceQuaries model)
        {
            return new ServiceQuariesDetailsVM
            {
                Id = model.Id,
                Question = model.Question,
                Answer = model.Answer
            };
        }
    }
}
