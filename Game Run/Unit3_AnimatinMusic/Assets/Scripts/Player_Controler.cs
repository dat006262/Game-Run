using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    private Rigidbody player_rigid;
    public float jumpForce = 10;
    public float gravityModifer=1;
    public bool onGround = true;
    public bool gameOver= false;
    private Animator anim;
    public ParticleSystem explotion_partical;
    public ParticleSystem dirty_partical;
    public AudioClip aud_jump;
    public AudioClip aud_crass;
    private AudioSource player_audio;
    private AudioSource cam_audio;
    // Start is called before the first frame update
    void Start()
    {
        player_rigid = GetComponent<Rigidbody>();
        player_audio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifer;
        anim = GetComponent<Animator>();
        //Physics.gravity = Physics.gravity * gravityModifer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround&&!gameOver)
        {
            player_rigid.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            anim.SetTrigger("Jump_trig");
            dirty_partical.Stop();
            player_audio.PlayOneShot(aud_jump, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            onGround = true;
            dirty_partical.Play();

        }else if (collision.gameObject.CompareTag("Obstancles"))
        {
            gameOver = true;
            Debug.Log("Over");
            anim.SetInteger("DeathType_int", 1);
            anim.SetBool("Death_b",true);
            explotion_partical.Play();
            dirty_partical.Stop();
            player_audio.PlayOneShot(aud_crass, 1.0f);
            cam_audio =  GameObject.Find("Main Camera").GetComponent<AudioSource>();
            cam_audio.Stop();
        }
    }
}
