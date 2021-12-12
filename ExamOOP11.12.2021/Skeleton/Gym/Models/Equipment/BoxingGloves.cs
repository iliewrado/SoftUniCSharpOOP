namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double initialWeight = 227;
        private const decimal price = 120;
        public BoxingGloves()
            : base(initialWeight, price)
        {
        }
    }
}
