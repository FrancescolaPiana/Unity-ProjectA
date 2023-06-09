using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class zombi : MonoBehaviour
{ 
    public float HP = 27f;
    public float actualHP;
    
    private bool IsDeath = false;

    private sparare sparare;
    private GameObject player;
    private GameObject zombie;
    public AudioManager Manager;


    [SerializeField] private AudioSource damageTaken;
    [SerializeField] private AudioSource deathSound;

    Vector2 direzione;
    public AIPath aiPath;


    // Start is called before the first frame update
    private void Start()
    {
        Manager = FindObjectOfType<AudioManager>();

        player = GameObject.Find("player");
        actualHP = HP;
        sparare = player.GetComponent<sparare>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (actualHP <= 0f)
        {

            //deathSound.Play();
            StartCoroutine(Morte());


        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 7) {
                actualHP = actualHP - sparare.pistolDMG;
                if (actualHP <= 0f)
                {
                Manager.Play("ZombieDeath");
                return;
                }
            Manager.Play("DamageTakenZombie");

            Debug.Log("danni subiti" + sparare.pistolDMG);
                    Debug.Log("hp rimanenti" + actualHP);
                }



        }

        IEnumerator Morte()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
