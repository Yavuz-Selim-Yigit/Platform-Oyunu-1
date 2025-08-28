using UnityEngine;

public class PlayerHareketController : MonoBehaviour
{
    Rigidbody2D rb;// Rigidbody2D bile�eni

    public float hareketHizi; // Player hareket h�z�
    public float ziplamaGucu; // Player z�plama g�c�


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();// Rigidbody2D bile�enini al
    }

    private void Update()
    {
        HareketEt();
    }

    void HareketEt()
    {
        float h = Input.GetAxis("Horizontal");// Yatay eksende hareket giri�i
        rb.linearVelocity = new Vector2(h * hareketHizi, rb.linearVelocity.y); // Yatay hareket

    }
}
