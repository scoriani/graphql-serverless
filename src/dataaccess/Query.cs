namespace dataaccess
{
    public class Query
    {
        public Order GetOrder(int orderID) => db.GetOrder(orderID);
    }
    
}
