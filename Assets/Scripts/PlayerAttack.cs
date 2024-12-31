using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator animator;
    private PlayerMovement playerMovement;
    private float cooldownTimer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && (cooldownTimer > attackCooldown))
        //if (Input.GetMouseButton(0) && (cooldownTimer > attackCooldown) && playerMovement.canAttack())
        {
            Console.WriteLine("atta");
            Attack();

        }

        cooldownTimer += Time.deltaTime;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        // To make sure players can attack in the beginning
        cooldownTimer = Mathf.Infinity;
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        cooldownTimer = 0;
    }
}
