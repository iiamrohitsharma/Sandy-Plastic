namespace Sandy.Main.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Location
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int postcode { get; set; }
    }

    public class DummyUserModel
    {
        public string email { get; set; }
        public string gender { get; set; }
        public string phone_number { get; set; }
        public int birthdate { get; set; }
        public Location location { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string picture { get; set; }
    }


}
