using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move projectile
        

        if (transform.position.y > 6.4f){ 
            Destroy(gameObject); 
        }

        if (transform.position.y < -4.5f)
        {
          
            transform.rotation = Quaternion.Euler(0f, 0f, 180-this.transform.rotation.eulerAngles.z);
               
        }

        if (transform.position.x > 7.4f)
        {

            transform.rotation = Quaternion.Euler(0f, 0f, 270+this.transform.rotation.eulerAngles.z);
            Debug.Log("test");

        }

        if (transform.position.x < -7.4f)
        {

            transform.rotation = Quaternion.Euler(0f, 0f, 270 + this.transform.rotation.eulerAngles.z);
            Debug.Log("test");

        }

        /*if (flippedX)
        {

            //transform.Rotate(Vector3.forward, transform.rotation.eulerAngles.z-180); 

            float amtToMove = projectileSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * amtToMove);
            
            
        }
        else
        {
            float amtToMove = projectileSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * amtToMove);
        }*/

        float amtToMove = projectileSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * amtToMove);
    }
}
