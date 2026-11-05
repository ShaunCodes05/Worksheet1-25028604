using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

//pop the string for the item
public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

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
        if (items.Count > 0)
        {
            Item item = items[0];
            GameObject itemObject = item.gameObject;

            items.Remove(item);


            Vector3 posistion = GetComponent<Transform>().position + GetComponent<Transform>().forward + Vector3.up;

            Quaternion rotation = Quaternion.Euler(0, 180, 0 ) * GetComponent<Transform>().rotation;

            GameObject newItem = Instantiate(itemObject, posistion, rotation, worldItems);
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