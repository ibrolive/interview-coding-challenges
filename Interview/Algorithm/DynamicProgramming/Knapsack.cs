using System;
using System.Collections;
using System.Collections.Generic;

namespace Interview.Algorithm.DynamicProgramming
{
    class KnapsackTest
    {
        public static void Entry()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Product 1", 10, 60));
            products.Add(new Product("Product 2", 20, 100));
            products.Add(new Product("Product 3", 30, 120));

            Knapsack knpasack = new Knapsack(50);
            knpasack.GetBestCombination(products);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }

        public Product(string name, int weight, int price)
        {
            this.Name = name;
            this.Weight = weight;
            this.Price = price;
        }
    }

    class Knapsack
    {
        public int MaxVolume { get; set; }

        public Knapsack(int maxVolume)
        {
            this.MaxVolume = maxVolume;
        }

        public void GetBestCombination(List<Product> products)
        {
            Hashtable weightCombinationMapping = new Hashtable();
            Hashtable weightPriceMapping = new Hashtable();

            weightCombinationMapping.Add(0, new List<Product>());
            weightPriceMapping.Add(0, 0);

            for (int currentWeight = 10; currentWeight <= MaxVolume; currentWeight += 10)
            {
                weightCombinationMapping.Add(currentWeight, new List<Product>());
                weightPriceMapping.Add(currentWeight, 0);

                foreach (var currentProduct in products)
                {
                    if (currentProduct.Weight <= currentWeight
                        && currentProduct.Price + Convert.ToInt32(weightPriceMapping[currentWeight - currentProduct.Weight]) > Convert.ToInt32(weightPriceMapping[currentWeight])
                        && !((List<Product>)weightCombinationMapping[currentWeight - currentProduct.Weight]).Contains(currentProduct))
                    {
                        weightPriceMapping[currentWeight] = currentProduct.Price + Convert.ToInt32(weightPriceMapping[currentWeight - currentProduct.Weight]);
                        weightCombinationMapping[currentWeight] = new List<Product>((List<Product>)weightCombinationMapping[currentWeight - currentProduct.Weight]);
                        ((List<Product>)weightCombinationMapping[currentWeight]).Add(currentProduct);
                    }
                }

                if (Convert.ToInt32(weightPriceMapping[currentWeight - 10]) > Convert.ToInt32(weightPriceMapping[currentWeight]))
                {
                    weightPriceMapping[currentWeight] = Convert.ToInt32(weightPriceMapping[currentWeight - 10]);
                    weightCombinationMapping[currentWeight] = weightCombinationMapping[currentWeight - 10];
                }
            }

            Console.WriteLine(Convert.ToInt32(weightPriceMapping[MaxVolume]));
            Console.WriteLine("Best combination is:");
            foreach (var item in (List<Product>)weightCombinationMapping[MaxVolume])
                Console.WriteLine(item.Name);
        }
    }
}