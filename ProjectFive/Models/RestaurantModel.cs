namespace ProjectFive.Models
{
    public class RestaurantModel
    {
        public int ID { get; set; }
        public int Representative_ID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string Category { get; set; }
    }
}
