using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    Vector2 axes => playerInputActions.GamePlay.Axex.ReadValue<Vector2>();
    public bool IsJump => playerInputActions.GamePlay.Jump.WasPressedThisFrame();

    public bool StopJump => playerInputActions.GamePlay.Jump.WasReleasedThisFrame();

    // Start is called before the first frame update

    public bool StartMove => AxisX != 0;

    public float AxisX => axes.x;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();    

    }

    public void EnableGamePlayInputs()
    {
        playerInputActions.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;


    }

}
