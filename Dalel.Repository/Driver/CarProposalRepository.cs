using Dalel.Repository;
using Dalel.ViewModels;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Driver;
using Models.Enums;

namespace Dalel.Repository
{
    public class CarProposalRepository : BaseRepository<CarProposal>
    {
        public CarProposalRepository(DelelContext context) : base(context)
        {
        }

        public CarProposalDetailsViewModel GetCarProposalDetails(int proposalId)
        {
            var proposal = base.GetList(cp => cp.Id == proposalId).FirstOrDefault();
            return proposal?.ToDetailsViewModel();
        }

        public IQueryable<CarProposalDetailsViewModel> GetProposalsByBooking(int bookingId)
        {
            return GetList(cp => cp.BookingVehicleId == bookingId).Select(cp => cp.ToDetailsViewModel());
        }

        public IQueryable<CarProposalDetailsViewModel> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return base.GetList().Select(cp => cp.ToDetailsViewModel());

            searchTerm = searchTerm.ToLower();

            return base.GetList()
                .Where(cp =>
                    cp.Driver.AppUser.UserName.ToLower().Contains(searchTerm) ||
                    cp.ProposalStatus.ToString().ToLower().Contains(searchTerm) ||
                    cp.Id.ToString().Contains(searchTerm)
                )
                .Select(cp => cp.ToDetailsViewModel());
        }
    }
}
