using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesUI : MonoBehaviour
{
    public Text wavesText;


    // Update is called once per frame
    void Update()
    {
        wavesText.text = "Wave " + PlayerStats.Rounds + "/" + PlayerStats.Waves;
    }
}
