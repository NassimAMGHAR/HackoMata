using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private const string BULLET_NAME = "Bullet";

    private GameObject player;
    public Transform shootPos;
    public GameObject bullet;

    public float fireRange = 6F;
    public float fireRate = 10F;
    public float RotationSpeed = 50F;
    public float life = 30f;
    public float hitPoint = 10f;


    private float nextFire = 0.0F;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        Fire();
    }

    private void FixedUpdate()
    {
        LookAt();
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == BULLET_NAME)
        {
            if (life > 0)
            {
                life -= hitPoint;
            }
            else
            {
                //If the GameObject has the same tag as specified, output this message in the console        
                Destroy(gameObject);
            }
        }
    }

    private void LookAt()
    {
        if (InRange())
        {
            //find the vector pointing from our position to the target
            var direction = (player.transform.position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            var lookRotation = Quaternion.LookRotation(direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
        }
    }

    private void Fire()
    {
        if (InRange() && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject created = Instantiate(bullet, shootPos.position, transform.rotation);
        }
    }

    private bool InRange()
    {
        return player != null && System.Math.Abs(Vector3.Distance(transform.position, player.transform.position)) < fireRange;
    }
}
