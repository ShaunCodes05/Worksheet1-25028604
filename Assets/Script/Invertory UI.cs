
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;

    public List<GameObject> buttons;

    private void OnEnable()
    {
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        Debug.Log("Refreshing Inventory UI");

        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }

        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (i < buttons.Count)
            {
                InventoryUIButton button = buttons[i].GetComponent<InventoryUIButton>();

                Item item = inventory.items[i];

                button.SetButton(item, i);

                buttons[i].SetActive(true);
            }
        }
    }
}
