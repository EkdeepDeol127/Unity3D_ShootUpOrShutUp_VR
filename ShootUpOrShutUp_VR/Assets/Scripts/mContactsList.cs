using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class mContactsList : MonoBehaviour {

    public LineRenderer LN;
    public ShopBehavior shop;
    private Image hold;
    private GameObject temp;
    public GameObject barrel;
    public GameObject endSelect;
    private Color blank;
    public SteamVR_Action_Boolean testBuy;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    void Start ()
    {
        testBuy.AddOnChangeListener(selectBuy, inputSource);
        LN = this.gameObject.GetComponent<LineRenderer>();
        LN.SetWidth(0.01f, 0.01f);
        blank.a = 0;
        LN.SetColors(blank, blank);
    }


    void Update()
    {
        if(shop.shopOpen == true)
        {
            LN.SetColors(Color.white, Color.white);
            LN.SetPosition(0, barrel.transform.position);
            LN.SetPosition(1, endSelect.transform.position);
        }
        else
        {
            LN.SetColors(blank, blank);
        }

        int layerMask = 1 << 16;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            hold = hit.collider.gameObject.GetComponent<Image>();
            LN.SetColors(hold.color, hold.color);
            temp = hit.collider.gameObject;
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            temp = null;
        }
    }

    void selectBuy(SteamVR_Action_In action_In)
    {
        if(temp.tag == "AmmoBuy")
        {
            shop.addAmmo();
        }
        else if (temp.tag == "ArmorBuy")
        {
            shop.addArmor();
        }
        else if (temp.tag == "HealthBuy")
        {
            shop.addHealth();
        }
    }
}
