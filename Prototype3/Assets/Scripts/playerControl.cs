using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    private Rigidbody player;
    public float jumpForce;
    public float gravityModifier;
    public bool onGround = true;
    public bool gameOver = false;

    private Animator playerAnim;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioSource sourceAudio;
    public AudioClip jump;
    public AudioClip crash;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        sourceAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
        {
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            playerAnim.SetTrigger("Jump_trig");
            sourceAudio.PlayOneShot(jump, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirt.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("GAME OVER!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            sourceAudio.PlayOneShot(crash, 1.0f);
            explosion.Play();
            dirt.Stop();
        }
    }

}
