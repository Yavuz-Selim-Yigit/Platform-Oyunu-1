using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHareketController : MonoBehaviour
{
    #region De�i�kenler
    Rigidbody2D rb;// Rigidbody2D bile�eni


    #region zemin kontrol� && z�plama
    [Header("Z�plama Ayarlar�")]

    public float ziplamaGucu; // Player z�plama g�c�
    [SerializeField]// zemin kontrol� i�in
    Transform zeminKontrolNoktasi; // Zemin kontrol noktas�

    bool zemindeMi; // Player zeminde mi?
    bool ikinciZiplama; // Player havada m�?

    public LayerMask zeminMaske;// Zemin katman�

    #endregion



    #region Hareket

    [Header("Hareket Ayarlar�")]
    public float hareketHizi; // Player hareket h�z�

    #endregion



    #endregion




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();// Rigidbody2D bile�enini al
    }

    private void Update()
    {
        HareketEt();
        Ziplama();
    }


    #region Yatay Hareket
    void HareketEt()
    {
        float h = Input.GetAxis("Horizontal");// Yatay eksende hareket giri�i
        rb.linearVelocity = new Vector2(h * hareketHizi, rb.linearVelocity.y); // Yatay hareket

    }
    #endregion

    #region Z�plama
    void Ziplama()
    {
        zemindeMi = Physics2D.OverlapCircle(zeminKontrolNoktasi.position, .2f, zeminMaske);

        if (Input.GetButtonDown("Jump") && (zemindeMi || ikinciZiplama))
        {
            if(zemindeMi)
            {
                ikinciZiplama = true; // Havada oldu�unu i�aretle
            }
            else
            {
                ikinciZiplama = false; // �kinci z�plamadan sonra havada olmad���n� i�aretle
            }

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, ziplamaGucu);
        }

        
    }
    #endregion

}