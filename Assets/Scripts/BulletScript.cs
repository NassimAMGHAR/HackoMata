using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 1000.0f;
    public float deselerate = 0.00000000000000000000000001f;

    public string GROUND_TAG = "Ground";

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    void FixedUpdate()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation =  speed * Time.deltaTime;


        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);
      /*  if(speed * Time.deltaTime > 10)
        {
           speed -= deselerate;
        }*/

    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != GROUND_TAG)
        {
            
            Destroy(gameObject);
        }
    }

}
