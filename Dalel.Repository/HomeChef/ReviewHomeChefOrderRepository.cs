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
    public class ReviewHomeChefOrderRepository : BaseRepository<ReviewHomeChefOrder>
    {

        public ReviewHomeChefOrderRepository(DelelContext dalel) : base(dalel) 
        {
        
        }


        public ReviewHomeChefOrderDetailsVM ? GetReviewById(int id)
        {
            return base.GetList(r => r.Id == id)
                .Select(r => new ReviewHomeChefOrderDetailsVM()).FirstOrDefault();
        }

        public List<ReviewHomeChefOrderDetailsVM> GetAllReviews()
        {
            return base.GetList().Select(r => new ReviewHomeChefOrderDetailsVM
            {
                Comments = r.Comments,
                ModificationDateTime = r.ModificationDateTime,
                Rating = r.Rating
            }).ToList();
        }


        public List<ReviewHomeChefOrderDetailsVM> GetReviewsByOrderId(int id)
        {
            return base.GetList(r => r.HomeChefOrderId == id)
                .Select(r => new ReviewHomeChefOrderDetailsVM()).ToList();
        }

        public List<ReviewHomeChefOrderDetailsVM> GetReviewsByChefId(string id)
        {
            return base.GetList(r =>r. HomeChefId == id)
                .Select(r => new ReviewHomeChefOrderDetailsVM()).ToList();
        }


    }
}
