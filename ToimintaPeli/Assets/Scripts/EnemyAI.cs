using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public float maxDistance;
    public bool Dead;
    Animator anim;

    string state = "patrol";
    public GameObject[] waypoints;
    int currentWP = 0;
    float accuracyWP = 2.0f;

    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;

        
	}
	
	// Update is called once per frame
	void Update () 
    {
        EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
        if (enemyHealth.curHealth <= 0)
        {
          //  enemyHealth.isTargetted = false;
            anim.SetBool("isDead", true);
         //   enemyHealth.canvas.SetActive(false);
            Object.Destroy(gameObject, 3.0f);
            return;
        }
           

        Vector3 direction = target.position - myTransform.position;

        if (state == "patrol" && waypoints.Length > 0)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
            {
                currentWP++;
                if (currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }
            }

            //kääntyy waypointtia kohti
            direction = waypoints[currentWP].transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, Time.deltaTime * moveSpeed);
        }

        if (Vector3.Distance(target.position, myTransform.position) < 20)
        {
            
            Debug.DrawLine(target.position, myTransform.position, Color.yellow); // viiva vihollisesta pelaajaan
            // katso kohdetta                        mihin nyt katsotaan                            vihollisen ja pelaajan sijainnit               
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

            anim.SetBool("isIdle", false);
            if (Vector3.Distance(target.position, myTransform.position) > maxDistance)
            {

                state = "pursuing";
                //liikkuminen kohdetta kohti
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                state = "attacking";
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            state = "patrol";
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
        }
	}

}
