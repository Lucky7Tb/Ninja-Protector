using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float playerSpeed = 30f;
    public float horizontalMove = 0f;
    public Rigidbody2D playerRigidbody;
    public Animator animator;

    public void Move(float direction) {
        horizontalMove = direction * playerSpeed;
        animator.SetFloat("player_speed", Mathf.Abs(horizontalMove));
        Vector3 playerScale = transform.localScale;
        if (direction < 0 || direction > 0)
        {
            playerScale.x = direction;
        } 
        transform.localScale = playerScale;
    }

    void FixedUpdate() {
       playerRigidbody.velocity = new Vector2(horizontalMove * 10f * Time.fixedDeltaTime, playerRigidbody.velocity.y);
    }
}
