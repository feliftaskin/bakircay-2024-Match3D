using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject One; // Birinci kontrolcünün nesnesi
    public GameObject Two; // İkinci kontrolcünün nesnesi
    public bool dest = false; // Fırlatma işlemini tetiklemek için

    void Start()
    {
        One = null;
        Two = null;
    }

    void Update()
    {
        if (One != null && Two != null)
        {
            if (One.gameObject.tag != Two.gameObject.tag) // Tag kontrolü
            {
                dest = true;
                StartCoroutine(WaitTime());
            }
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1f); // Bir saniye bekle

        if (dest)
        {
            // Fırlatma işlemi
            ThrowObject(One);
            ThrowObject(Two);
        }

        dest = false;

        // Nesneleri sıfırla
        One = null;
        Two = null;
    }

    void ThrowObject(GameObject obj)
    {
        if (obj != null)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>(); // Rigidbody bileşenini al
            if (rb != null)
            {
                // Kontrolcünün x eksenindeki yönü al
                float throwDirectionY = obj.transform.position.y + 5f; // x ekseninde 10 birim yukarıya doğru fırlatma

                // x ekseninde nesneyi fırlat
                Vector3 throwDirection = new Vector3(0f, throwDirectionY, 0f) - obj.transform.position;

                // Kuvvetle fırlat
                float throwForce = 50f; // Kuvveti ayarlayabilirsiniz
                rb.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
            }
        }
    }
}
