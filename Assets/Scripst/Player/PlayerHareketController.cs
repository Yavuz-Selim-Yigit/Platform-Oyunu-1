using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHareketController : MonoBehaviour
{
    #region Deðiþkenler
    Rigidbody2D rb;// Rigidbody2D bileþeni


    #region zemin kontrolü && zýplama
    [Header("Zýplama Ayarlarý")]

    public float ziplamaGucu; // Player zýplama gücü
    [SerializeField]// zemin kontrolü için
    Transform zeminKontrolNoktasi; // Zemin kontrol noktasý

    bool zemindeMi; // Player zeminde mi?
    bool ikinciZiplama; // Player havada mý?

    public LayerMask zeminMaske;// Zemin katmaný

    #endregion


    #region Animasyon
    [Header("Animasyon Ayarlarý")]
    [SerializeField]
    Animator anim;// Animatör bileþeni
    #endregion


    #region Hareket

    [Header("Hareket Ayarlarý")]
    public float hareketHizi; // Player hareket hýzý

    #endregion



    #endregion




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();// Rigidbody2D bileþenini al
    }

    private void Update()
    {
        HareketEt();
        Ziplama();

        anim.SetBool("zemindeMi", zemindeMi); // Animasyona zeminde olup olmadýðýný bildir
        anim.SetFloat("hareketHizi", Mathf.Abs(rb.linearVelocity.x)); // Animasyona yatay hýzý bildir
    }


    #region Yatay Hareket
    void HareketEt()
    {
        float h = Input.GetAxis("Horizontal");// Yatay eksende hareket giriþi
        rb.linearVelocity = new Vector2(h * hareketHizi, rb.linearVelocity.y); // Yatay hareket

    }
    #endregion

    #region Zýplama
    void Ziplama()
    {
        zemindeMi = Physics2D.OverlapCircle(zeminKontrolNoktasi.position, .2f, zeminMaske);

        if (Input.GetButtonDown("Jump") && (zemindeMi || ikinciZiplama))
        {
            if (zemindeMi)
            {
                ikinciZiplama = true; // Havada olduðunu iþaretle
            }
            else
            {
                ikinciZiplama = false; // Ýkinci zýplamadan sonra havada olmadýðýný iþaretle
            }
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, ziplamaGucu); // Zýplama hareketi
            
        }


       

    }
    #endregion


}