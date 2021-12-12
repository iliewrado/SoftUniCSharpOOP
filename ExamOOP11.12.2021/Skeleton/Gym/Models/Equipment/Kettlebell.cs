namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double initialWeight = 10000;
        private const decimal price = 80;
        public Kettlebell()
            : base(initialWeight, price)
        {
        }
    }
}
