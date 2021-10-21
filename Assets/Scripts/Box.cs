using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour 
{
    public enum BoxOwner { None, Player, Enemy }
    public BoxOwner owner = BoxOwner.None;

    public float moveSpeed;
    Vector3 moveDirection = Vector3.zero;

    private void Update()
    {
        if (owner == BoxOwner.None)
            return;

        moveDirection = owner == BoxOwner.Player ? Vector3.right : Vector3.left;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (CheckBoxHitCharacterBack(collision.GetComponent<PlayerMovement>()))
            {
                owner = BoxOwner.None;
                Debug.Log("Player Back is Collide!");
            }
            else
            {
                owner = BoxOwner.Player;
            }
        }
    }

    private bool CheckBoxHitCharacterBack(PlayerMovement player)
    {
        return player.direction == PlayerMovement.CharacterDirection.Left ? true : false;
    }
}
