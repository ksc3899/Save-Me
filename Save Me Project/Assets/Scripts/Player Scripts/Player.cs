using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    [Space]
    public float minimumX;
    public float maximumX, minimumY, maximumY;
    
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minimumX, maximumX), transform.position.y);

        if (transform.position.y < minimumY)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }

    public void SpeedPlatform(float x)
    {
        rb.velocity = new Vector2(x, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        Destroy(this.gameObject);
    }
}
