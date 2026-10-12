using UnityEngine;
using System.Collections.Generic;


public class Inventory : MonoBehaviour
{
    public List<string> Items = new List<string>();

    public GameCon gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameCon>();
    }

    void Update()
    {
        if (gameManager.currentState == gameManager.GAMEPLAY)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                AddItemToInventory("Item1");
                print("Item1 added to inventory");
            }
        }
    }

    public void AddItemToInventory(string itemName)
    {
        Items.Add(itemName);
    }

    public void RemoveItemFromInventory(string itemName)
    {
        Items.Remove(itemName);
    }
}