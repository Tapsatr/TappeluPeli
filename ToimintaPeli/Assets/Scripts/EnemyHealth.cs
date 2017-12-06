using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
        public int maxHealth = 100;
        public int curHealth = 100;
        public bool isDead = false;
        Animator anim;
       
       // public float healthBarLengh;
       
        // Use this for initialization
        void Start () {
            anim = GetComponent<Animator>();
            
        }
        void OnTriggerEnter(Collider other)
        {
            var rigidbody = other.GetComponent<Rigidbody>();

            if(rigidbody.velocity.magnitude > 2)
            {
                Debug.Log("KovempiVauhti");
                curHealth -= 50;
            }
         
        }
       
        // Update is called once per frame
        void Update () 
        {
                if(curHealth == 0)
                {
                    isDead = true;
                    anim.enabled = false;
                }
        }
       
   
       
}