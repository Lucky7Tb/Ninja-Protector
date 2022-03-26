using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float damage = 20f;
    public float health = 100f;
    public float moveSpeed = 8f;
    float attackRate = 2f;
    float nextAttackTime = 0f;
    
    PlayerAttack playerAttack;
    PlayerController playerController;

    void Start() {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        playerAttack = GameObject.FindObjectOfType<PlayerAttack>();    
    }

    void Update()
    {
        playerController.move(Input.GetAxisRaw("Horizontal"), moveSpeed);
       
        if(Time.time > nextAttackTime) 
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                playerAttack.attack(damage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
}
