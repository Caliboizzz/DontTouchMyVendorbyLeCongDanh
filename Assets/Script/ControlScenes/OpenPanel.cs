using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;
    public void ShowPanel()
    {
        Panel.SetActive(true);
    }
    public void HidePanel()
    {
        Panel.SetActive(false);
    }
}
