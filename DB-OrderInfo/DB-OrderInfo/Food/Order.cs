namespace DB_OrderInfo.Food
{
    class Order
    {
        public int ID { get; set; }
        public enum Status { Pågående = 1, Klar = 2, }
    }
}
