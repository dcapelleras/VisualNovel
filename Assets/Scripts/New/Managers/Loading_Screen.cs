using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;

public class Loading_Screen : MonoBehaviour
{
    [SerializeField] TMP_Text tipText;
    public string[] tips;


    private void OnEnable()
    {
        int randomInt = Random.Range(0, tips.Length);
        tipText.text = tips[randomInt];
    }
}
