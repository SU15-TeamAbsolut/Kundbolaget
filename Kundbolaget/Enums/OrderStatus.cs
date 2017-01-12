namespace Kundbolaget.Enums
{
    public enum OrderStatus
    {
        Registered = 100,
        Processing = 200,
        ReadyToShip = 300,
        Shipping = 400,
        Delivered = 500,
        Invoiced = 600,
        Cancelled = 1000
    }
}