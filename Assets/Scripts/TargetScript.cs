using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private const string BULLET_NAME = "Bullet";



    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == BULLET_NAME)
        {
            //If the GameObject has the same tag as specified, output this message in the console          
            Destroy(gameObject);
        }
    }
}
