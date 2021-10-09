using System;
using System.Collections.Generic;
using System.Text;

namespace _04PizzaCalories
{
    public class Dough
    {
        private const int caloriesPerGram = 2;
        private string flourType;
        private string bakingTechnique;
        private double weight;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value; 
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set 
            {
                if (value.ToUpper() != "CRISPY"
                    && value.ToUpper() != "CHEWY"
                    && value.ToUpper() != "HOMEMADE")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value; 
            }
        }

        public string FlourType
        {
            get { return flourType; }
            private set 
            {
                if (value.ToUpper() != "WHITE" && value.ToUpper() != "WHOLEGRAIN")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value; 
            }
        }
        public double CaloriesCalculator()
        {
            double doughModifier = 1.0;
            if (FlourType.ToUpper() == "WHITE")
            {
                doughModifier = 1.5;
            }
            double bakingModifier = 1.0;
            if (BakingTechnique.ToUpper() == "CHEWY")
            {
                bakingModifier = 1.1;
            }
            else if (BakingTechnique.ToUpper() == "CRISPY")
            {
                bakingModifier = 0.9;
            }
            return caloriesPerGram * Weight * doughModifier * bakingModifier;
        }
    }
}
