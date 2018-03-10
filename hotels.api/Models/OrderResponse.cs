using System;

namespace hotels.api.Models
{
    public class OrderResponse
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Units { get; set; }
    }
}
