using Dalel.ViewModels;
using Models.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class CarProposalExt
    {
        public static CarProposalDetailsViewModel ToDetailsViewModel(this CarProposal proposal)
        {
            return new CarProposalDetailsViewModel
            {
                Id = proposal.Id,
                Price = proposal.Price,
                ProposalStatus = proposal.ProposalStatus,
                IsAccepted = proposal.IsAccepted,
                SuggestedPrice = proposal.SuggestedPrice,
                StartedDateTime = proposal.StartedDateTime,
                DriverName = proposal.Driver?.AppUser?.UserName,
                BookingVehicleId = proposal.BookingVehicleId
            };
        }
    }
}
