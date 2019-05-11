using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject enemy;
    private float timer;
    private float timerTemp;
    private string type;
    private GameObject[] EnemySpawns;

    void Start ()
    {
        timer = timerTemp;
        EnemySpawns = new GameObject[10];
        type = enemy.gameObject.tag;
        switch (type)
        {
            case "Tank":
                timerTemp = 60f;
                break;
            case "Ranger":
                timerTemp = 40f;
                break;
            case "Speeder":
                timerTemp = 20f;
                break;
            case "Balance":
                timerTemp = 50f;
                break;
            default:
                timerTemp = 1000f;
                Debug.Log("Default Enemy Error!");
                break;
        }
        for (int i = 0; i < 10; i++)
        {
            EnemySpawns[i] = Instantiate(enemy, this.transform.position, this.transform.rotation);
            EnemySpawns[i].SetActive(false);
        }
    }
	
	void FixedUpdate ()
    {
        if (timer <= 0)
        {
            for (int i = 0; i < 20; i++)
            {
                if (EnemySpawns[i].activeSelf != true)
                {
                    EnemySpawns[i].SetActive(true);
                    EnemySpawns[i].transform.position = this.gameObject.transform.position;
                    EnemySpawns[i].transform.rotation = this.gameObject.transform.rotation;
                    timer = timerTemp;
                    break;
                }
            }
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
    }
}
