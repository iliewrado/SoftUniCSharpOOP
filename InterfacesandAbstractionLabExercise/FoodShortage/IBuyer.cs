namespace FoodShortage
{
    interface IBuyer : IPerson
    {
        public int Food { get; set; }
        void BuyFood();
    }
}
