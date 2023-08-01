using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject ShopPanel;

    public void showShopPanel(){
        ShopPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void hideShopPanel(){
        ShopPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
