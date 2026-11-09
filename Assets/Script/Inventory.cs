using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{
    public List<Item> items= new List<Item>();

    public Transform worldItems;

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
                print("Item1 added to inventory");
            }
        }
    }

    public void AddItemToInventory(Item item)
    {
        items.Add(item);

        item.Oncollect();
    }

    public void RemoveItemFromInventory()
    {
        RemoveItemFromInventory(0);
    }

    public void RemoveItemFromInventory(int i)
    {
        if (items.Count > i && i >= 0)
        {
            Item item = items[i];

            GameObject itemObject = item.gameObject;

            items.RemoveAt(i);

            Vector3 position = transform.position + transform.forward + Vector3.up;

            Quaternion rotation = Quaternion.Euler(0, 180, 0) * transform.rotation;

            GameObject newItem = Instantiate(itemObject, position, rotation, worldItems);

            newItem.SetActive(true);

            Destroy(itemObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item item = hit.gameObject.GetComponent<Item>();

        if (item != null)
        {
            Debug.Log("hit item");
           
            AddItemToInventory((Item)item);
        }
  
    }
   
}