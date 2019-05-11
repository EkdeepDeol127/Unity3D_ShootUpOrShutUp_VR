using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour {

    public float attack;
    public float armor;
    public float healthAmount;
    public float money;
    public float ammoCur;
    public float ammoTot;
    private float temp;
    public Text Health;
    public Text Armor;
    public Text Ammo;
    public Text Money;
    public Image healthBar;
    public Image ArmorBar;

	void Start ()
    {
        money = 100;
        attack = 20;
        armor = 500;
        healthAmount = 1000f;
        ammoCur = 30;
        ammoTot = 90;
        updateStats();
    }

    /*void Update()
    {

    }*/

    public void updateStats()
    {
        Armor.text = "Armor: " + armor;
        temp = armor / 1000f;
        ArmorBar.rectTransform.sizeDelta = new Vector2(temp, 0.05f);
        Health.text = "Health: " + healthAmount;
        temp = healthAmount / 1000f;
        healthBar.rectTransform.sizeDelta = new Vector2(temp, 0.05f);
        Ammo.text = "Ammo: " + ammoCur + "/" + ammoTot;
        Money.text = "Money: " + money;
    }

    public void damagePlayer(float AttackAmount)
    {
        armor -= AttackAmount;
        if (armor <= 0)//for health after armor
        {
            healthAmount -= Mathf.Abs(armor);
            armor = 0;
        }
        updateStats();
    }

    public void addMoney(float MoneyAmount)
    {
        money += MoneyAmount;
        updateStats();
    }
}
