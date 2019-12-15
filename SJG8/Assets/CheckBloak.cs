using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBloak : MonoBehaviour
{
    public Player player;
    public MoveState state;
    public JoystickController controller;
    private void OnMouseDown()
    {
        //clamp
        controller.MoveToTarget(state);
        player.Shoot();
    }
}
