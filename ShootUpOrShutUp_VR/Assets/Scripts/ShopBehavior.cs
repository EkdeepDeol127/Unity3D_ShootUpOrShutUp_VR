using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ShopBehavior : MonoBehaviour {

    public GameObject Shop;
    private GameObject player;
    private PlayerBehavior playerStats;
    public Text money;
    public Text ammo;
    public Text armor;
    public Text health;
    public Button buyAmmo;
    public Button buyArmor;
    public Button buyHealth;
    public Button back;
    public bool shopOpen;
    private float temp;
    public SteamVR_Action_Boolean testShop;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerBehavior>();
        buyAmmo.onClick.AddListener(addAmmo);
        buyArmor.onClick.AddListener(addArmor);
        buyHealth.onClick.AddListener(addHealth);
        back.onClick.AddListener(ClickBack);
        testShop.AddOnChangeListener(OpenShop, inputSource);
        shopOpen = false;
        Shop.SetActive(false);
    }

    void OpenShop(SteamVR_Action_In action_In)
    {
        if (shopOpen == false)
        {
            Time.timeScale = 0;
            Shop.SetActive(true);
            shopOpen = true;
            updateStats();
        }
        else
        {
            Time.timeScale = 1;
            shopOpen = false;
            playerStats.updateStats();
            Shop.SetActive(false);
        }
    }

    void updateStats()
    {
        money.text = "Money: " + playerStats.money;
        ammo.text = "Ammo: " + playerStats.ammoTot;//does not count ammo in clip
        armor.text = "Armor: " + playerStats.armor;
        health.text = "Health: " + playerStats.healthAmount;
    }

    public void addAmmo()
    {
        if(playerStats.money >= 100)
        {
            playerStats.ammoTot += 180;
            playerStats.money -= 100;
            money.text = "Money: " + playerStats.money;
            ammo.text = "Ammo: " + playerStats.ammoTot;//does not count ammo in clip
        }
        else
        {
            money.text = "Money: " + playerStats.money + ", NOT ENOUGH";
        }
    }

    public void addArmor()
    {
        if (playerStats.armor < 500)
        {
            if (playerStats.money >= 100)
            {
                playerStats.armor += 100;
                playerStats.money -= 100;
                if (playerStats.armor > 500)
                {
                    playerStats.armor = 500;
                }
                money.text = "Money: " + playerStats.money;
                armor.text = "Armor: " + playerStats.armor;
            }
            else
            {
                money.text = "Money: " + playerStats.money + ", NOT ENOUGH";
            }
        }
        else
        {
            Debug.Log("Armor Full");
        }
    }

    public void addHealth()
    {
        if (playerStats.healthAmount < 1000)
        {
            if (playerStats.money >= 200)
            {
                playerStats.healthAmount += 250;
                playerStats.money -= 200;
                if (playerStats.healthAmount > 1000)
                {
                    playerStats.healthAmount = 1000;
                }
                money.text = "Money: " + playerStats.money;
                health.text = "Health: " + playerStats.healthAmount;
            }
            else
            {
                money.text = "Money: " + playerStats.money + ", NOT ENOUGH";
            }
        }
        else
        {
            Debug.Log("Health Full");
        }
    }

    void ClickBack()
    {
        Time.timeScale = 1;
        shopOpen = false;
        playerStats.updateStats();
        Shop.SetActive(false);
    }
}
