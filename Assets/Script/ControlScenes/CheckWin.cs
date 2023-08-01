using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    // private int CheckValue;
    // private int CheckValueFormation;
    // public int AllAmountEnemy;
    // public int AllAmountFormation;
    public GameObject WinPanel;

    // public static CheckWin Instance;


    
    // Start is called before the first frame update
    // private void Update()
    // {
    //     Debug.Log(CheckValue);
    //     Instance = this;
    //     if(Instance.CheckValue>=AllAmountEnemy && Instance.CheckValueFormation==AllAmountFormation){
    //         ShowWinPanel();
    //         Instance.CheckValue=0;
    //         Instance.CheckValueFormation=0;
    //     }
    // }

    // public static void AddCountEnemy()
    // {
    //     Instance.CheckValue++;
    // }

    // public static void AddCountEnemyFormation(int addCheckValue)
    // {
    //     Instance.CheckValueFormation += addCheckValue;
    // }
    public void GameWin(){
        StartCoroutine(ShowWinPanel());
    }

    private IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(1f);// set thoi gian delay 
        WinPanel.SetActive(true);
        Time.timeScale=0;
    }

}
