using UnityEngine;

public class PlayerHareketController : MonoBehaviour
{
    Rigidbody2D rb;// Rigidbody2D bileþeni

    public float hareketHizi; // Player hareket hýzý
    public float ziplamaGucu; // Player zýplama gücü


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();// Rigidbody2D bileþenini al
    }

    private void Update()
    {
        HareketEt();
    }

    void HareketEt()
    {
        float h = Input.GetAxis("Horizontal");// Yatay eksende hareket giriþi
        rb.linearVelocity = new Vector2(h * hareketHizi, rb.linearVelocity.y); // Yatay hareket

    }
}
