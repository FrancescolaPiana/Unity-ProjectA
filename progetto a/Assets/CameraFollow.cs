using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;
    private GameObject player;
    public float smoothspeed = 10f;
    public float Xmax;
    public float Ymax;


    private void FixedUpdate()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            target = player.transform;
        }

            target = player.transform;

        if (Mathf.Abs(target.position.x) < Xmax && Mathf.Abs(target.position.y) < Xmax)
        {

            
            Vector3 targetposition = target.position - offset;
            Vector3 smoothposition = Vector3.Lerp(transform.position, targetposition, smoothspeed * Time.deltaTime);
            transform.position = smoothposition;
        }
        else if (Mathf.Abs(target.position.x) >= Xmax && Mathf.Abs(target.position.y) < Xmax)
        {
            
            Vector3 targetposition = new Vector3(transform.position.x,target.position.y , 0 ) - offset;
            Vector3 smoothposition = Vector3.Lerp(transform.position, targetposition, smoothspeed * Time.deltaTime);
            transform.position = smoothposition;
        }

        else if (Mathf.Abs(target.position.y) >= Ymax && Mathf.Abs(target.position.x) < Xmax)
        {

            Vector3 targetposition = new Vector3( target.position.x , transform.position.y , 0) - offset;
            Vector3 smoothposition = Vector3.Lerp(transform.position, targetposition, smoothspeed * Time.deltaTime);
            transform.position = smoothposition;
        }
       

        //Poco smooth, da rivedere
        //Aggiungere zoom in al buio
    }
}
