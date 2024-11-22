using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCont : MonoBehaviour
{
    public GameManager gm;
    public GameObject currentObject; // Üstüne yerleştirilen nesne

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerStay(Collider col)
    {
        // İkinci kontrolcüdeki nesneyi kontrol ediyoruz
        if (gm.Two == null)
        {
            gm.Two = col.gameObject; // İkinci nesneyi GameManager'a ata
        }

        currentObject = col.gameObject; // Mevcut nesneyi sakla
    }

    private void OnTriggerExit(Collider col)
    {
        // Nesne tetik alanından çıkarsa sıfırla
        if (col.gameObject == gm.Two)
        {
            gm.Two = null;
        }
    }
}
