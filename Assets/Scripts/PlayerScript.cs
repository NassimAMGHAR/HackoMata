using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private const float offset = 1f;
    public float speed = 15.0f;
    public float rotationSpeed = 100.0f;
    public GameObject bullet;
    public Transform shootPos;
    public float life = 100f;
    public float hitPoint = 10f;
    public Text healthText;

    private const string BULLET_NAME = "Bullet";

    private void Update()
    {
        Shoot();
    }

    void FixedUpdate()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);      
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == BULLET_NAME)
        {
            if(life > 0)
            {
                life -= hitPoint;
                healthText.text = "Health: "+life;
            }
            else
            {
                //If the GameObject has the same tag as specified, output this message in the console        
                Destroy(gameObject);
            }
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = shootPos.position;
           GameObject created = Instantiate(bullet, position, transform.rotation);
           
        }
    }
}
