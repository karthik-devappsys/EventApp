using EventManageApp.Core.Enums;

namespace EventManageApp.Core.Models.Event
{
    public class ViewEvents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public decimal Price { get; set; }
        public EventStatus Status { get; set; }
        public string ImageUrl { get; set; }
    }
}