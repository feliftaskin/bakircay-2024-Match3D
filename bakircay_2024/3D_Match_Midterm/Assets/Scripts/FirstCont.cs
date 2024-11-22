using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCont : MonoBehaviour
{
    public GameManager gm;
    public GameObject currentObject; // Üstüne yerleştirilen nesne

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerStay(Collider col)
    {
        // Birinci kontrolcüdeki nesneyi kontrol ediyoruz
        if (gm.One == null)
        {
            gm.One = col.gameObject; // İlk nesneyi GameManager'a ata
        }

        currentObject = col.gameObject; // Mevcut nesneyi sakla
    }

    private void OnTriggerExit(Collider col)
    {
        // Nesne tetik alanından çıkarsa sıfırla
        if (col.gameObject == gm.One)
        {
            gm.One = null;
        }
    }
}
