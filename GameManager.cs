using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Cow cow1;
    public Chicken chicken1;
    public Wolf wolf1;

    public List<Animal> animals = new List<Animal>();

    void Start()
    {
        Debug.Log("Welcome to Happy Farm Sim");
        
        cow1.Init("ThaiDelmar");
        chicken1.Init("AiTong");
        wolf1.Init("AiBo");

        animals.Add(cow1);
        animals.Add(chicken1);
        animals.Add(wolf1);

        Debug.Log($"{animals.Count} animals in the farm");
        
        Debug.Log("\nFavorite Food");
        cow1.Feed(FoodType.Hay, 20);
        cow1.MakeSound();
        Debug.Log(cow1.Produce());
        
        Debug.Log("\nRotten Food");
        chicken1.Feed(FoodType.RottenFood, 5);
        chicken1.MakeSound();
        Debug.Log(chicken1.Produce());
        
        Debug.Log("\nClamp test");
        cow1.AdjustHunger(-200);
        cow1.AdjustHappiness(200);
        cow1.GetStatus();
        
        Debug.Log("\nNew animal lone wolf");
        wolf1.Feed(10);
        wolf1.MakeSound();
        Debug.Log(wolf1.Produce());

        Debug.Log("\n--- Final Status ---");
        foreach (var a in animals) a.GetStatus();
    }
}