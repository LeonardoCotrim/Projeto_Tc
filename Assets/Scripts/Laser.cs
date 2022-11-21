using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float velocLaser = 11.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.down*velocLaser*Time.deltaTime);

       if ( transform.position.x > 9.9f ){
        Destroy(this.gameObject);
       }

    }
}

