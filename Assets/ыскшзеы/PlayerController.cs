using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public float jumpForce = 25f;
    public float gravityModifier = 15f;

    public bool isOnGround = true;
    public bool gameOver = false;

    private Animator playerAnim;
    private ParticleSystem runParticles;

    public GameOverUI gameOverUI;

    private bool isDead = false;
    [SerializeField] ParticleSystem deathParticles;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        runParticles = GetComponentInChildren<ParticleSystem>();

        Physics.gravity *= gravityModifier;
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void Update()
    {
        if (gameOver) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump();
        }
    }

    public void OnJump()
    {
        if (isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (gameOver) return;

            gameOver = true;

            playerAnim.SetFloat("Speed_f", 0f);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            if (runParticles != null)
                runParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);

            StartCoroutine(DeathSequence());
        }
    }

    IEnumerator DeathSequence()
    {
        if (isDead) yield break;
        isDead = true;

        yield return new WaitForSeconds(1.2f);

        GameTimer.Instance.StopTimer();
        gameOverUI.ShowGameOver();
    }


}
