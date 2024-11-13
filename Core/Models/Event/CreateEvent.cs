
using System.ComponentModel.DataAnnotations;
using EventManageApp.Core.Attributes;
using EventManageApp.Core.Enums;

namespace EventManageApp.Core.Models.Event
{
    public class CreateEvent
    {
        [Required(ErrorMessage = "Please enter the title of the event.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a description for the event.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select the date and time for the event.")]
        [DataType(DataType.DateTime, ErrorMessage = "Please select a valid date and time.")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Please specify the price of the event.")]
        [DataType(DataType.Currency, ErrorMessage = "Please enter a valid currency format for the price.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter the total number of slots available.")]
        [Range(1, int.MaxValue, ErrorMessage = "Total slots must be at least 1.")]
        public int TotalSlots { get; set; } = 0;

        [Required(ErrorMessage = "Please upload an image for the event.")]
        [DataType(DataType.Upload, ErrorMessage = "Please upload a valid image file.")]
        [MaxFileSize(5 * 1024 * 1024)]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Please select a status for the event.")]
        public EventStatus Status { get; set; }
    }
}