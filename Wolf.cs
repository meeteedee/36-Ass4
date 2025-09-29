using UnityEngine;
public class Wolf : Animal
{
    private int furs;
    public int Furs
    {
        get { return furs; }
        private set { furs = (value < 0) ? 0 : value; }
    }

    public override void Init(string name)
    {
        base.Init(name);
        PreferredFood = FoodType.Omakase;
        Furs = 0;
        GetStatus();
    }

    public override void MakeSound()
    {
        Debug.Log("Awoooo!");
    }
    
    public override string Produce()
    {
        int produced = (Happiness >= 60) ? (Happiness / 30) : 0;
        Furs += produced;
        Debug.Log($"{Name} produced {produced} furs.");
        string total = $"Total Furs: {Furs}";
        Debug.Log(total);
        return total;
    }
}