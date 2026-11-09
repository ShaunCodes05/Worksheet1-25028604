
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : StarterAssets.ThirdPersonController
{
    void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("pause Input Pressed");
        }
    }

    void OnRemoveItem(InputValue value)
    {
        if (value.isPressed)
        {
            GameCon gameCon = FindAnyObjectByType<GameCon>();

            if (gameCon.currentState == gameCon.GAMEPLAY)
            {
                FindAnyObjectByType<Inventory>().RemoveItemFromInventory(0);
            }
        }
    }
}
