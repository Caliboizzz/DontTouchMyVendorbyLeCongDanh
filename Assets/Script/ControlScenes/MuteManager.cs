using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteManager : MonoBehaviour
{
    // public GameObject SoundOnBtn;
    // public GameObject SoundOffBtn;
    private bool IsMute;
    // Start is called before the first frame update
    void Start()
    {
        IsMute = PlayerPrefs.GetInt("MUTED")==1;
    }

    public void Mute()
    {
        IsMute = !IsMute;
        AudioListener.pause = IsMute;
        PlayerPrefs.SetInt("MUTED",IsMute?1:0);
    }
    // void Start()
    // {
    //     AudioListener.pause=false;
    // }

    // public void IsMute()
    // {
    //     SoundOnBtn.SetActive(true);
    //     SoundOffBtn.SetActive(false);
    //     AudioListener.pause = true;

    // }
    // public void IsMuteFalse()
    // {
    //     SoundOnBtn.SetActive(false);
    //     SoundOffBtn.SetActive(true);
    //     AudioListener.pause = false;

    // }

}
