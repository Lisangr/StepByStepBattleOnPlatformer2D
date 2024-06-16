using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private int jumpsRemaining;
    private Transform player;
    private Animator animator;
    private bool grounded;
    private int m_facingDirection;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
        player = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        StartCoroutine(LoadPlayerPosition());
    }

    public void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if ((Mathf.Abs(moveX) > 0 || Mathf.Abs(moveX) < 0) && grounded == true)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }

        float moveY = rb.velocity.y;
        if ((Mathf.Abs(moveY) > 0 || Mathf.Abs(moveY) < 0) && grounded == false)
        {
            animator.SetTrigger("Fall");
        }
        else
        {
            animator.SetTrigger("NotFall");
            grounded = true;
        }

        if (moveX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
        }
        else if (moveX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
        }

        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;

            grounded = false;
            animator.SetTrigger("Jump");
        }

        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

        if (currentState.IsName("Jump") && currentState.normalizedTime >= 1.0f)
        {
            animator.SetTrigger("ToFall");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {           
            SavePlayerPosition();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (rb.velocity != null)
            {
                animator.SetTrigger("Run");
            }
            jumpsRemaining = maxJumps;
            SavePlayerPosition();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SavePlayerPosition();
        }
    }

    private void SavePlayerPosition()
    {
        Vector3 position = player.transform.position;
        PlayerPrefs.SetFloat("PlayerX", position.x);
        PlayerPrefs.SetFloat("PlayerY", position.y);
        PlayerPrefs.SetFloat("PlayerZ", position.z);
        PlayerPrefs.Save();
    }
    private IEnumerator LoadPlayerPosition()
    {
        //if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        //{
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");
            player.transform.position = new Vector3(x, y, z);

            yield return null;

            //PlayerPrefs.DeleteKey("PlayerX");
            //PlayerPrefs.DeleteKey("PlayerY");
            //PlayerPrefs.DeleteKey("PlayerZ");
        //}
    }
}