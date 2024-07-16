namespace ProjectFive.Models
{
    public class ReviewModel
    {
        public int ID { get; set; }
        public int ResturantID { get; set; }
        public int ReviwerID { get; set; }

        public int FoodRating { get; set; }
        public int ServiceRating { get; set; }
        public int AtmosphereRating { get; set; }
        public int PriceRating { get; set; }
        public string Description { get; set; }

    }

    public class ReviewApiModel
    {
        public int ID { get; set; }
        public int ResturantID { get; set; }
        public int ReviwerID { get; set; }
        public string Name { get; set; }
        public int FoodRating { get; set; }
        public int ServiceRating { get; set; }
        public int AtmosphereRating { get; set; }
        public int PriceRating { get; set; }
        public string Description { get; set; }

    }
}
