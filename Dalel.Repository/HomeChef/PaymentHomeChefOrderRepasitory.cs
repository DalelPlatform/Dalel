using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using Models;
using Models.HomeChef;

namespace Dalel.Repository
{
    public class PaymentHomeChefOrderRepasitory : BaseRepository<PaymentHomeChefOrder>
    {
        public PaymentHomeChefOrderRepasitory(DelelContext dalel) : base(dalel) 
        {
        
        }

        public PaymentHomeChefOrderDetailsVM ? GetPaymentById(int id)
        {
            return base.GetList(p => p.Id == id)
                .Select(p => new PaymentHomeChefOrderDetailsVM()).FirstOrDefault();
        }

        public List<PaymentHomeChefOrderDetailsVM> GetAllPayments()
        {
            return base.GetList().Select(p => new PaymentHomeChefOrderDetailsVM
            {
                CommissionDeducted = p.CommissionDeducted,
                TransactionDateTime = p.TransactionDateTime,    
                Amount = p.Amount,
                AmountPaid = p.AmountPaid,
                CodeApplied = p.CodeApplied,
                PaymentMethod = p.PaymentMethod,
                PaymentStatus = p.PaymentStatus
            }).ToList();
        }

        //public List<PaymentHomeChefOrderDetailsVM> GetSuccessfulPayments()
        //{
        //    return base.GetList(p => p.PaymentStatus == 2)
        //        .Select(p => new PaymentHomeChefOrderDetailsVM()).ToList();
        //}

    }
}
