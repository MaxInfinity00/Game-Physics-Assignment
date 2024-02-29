using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private PlayerInput playerActions;
    
    void Start()
    {
        player = GetComponent<Player>();
        playerActions = new PlayerInput();
        if(playerActions == null)
        {
            Debug.Log("Player actions is null");
        }
        if(player == null)
        {
            Debug.Log("Player is null");
        }
        playerActions.Player.Left.performed += ctx => player.PressedLeft();
        playerActions.Player.Right.performed += ctx => player.PressedRight();
        playerActions.Player.Space.performed += ctx => player.PressedSpace();
        playerActions.Player.Space.canceled += ctx => player.ReleasedSpace();
        playerActions.Player.Enable();
    }

}
