using UnityEngine;
public class Chicken : Animal
{
    private int eggs;
    public int Eggs
    {
        get { return eggs; }
        private set { eggs = (value < 0) ? 0 : value; }
    }

    public override void Init(string name)
    {
        base.Init(name);
        PreferredFood = FoodType.Grain;
        Eggs = 0;
        GetStatus();
    }

    public override void MakeSound()
    {
        Debug.Log("Cheep cheep!");
    }

    public void Sleep()
    {
        AdjustHunger(+5);
        AdjustHappiness(+10);
        Debug.Log($"{Name} Sleep. Hunger:{Hunger}, Happiness:{Happiness}");
    }
    
    public override string Produce()
    {
        int produced = 0;
        if (Happiness <= 50) produced = 0;
        else if (Happiness <= 79) produced = 2;
        else produced = 3;

        Eggs += produced;
        Debug.Log($"{Name} produced {produced} eggs.");
        string total = $"Total Eggs: {Eggs}";
        Debug.Log(total);
        return total;
    }
}