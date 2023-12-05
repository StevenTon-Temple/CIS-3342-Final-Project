namespace ProjectFive.Models
{
    public class ReservationModel
    {
        public int ID { get; set; }
        public int Restuarant_ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string DateTime { get; set; }
    }

    public class ReservationAPIModel
    {
        public int id { get; set; }
        public int restuarant_id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string datetime { get; set; }

        public override string ToString()
        {
            return $"{id}|{restuarant_id}|{name}|{phone}|{datetime}";
        }
    }
}
