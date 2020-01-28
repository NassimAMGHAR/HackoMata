using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{


    public GameObject boss;



    // Update is called once per frame
    void Update()
    {
       var Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemies.Length == 0 )
        {
            Instantiate(boss, new Vector3(0,10,0), transform.rotation);
        }
    }
}
