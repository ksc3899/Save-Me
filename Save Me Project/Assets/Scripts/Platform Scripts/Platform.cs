using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 2;
    public float boundY = 6f;

    [Header("Plateform Type")]
    public bool speedPlatformLeft;
    public bool speedPlatformRight;
    public bool breakablePlatform;
    public bool spikePlatform;
    public bool standardPlatform;

    private Animator animator;

    private void Awake()
    {
        if(breakablePlatform)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        Move();

        if(this.transform.position.y > boundY)
        {
            Destroy(this.gameObject);
        }
    }

    private void Move()
    {
        Vector2 pos = this.transform.position;
        pos.y += moveSpeed * Time.deltaTime;

        this.transform.position = pos;
    }

    private void BreakableDeactivate()
    {
        Invoke("DeactivateGameobject", 0.5f);
    }

    private void DeactivateGameobject()
    {
        Destroy(this.gameObject);
    }

    /* private void OnTriggerEnter2D(Collider2D target)
    {
        Destroy(target.gameObject); 
    }*/

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(breakablePlatform)
        {
            animator.SetTrigger("Break");
        }
        else if(standardPlatform)
        {
            
        }
    }

    private void OnCollisionStay2D(Collision2D target)
    {
        if(speedPlatformLeft)
        {
            target.gameObject.GetComponent<Player>().SpeedPlatform(-1f);
        }
        else if(speedPlatformRight)
        {
            target.gameObject.GetComponent<Player>().SpeedPlatform(1f);
        }
    }
}
