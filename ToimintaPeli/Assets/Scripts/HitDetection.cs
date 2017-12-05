using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour {
    public int health;
    public int damage;

    void OnTriggerEnter(Collider other)
    {

        EnemyHealth eh = other.GetComponent<EnemyHealth>();

        
        Debug.Log("osuma");
        eh.curHealth -= damage;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
