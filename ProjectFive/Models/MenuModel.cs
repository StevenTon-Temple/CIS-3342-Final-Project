using System.Collections.Generic;

namespace ProjectFive.Models
{
    public class MenuModel
    {

        public class MenuItems
        {
            public string title { get; set; }
            public string restaurantChain { get; set; }
        }
        public class CallRoot
        {
            public List<MenuItems> menuItems { get; set; }
        }





    }
}
