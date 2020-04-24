using StoreApp.Model.Interfaces;

namespace StoreApp.Model
{
    public class Items:IItems
    {
        public string Item_Id { get; set; }

        public string Item_Name { get; set; }

        public string Cat_Id { get; set; }

        public string Unit_Id { get; set; }

        public float Price { get; set; }

        public string Start_Date { get; set; }

        public string End_Date { get; set; }

        public string Active { get; set; }
    }
}
