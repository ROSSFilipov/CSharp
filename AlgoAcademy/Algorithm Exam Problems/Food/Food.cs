using System;
using System.Collections.Generic;

class Dish
{
    public Dish(string name, int weight, int value)
    {
        this.Name = name;
        this.Value = value;
        this.Weight = weight;
    }

    public string Name { get; set; }

    public int Value { get; set; }

    public int Weight { get; set; }
}

class Food
{
    static void Main(string[] args)
    {
        int capacity = int.Parse(Console.ReadLine());
        int numberOfDishes = int.Parse(Console.ReadLine());
        Dish[] dishArray = new Dish[numberOfDishes];
        for (int i = 0; i < numberOfDishes; i++)
        {
            string[] currentDish = Console.ReadLine().Split();
            dishArray[i] = new Dish(currentDish[0], int.Parse(currentDish[1]), int.Parse(currentDish[2]));
        }

        ChooseOptimalDishes(dishArray, capacity, numberOfDishes);
    }

    private static void ChooseOptimalDishes(Dish[] dishArray, int capacity, int numberOfDishes)
    {
        long[,] costMatrix = new long[numberOfDishes, capacity + 1];
        bool[,] isTaken = new bool[numberOfDishes, capacity + 1];
        for (int i = 0; i < capacity + 1; i++)
        {
            if (dishArray[0].Weight <= i)
            {
                costMatrix[0, i] = dishArray[0].Value;
                isTaken[0, i] = true;
            }
        }

        for (int i = 1; i < numberOfDishes; i++)
        {
            for (int j = 0; j < capacity + 1; j++)
            {
                costMatrix[i, j] = costMatrix[i - 1, j];
                int remainingCapacity = j - dishArray[i].Weight;
                if (remainingCapacity >= 0
                    && costMatrix[i - 1, remainingCapacity] + dishArray[i].Value > costMatrix[i - 1, j])
                {
                    costMatrix[i, j] = costMatrix[i - 1, remainingCapacity] + dishArray[i].Value;
                    isTaken[i, j] = true;
                }
            }
        }

        LinkedList<Dish> takenItems = new LinkedList<Dish>();
        int rowIndex = numberOfDishes - 1;
        int collumnIndex = capacity;

        Console.WriteLine(costMatrix[rowIndex, collumnIndex]);
        while (rowIndex >= 0)
        {
            if (isTaken[rowIndex, collumnIndex])
            {
                Console.WriteLine(dishArray[rowIndex].Name);
                //takenItems.AddFirst(dishArray[rowIndex]);
                collumnIndex -= dishArray[rowIndex].Weight;
            }
            rowIndex--;
        }
    }
}

