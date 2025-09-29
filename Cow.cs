using UnityEngine;
public class Cow : Animal 
{
    private float milk;
    public float Milk
    {
        get { return milk; }
        private set { milk = (value < 0) ? 0 : value; }
    }

    public override void Init(string name)
    {
        base.Init(name);
        PreferredFood = FoodType.Hay;
        Milk = 0;
        GetStatus();
    }

    public override void MakeSound()
    {
        Debug.Log("Moooooo!");
    }
    
    public override string Produce()
    {
        float produced = 0;
        if (Happiness > 70)
        {
            produced = Happiness / 10f;
            Milk += produced;
            Debug.Log($"{Name} produced {produced} units of Milk.");
        }
        else
        {
            Debug.Log($"{Name} is not happy enough to produce milk.");
        }
        string total = $"Total Milk: {Milk} units";
        Debug.Log(total);
        return total;
    }
}