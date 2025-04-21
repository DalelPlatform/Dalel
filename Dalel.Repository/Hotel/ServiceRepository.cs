// File: Dalel.Repository/ServiceRepository.cs
using System;
using System.Linq;
using System.Linq.Expressions;
using Dalel.ViewModels;
using Models.Hotel;
using Models;

namespace Dalel.Repository
{
    public class ServiceRepository : BaseRepository<Service>
    {
        public ServiceRepository(DelelContext context) : base(context) { }

        public PaginationViewModel<ServiceDetails> Search(
            string name = null,
            bool? isActive = null,
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            Expression<Func<Service, bool>> filter = s =>
                (string.IsNullOrEmpty(name) || s.Name.Contains(name)) &&
                (!isActive.HasValue || s.IsActive == isActive);
            Expression<Func<Service, object>> orderBy = s => s.Name;
            return Search(filter, orderBy, s => s.ToDetailsViewModel(), descending, pageSize, pageIndex);
        }

        public ServiceDetails GetDetailsById(int id) =>
            GetList(s => s.Id == id).Select(s => s.ToDetailsViewModel()).FirstOrDefault();

        public IQueryable<ServiceDetails> GetAllDetails() =>
            GetList().Select(s => s.ToDetailsViewModel());

        public IQueryable<ServiceDetails> GetActiveServices() =>
            GetList(s => s.IsActive).Select(s => s.ToDetailsViewModel());
    }
}
