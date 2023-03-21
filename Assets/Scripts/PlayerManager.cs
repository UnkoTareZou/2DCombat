using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 3;
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    Rigidbody2D rb;
    Animator animator;
    int at = 1;
    float attcakTimer = 2f;
    float attackCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackCounter = attcakTimer;

	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();

        }

        Movement();
    }

    void Attack()
    {
        animator.SetTrigger("IsAttack");
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            Debug.Log(hitEnemy.gameObject.name+"Ç…çUåÇ");
            hitEnemy.GetComponent<EnemyManager>().OnDamage(at);
        }
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
	}


	void Movement()
    {
		float x = Input.GetAxisRaw("Horizontal");//êÖïΩï˚å¸ÉLÅ[

		if (x > 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		if (x < 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}

		animator.SetFloat("Speed", Mathf.Abs(x));
		rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
	}
}
