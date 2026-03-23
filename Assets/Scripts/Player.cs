using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] InputSystem inputSystem;
    public DodgerAttributes dodgerAttributes;
    public Gestures_DoubleTap hasShield;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dodgerAttributes = new DodgerAttributes(3, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        int moveDir = 0;

        Vector2 screenPos;

        if (inputSystem.IsPressing(out screenPos))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint
                (new Vector3(screenPos.x, screenPos.y, 0f));

            if (touchPos.x < 0)
            {
                moveDir = -1;
            }
            else
            {
                moveDir = 1;
            }
        }
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

            if (viewportPos.x <=0f && moveDir<0 || (viewportPos.x>=1 && moveDir > 0))
            {
                moveDir = 0;
            }

            rb.linearVelocityX = moveDir * moveSpeed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasShield.hasShield) 
        { 
        if (collision.gameObject.CompareTag("Enemy"))
            dodgerAttributes.SetHealth(dodgerAttributes.GetCurrentHealth() - 1);
        if (collision.gameObject.CompareTag("Enemy") && dodgerAttributes.GetCurrentHealth() == 0)
        {
            SceneManager.LoadScene(1);
        }
        }
    }
    
}
