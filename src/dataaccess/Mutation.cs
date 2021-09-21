
namespace dataaccess
{

    public class Mutation
    {
        public OrderLine AddOrderLine (int orderLineID, int orderID, int stockItemID, int quantity)
        {
            var input = new AddOrderLineInput(OrderLineID: orderLineID, OrderID: orderID, StockItemID: stockItemID, Quantity: quantity );
            var ol = db.AddOrderLine(input);
            return ol;
        } 
    }

    public record AddOrderLineInput
    (
        int OrderLineID,
        int OrderID,
        int StockItemID,
        int Quantity
    );

}