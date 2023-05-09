using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieAi : MonoBehaviour
{
    public Transform target;

    public float Speed = 200f; //velocità
    public float NextWaypointDistance = 3f; //vicinanza ai waypoint

    public Transform EnemyG;

    Path Path;
    int CurrentWaypoint = 0; //obbiettivo o curva attuale da seguire
    bool ReachedEndofPath = false; //aver raggiunto la fine del percorso

    Seeker Seeker;
    Rigidbody2D Rb;

    // Start is called before the first frame update
    void Start()
    {
        Seeker = GetComponent<Seeker>();
        Rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f); 
        //metodo che permette di ripetere un methodo a frequenze prestabilite
        //il primo valore è quante volte eseguirlo il secondo è ogni quanti secondi eseguirlo
        
    }

    private void UpdatePath()
    {
        if (Seeker.IsDone()) //che significa entra nell'if solo se non stai ancora calcolando un percorso. se hai finito invece entra e inizia a calcolarne un'altro
        { 
            Seeker.StartPath(Rb.position, target.position, OnPathComplete);
            // il nostro seeker che prender la nostra posizione e tenta di portarci al targhet 
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)    //il method OnPathComplete ci blocca qualora raggiungessimo il target
        {
            Path = p;
            CurrentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        Vector2 direzioneOsservata = (Vector2)target.position - Rb.position;
        float angolo = Mathf.Atan2(direzioneOsservata.y, direzioneOsservata.x) * Mathf.Rad2Deg;
        Rb.rotation = angolo ;
   
        if (Path == null) // se non vi è percorso esci dall'if e ricomincia l'update senza guardare sotto
        {
            return;
        }
        if(CurrentWaypoint >= Path.vectorPath.Count) //se il nostro waypoint è superiore al nuemro totale di waypoint allora sei arrivato
        {
            ReachedEndofPath=true;
            return;
        }
        else   //altrimenti continua a cercare un Waypoint
        {
            ReachedEndofPath = false;
        }

        //Path.vectorPath[CurrentWaypoint] === il vettore che designa il prossimo waypoint

        Vector2 Direction = ((Vector2)Path.vectorPath[CurrentWaypoint] - Rb.position).normalized;

        //currentwaypoint - our position vector2 serve a castare il valore currentpoint in un vector2
        //normalize rende "semplice il nuovo vettore generato" come se fosse una freccia 

        Vector2 Force = Direction * Speed * Time.deltaTime; //velocità o forza del movimento

        Rb.AddForce(Force); //applicazione del vettore forza al nostro movimento
        

        float Distance = Vector2.Distance(Rb.position, Path.vectorPath[CurrentWaypoint]); //dstanza tra noi e il prossimo watpoint

        if (Distance < NextWaypointDistance) //allora se la distanza è colmata passa al prossimo waypoint
        {
            CurrentWaypoint++;
        }


    }
}
