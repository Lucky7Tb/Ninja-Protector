using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float horizontalMove = 0f;
    private GameObject healthBar;

    private void Start() {
        healthBar = GameObject.Find("HealthBar");        
    }

    public void move(float direction, float moveSpeed) 
    {
        horizontalMove = direction * moveSpeed;
        animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMove));
        if (direction < 0 || direction > 0)
        {
            Vector3 playerScale = transform.localScale;
            playerScale.x = direction;
            transform.localScale = playerScale;
        } 
    }

    void FixedUpdate() {
        if(horizontalMove != 0)
        {
            Vector3 moveTo = horizontalMove > 0 ? Vector3.right : Vector3.left;
            transform.Translate(moveTo * Time.deltaTime * Mathf.Abs(horizontalMove));
            healthBar.transform.Translate(moveTo * Mathf.Abs(horizontalMove));
        }
    }
}
