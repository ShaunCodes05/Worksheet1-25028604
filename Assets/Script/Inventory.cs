using UnityEngine;
using System.Collections.Generic;


public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();


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
        items.Add(itemName);
    }

    public void RemoveItemFromInventory(string itemName)
    {
        items.Remove(itemName);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item item = hit.gameObject.GetComponent<Item>();

        if (item != null)
        {
            Debug.Log("hit item");
            items.Add(item.itemName);

            item.Oncollect();
        }

       
    }

   

}