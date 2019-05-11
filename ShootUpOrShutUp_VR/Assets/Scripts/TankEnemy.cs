using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankEnemy : MonoBehaviour {

    NavMeshAgent agent;
    private GameObject player;
    private PlayerBehavior playerStats;
    private float speed;
    private float health;
    private float attack;
    private float defence;
    private float rangeTemp;
    private float timer;
    private float worth;
    private float temp;
    private SphereCollider range;
    private bool inRange;

    void Start()
    {
        speed = 2.5f;
        timer = 3f;
        inRange = false;
        worth = Random.Range(250, 350);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        health = Random.Range(150, 200);
        health = Mathf.CeilToInt(health);
        attack = Random.Range(20, 30);
        attack = Mathf.CeilToInt(attack);
        defence = Random.Range(30, 50);
        defence = Mathf.CeilToInt(defence);
        range = this.gameObject.GetComponent<SphereCollider>();
        rangeTemp = Random.Range(3, 6);
        rangeTemp = Mathf.CeilToInt(rangeTemp);
        range.radius = rangeTemp;
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerBehavior>();
        agent.destination = player.transform.position;
    }

    void Update()
    {
        if (timer <= 0 && inRange == true)
        {
            playerStats.damagePlayer(attack);
            timer = 3f;
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter trigger");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player trigger");
            inRange = true;
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            defence -= playerStats.attack;
            if (defence <= 0)
            {
                health -= Mathf.Abs(defence);
                defence = 0;
                if (health <= 0)
                {
                    playerStats.addMoney(worth);
                    this.gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}