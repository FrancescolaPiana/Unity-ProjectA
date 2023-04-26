using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptProiettile : MonoBehaviour
{

    public GameObject colpoProiettile;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7,3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            GameObject effetto = Instantiate(colpoProiettile, transform.position, Quaternion.identity);
            Destroy(effetto, .5f);
            Destroy(gameObject);
    }

}
