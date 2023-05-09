using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterAi : MonoBehaviour
{
    public Transform Player;
    private Rigidbody2D Rb;
    private Vector2 Movment;
    public float moveSpeed = 10f;
    public float StopDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 Point = Player.position - transform.position;
        float angolo = Mathf.Atan2(Point.y, Point.x) * Mathf.Rad2Deg;
        Debug.Log(Point.magnitude);
        Rb.rotation = angolo;
        
        if (Point.magnitude <= StopDistance)
        {
           //move after shooting 
        }
        else if(Point.magnitude >= StopDistance +3)
        {
            Point.Normalize();
            Movment = Point;
            MoveSpitter(Movment);
        }
    }
    void MoveSpitter(Vector2 d) {
        Rb.MovePosition((Vector2)transform.position + (d * moveSpeed * Time.deltaTime));
    }

}
