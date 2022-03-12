using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerAttackDamage = 20f;
    public float playerHealth = 100f;
    public PlayerAttack playerAttack;
    public PlayerControler playerControler;

    void Start() {
        playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();    
    }

    // Update is called once per frame
    void Update()
    {
        playerControler.Move(Input.GetAxisRaw("Horizontal"));
        
        if(Input.GetMouseButtonDown(0)) {
            playerAttack.Attack();
        }
    }
}
