using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int hp = 3;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void OnDamage(int damage) 
    {
        hp -= damage;
        animator.SetTrigger("IsHurt");
        if (hp <= 0) {
            Die();
        }

    }

    void Die() {
        hp = 0;
        animator.SetTrigger("Die");
    }
}
