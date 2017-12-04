using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
    public GameObject target;
    public float attackTimer;
    public float coolDown;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        coolDown = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
        if (enemyHealth.curHealth <= 0) return;

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer < 0)
        {
            attackTimer = 0;
        }
        if (attackTimer == 0)
        {
              Attack();
             
              attackTimer = coolDown;
        }

       

    }
    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        Vector3 dir = (target.transform.position - transform.position).normalized; // molempien sijainnit

        float direction = Vector3.Dot(dir, transform.forward);  // palauttaa -1 ja 1 väliltä luvun jos takana negatiivinen, edessä positiivinen, sivuilla 0

        

        if (distance < 2.5f)
        {
            if (direction > 0)
            {
                PlayerHealth eh = (PlayerHealth)target.GetComponent("PlayerHealth");
                eh.AddjustCurrentHealth(-10);
            }
        }
    }
}
