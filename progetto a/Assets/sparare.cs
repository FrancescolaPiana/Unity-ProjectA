using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class sparare : MonoBehaviour
{
    public Transform puntoFuoco;
    public GameObject proiettilePrefab;

    public float proiettileForza = 20f;

    public int maxAmmo = 7;
    public int actualAmmo;
    public float rate2 = 1.25f;
    private float reloadTime = 2.0f;
    public float pistolDMG = 9.0f;

    public bool shootCouldownBetween = false;
    private bool isReloading = false;

    public Light2D luce;
    public GameObject pauseShoot;

    public AudioManager Manager { get; set; }

    [SerializeField] private AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        luce.intensity = 0f;
        actualAmmo = maxAmmo;
        pauseShoot.gameObject.SetActive(false);
        Manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading == true)
        {
            return;
        }

        if (actualAmmo <= 0)
        {
            StartCoroutine(reload());
            return;
        }
        if (Input.GetButtonDown("Fire1") && shootCouldownBetween == false)
        {
            Sparare();
            StartCoroutine(rateFire());
        }
    }

    void Sparare()
    {
        luce.intensity = 1f;
        Manager.Play("PistolShoot");
        actualAmmo--;
        GameObject proiettile = Instantiate(proiettilePrefab, puntoFuoco.position, puntoFuoco.rotation);
        Rigidbody2D RB = proiettile.GetComponent <Rigidbody2D>();
        RB.AddForce(puntoFuoco.up * proiettileForza * 2, ForceMode2D.Impulse);
        StartCoroutine(shot());
    }

    IEnumerator reload()
    {
        isReloading = true;
        Manager.Play("PistolReload");
        pauseShoot.gameObject.SetActive(true);
        //Debug.Log("reloading");
        yield return new WaitForSeconds(reloadTime);
        //Debug.Log(Time.time);
        actualAmmo = maxAmmo;
        isReloading = false;
        pauseShoot.gameObject.SetActive(false);
    }
    IEnumerator rateFire()
    {
        shootCouldownBetween = true;

        //Debug.Log("rate bwtween shots");

        yield return new WaitForSeconds(rate2);

        shootCouldownBetween = false;
        //Debug.Log(shootCouldownBetween);
    }
    IEnumerator shot()
    {
        yield return new WaitForSeconds(.05f);
        luce.intensity = 0f;
    }
}
