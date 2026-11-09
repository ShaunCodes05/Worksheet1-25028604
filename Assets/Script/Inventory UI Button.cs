
using TMPro;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    public TMP_Text Text;

    private Inventory inventory;
    private InventoryUI inventoryUI;

    private int currentIndex;

    private void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
        inventoryUI = FindAnyObjectByType<InventoryUI>();
    }

    public void SetButton(Item item, int index)
    {
        currentIndex = index;

        Text.text = item.name;
    }

    public void OnButtonPressed()
    {
        if (inventory != null)
        {
            inventory.RemoveItemFromInventory(currentIndex);

            inventoryUI.RefreshInventory();
        }
    }
}
