using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{

    public GameObject ControlAddButton;
    public GameObject ControlDestroyButton;
    public Transform PointSpawn;
    public int PriceSlot1;
    public GameObject Item1;
    public int PriceSlot2;
    public GameObject Item2;
    public int PriceSlot3;
    public GameObject Item3;
    public GameObject TextAlert;

    public TMP_Text pricetext1;
    public TMP_Text pricetext2;
    public TMP_Text pricetext3;


    // public static ShoppingManager Instance;
    private GameObject Clone;

    private void Start()
    {

        ShowPriceSlot1();
        ShowPriceSlot2();
        ShowPriceSlot3();
    }

    private void Update()
    {

    }


    // private void Update()
    // {
    //     Instance = this;
    //     ShowScore();
    // }

    // public static void AddScore(int addedScore)
    // {
    //     Instance.score += addedScore;
    //     Instance.ShowScore();
    // }

    //private void ShowScore() => scoretext.text = score.ToString();
    private void ShowPriceSlot1() => pricetext1.text = PriceSlot1.ToString();
    private void ShowPriceSlot2() => pricetext2.text = PriceSlot2.ToString();
    private void ShowPriceSlot3() => pricetext3.text = PriceSlot3.ToString();


    public void SentryTier1()
    {
        if (Scoring.GetScoreBudget >= PriceSlot1)
        {
            Scoring.ReduceScore(PriceSlot1);
            Clone = Instantiate(Item1, PointSpawn.position, Quaternion.identity);
            ControlAddButton.gameObject.SetActive(false);
            ControlDestroyButton.gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(ShowDontHaveMonney());
        }


    }
    public void SentryTier2()
    {
        if (Scoring.GetScoreBudget >= PriceSlot2)
        {
            Scoring.ReduceScore(PriceSlot2);
            Clone = Instantiate(Item2, PointSpawn.position, Quaternion.identity);
            ControlAddButton.gameObject.SetActive(false);
            ControlDestroyButton.gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(ShowDontHaveMonney());
        }


    }
    public void SentryTier3()
    {
        if (Scoring.GetScoreBudget >= PriceSlot3)
        {
            Scoring.ReduceScore(PriceSlot3);
            Clone = Instantiate(Item3, PointSpawn.position, Quaternion.identity);
            ControlAddButton.gameObject.SetActive(false);
            ControlDestroyButton.gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(ShowDontHaveMonney());
        }


    }

    public void DestroySentry()
    {
        GameObject.Destroy(Clone);
        ControlAddButton.gameObject.SetActive(true);
        ControlDestroyButton.gameObject.SetActive(false);
    }

    IEnumerator ShowDontHaveMonney()
    {
        TextAlert.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        TextAlert.SetActive(false);
    }
}
