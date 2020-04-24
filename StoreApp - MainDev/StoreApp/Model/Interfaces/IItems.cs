namespace StoreApp.Model.Interfaces
{
    public interface IItems
    {
         string Item_Id { get; set; }

         string Item_Name { get; set; }

         string Cat_Id { get; set; }

         string Unit_Id { get; set; }

         float Price { get; set; }

         string Start_Date { get; set; }

         string End_Date { get; set; }

         string Active { get; set; }
    }
}
