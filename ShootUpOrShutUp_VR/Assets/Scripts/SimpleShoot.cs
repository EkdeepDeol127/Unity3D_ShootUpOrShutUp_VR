using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class SimpleShoot : MonoBehaviour {
    
	private GameObject[] pool;
	public GameObject bullet;
    public GameObject barrelAK;
    public GameObject[] barrel;
    private GameObject player;
    private PlayerBehavior playerStats;
    private Animator fireAK;
    private float timer;
    private bool triggerPressed;
    public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Boolean grip;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    void Start () 
	{
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerBehavior>();

        timer = 0.0f;

        trigger.AddOnChangeListener(triggerPressedAndReleased, inputSource);
        grip.AddOnChangeListener(reloadAmmo, inputSource);
        triggerPressed = false;

        barrel = new GameObject[5];

        pool = new GameObject[30];
		for (int i = 0; i < 30; i++)
		{
			pool[i] = Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
			pool[i].SetActive(false);
		}
	}

    void triggerPressedAndReleased(SteamVR_Action_In action_In)
    {
        if(triggerPressed == false)
        {
            triggerPressed = true;
        }
        else
        {
            triggerPressed = false;
        }
    }

   void FixedUpdate () 
	{
        if(timer <= 0)
        {
            if (triggerPressed == true)
            {
                timer = 0.2f;
                fireBullet();
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Tab))//to switch gun
        {

        }
	}

    void reloadAmmo(SteamVR_Action_In action_In)
    {
        Debug.Log("Reloading");
        if (playerStats.ammoTot > 0)
        {
            if (playerStats.ammoTot < 30)
            {
                if ((playerStats.ammoCur + playerStats.ammoTot) <= 30)
                {
                    playerStats.ammoCur += playerStats.ammoTot;
                    playerStats.ammoTot = 0;
                }
                else
                {
                    playerStats.ammoCur = 30;
                    playerStats.ammoTot = ((playerStats.ammoTot + playerStats.ammoCur) - 30);
                }

            }
            else
            {
                playerStats.ammoTot -= (30 - playerStats.ammoCur);
                playerStats.ammoCur = 30;
            }
            playerStats.updateStats();
        }
    }

    void fireBullet()
    {
        /*if (timer <= 0)
        {
            Debug.Log("Firing");
            for (int j = 0; j < barrel.Length; j++)//might have to maually set the barrels and have dif if statments to fire
            {
                if (barrel[j] == null)
                {
                    break;
                }
                for (int i = 0; i < 30; i++)
                {
                    if (pool[i].activeSelf != true && playerStats.ammoCur > 0)//animate also
                    {

                        playerStats.ammoCur--;
                        playerStats.updateStats();
                        pool[i].SetActive(true);
                        pool[i].gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        pool[i].transform.position = barrel[j].transform.position;
                        pool[i].transform.rotation = barrel[j].transform.rotation;
                        timer = 0.2f;
                        break;
                    }
                    else
                    {
                        playerStats.Ammo.text = "Ammo: RELOAD!";
                    }
                }
            }
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }*/

        for (int i = 0; i < 30; i++)
        {
            if (pool[i].activeSelf != true && playerStats.ammoCur > 0)//animate also
            {

                playerStats.ammoCur--;
                playerStats.updateStats();
                pool[i].SetActive(true);
                pool[i].gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                pool[i].transform.position = barrelAK.transform.position;
                pool[i].transform.rotation = barrelAK.transform.rotation;
                break;
            }
            else
            {
                playerStats.Ammo.text = "Ammo: RELOAD!";
            }
        }
    }
}
