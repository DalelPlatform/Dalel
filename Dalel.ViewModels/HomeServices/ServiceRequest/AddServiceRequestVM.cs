using Microsoft.AspNetCore.Http;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddServiceRequestVM
    {
        public string? ClientId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryServicesId { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Address is required.")]
        public string Address { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required(ErrorMessage ="You Should Put the date that you want the service provider come to you")]
        public DateTime DueDate {  get; set; }
        [Required (ErrorMessage ="You should put your budget")]
        public double StartPrice { get; set; }
        public IFormFile? Image {  get; set; }
        public string? Imagepath { get; set; } = "";

        public RequestStatus Status { get; set; } = RequestStatus.Accepted;
    }
}

