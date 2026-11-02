using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : StarterAssets.ThirdPersonController
{
   void Onpause(InputValue value)
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
            Debug.Log("Remove Item");
        }
    }
}
