using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform _t;
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private bool isJumping = false;

    [SerializeField]
    private float Speed = 4f;

    [SerializeField]
    private float Jump = 10f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-Speed * 15, transform.localPosition.y));
            if (Input.GetKey(KeyCode.B))
            {
                float originalGravity = rb.gravityScale;
                rb.gravityScale = 0f;
                rb.AddForce(new Vector2(-Speed * 2, transform.position.y), ForceMode2D.Impulse);
                // HP-=10.0f;
                // Debug.Log(HP);
                rb.gravityScale = originalGravity;
                rb.velocity = Vector2.zero;
            }
            else if (Input.GetKeyDown(KeyCode.W) && !isJumping)
            {
                rb.AddForce(new Vector2(transform.localPosition.x, Jump * 130), ForceMode2D.Force);
                isJumping = true;
                rb.AddForce(new Vector2(transform.position.x, Jump * 60));
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(Speed * 15, transform.localPosition.y));
            if (Input.GetKey(KeyCode.B))
            {
                float originalGravity = rb.gravityScale;
                rb.gravityScale = 0f;
                rb.AddForce(new Vector2(Speed * 2, transform.position.y), ForceMode2D.Impulse);
                // HP-=10.0f;
                // Debug.Log(HP);
                rb.gravityScale = originalGravity;
                // rb.velocity = Vector2.zero;
            }
            else if (Input.GetKeyDown(KeyCode.W) && !isJumping)
            {
                rb.AddForce(new Vector2(transform.localPosition.x, Jump * 130), ForceMode2D.Force);
                isJumping = true;
                rb.AddForce(new Vector2(transform.position.x, Jump * 60));
            }
        }
        else if (Input.GetKey(KeyCode.W) && !isJumping)
        {
            rb.AddForce(new Vector2(transform.position.x, Jump * 130), ForceMode2D.Force);
            isJumping = true;
        }
        else if (Input.GetKey(KeyCode.Q) && !isJumping)
        {
            rb.AddForce(new Vector2(-Speed * 90, Jump * 130), ForceMode2D.Force);
            isJumping = true;
        }
        else if (Input.GetKey(KeyCode.E) && !isJumping)
        {
            if (Input.GetKey(KeyCode.B))
            {
                float originalGravity = rb.gravityScale;
                rb.gravityScale = 0f;
                rb.AddForce(new Vector2(Speed * 5, Jump * 3), ForceMode2D.Impulse);
                rb.gravityScale = originalGravity;
            }
            rb.AddForce(new Vector2(Speed * 90, Jump * 130), ForceMode2D.Force);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
        if (c.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Colisao");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}