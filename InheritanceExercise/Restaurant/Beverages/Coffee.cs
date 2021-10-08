namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal DefaultPrice = 3.50M;
        private const double DefaultMilliliters = 50;
        public double Caffeine { get; set; }
        public Coffee(string name, double caffeine)
            :base(name,DefaultPrice, DefaultMilliliters)
        {
            Caffeine = caffeine;
        }
    }
}
