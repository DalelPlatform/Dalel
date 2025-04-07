using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class ServiceQuariesDetailsVM
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ProviderName { get; set; }
        public string CategoryName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string QuestionDate { get; set; }
        public string AnswerDate { get; set; }
    }
}
