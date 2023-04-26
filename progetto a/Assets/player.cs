using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D RB;
    public Camera Camera;

    public float velocit‡Movimento = 6f;

    Vector2 movimento;
    Vector2 posizioneMouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");
        if (movimento.x !=0 && movimento.y !=0)
        {
            movimento = movimento / 1.41f;
        }

        posizioneMouse = Camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        //Debug.Log(movimento);
        RB.MovePosition(RB.position + movimento * velocit‡Movimento * Time.fixedDeltaTime);

        Vector2 direzioneOsservata = posizioneMouse - RB.position;
        float angolo = Mathf.Atan2(direzioneOsservata.y, direzioneOsservata.x) * Mathf.Rad2Deg;
        RB.rotation = angolo;
    }
}
