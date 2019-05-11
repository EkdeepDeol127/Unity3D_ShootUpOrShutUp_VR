using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {
    
	private GameObject bullet;
	private Rigidbody rb;
	private float force;
    private float timer;

    void Start () 
	{
        force = 60;
        timer = 2.0f;

		bullet = this.gameObject;
		rb = this.GetComponent<Rigidbody>();
	}
    
	void FixedUpdate () 
	{
		if(bullet.activeSelf == true)
		{
            if(timer <= 0)
            {
                timer = 2.0f;
                this.gameObject.SetActive(false);
            }
            else
            {
                timer -= Time.fixedDeltaTime;
                rb.velocity = bullet.gameObject.transform.forward * force;
            }
		}
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Speeder" || other.gameObject.tag == "Ranger" || other.gameObject.tag == "Tank" || other.gameObject.tag == "Balance")
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.SetActive(false);
        }
    }
}
