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

    public class RestaurantAPIModel
    {
        public int id { get; set; }
        public int representative_id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double rating { get; set; }
        public string category { get; set; }
    }
}
