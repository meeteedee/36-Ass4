using UnityEngine;
    public enum FoodType
{
    Hay,
    Grain,
    Omakase,
    RottenFood,
    AnimalFood
}
public abstract class Animal : MonoBehaviour
{
    private string name;
    private int hunger;
    private int happiness;
    public string Name
    {
        get { return name; }
        private set { name = string.IsNullOrEmpty(value) ? "Unknown" : value; }
    }

    public int Hunger
    {
        get { return hunger; }
        private set { hunger = Mathf.Clamp(value, 0, 100); }
    }

    public int Happiness
    {
        get { return happiness; }
        private set { happiness = Mathf.Clamp(value, 0, 100); }
    }

    public FoodType PreferredFood { get; protected set; }

    public virtual void Init(string newName)
    {
        Name = newName;
        Hunger = 50;
        Happiness = 50;
    }

    public void AdjustHunger(int amount)
    {
        Hunger = Hunger + amount;
    }

    public void AdjustHappiness(int amount)
    {
        Happiness = Happiness + amount;
    }
    public void GetStatus()
    {
        Debug.Log($"{Name} -> Hunger: {Hunger}, Happiness: {Happiness}, Preferred Food: {PreferredFood}");
    }

    public void Feed(int amount)
    {
        AdjustHunger(-amount);
        AdjustHappiness(amount / 2);
        Debug.Log($"{Name} was fed {amount} units of generic food. Hunger: {Hunger}, Happiness: {Happiness}");
    }
    public void Feed(FoodType food, int amount)
    {
        if (food == PreferredFood)
        {
            AdjustHunger(-amount);
            AdjustHappiness(15);
            Debug.Log($"{Name} was fed {amount} units of favorite food: {food}. Happiness +15! Hunger: {Hunger}, Happiness: {Happiness}");
        }
        else if (food == FoodType.RottenFood)
        {
            AdjustHappiness(-20);
            Debug.Log($"{Name} ate rotten food! Happiness -20! Hunger: {Hunger}, Happiness: {Happiness}");
        }
        else
        {
            Feed(amount);
        }
    }
    public abstract void MakeSound();
    public abstract string Produce();
}
