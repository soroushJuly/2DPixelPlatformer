using System;
using System.Collections.ObjectModel;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private AudioClip attackSound;

    private Animator animator;
    private PlayerMovement playerMovement;
    private float cooldownTimer;

    private float m_playerDamage = 40;
    public void SetPlayerDamage(float damage) { m_playerDamage = damage; }

    private Collection<Collider2D> _hitColliderList;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0) && (cooldownTimer > attackCooldown) && )
        if (Input.GetMouseButton(0) && (cooldownTimer > attackCooldown) && playerMovement.canAttack())
        {
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

        _hitColliderList = new Collection<Collider2D>();
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        SoundManager.instance.PlaySound(attackSound);
        cooldownTimer = 0;
    }

    private void CheckHit()
    {
        for (int i = 0; i < _hitColliderList.Count; i++)
        {
            // kill the small enemies instantly
            if (_hitColliderList[i].CompareTag("Enemy"))
            {
                _hitColliderList[i].gameObject.SetActive(false);
            }
            else if (_hitColliderList[i].CompareTag("Boss"))
            {
                _hitColliderList[i].GetComponent<EnemyBoss>().TakeDamage(m_playerDamage);
            }
        }
    }

    public void AddCollision(Collider2D collision)
    {
        _hitColliderList.Add(collision);
    }
    public void RemoveCollision(Collider2D collision)
    {
        _hitColliderList.Remove(collision);
    }
}
