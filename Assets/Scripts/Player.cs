using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public GameObject projectilePrefab;

    //Projektile type
    public float proType=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move player depending on input
        float amtToMovex = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * amtToMovex);
        // Move in Y
        float amtToMovey = Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * amtToMovey);
        // Screen wrap x
        if (transform.position.x < -7.4f){
            transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
        }
        if(transform.position.x > 7.4f){
            transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);
        }
        // Screen warp y
        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(transform.position.x, 7f, transform.position.z);
        }
        if (transform.position.y > 7f)
        {
            transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
        }

        if (Input.GetKeyDown("1")) proType = 1;
        if (Input.GetKeyDown("2")) proType = 2;
        if (Input.GetKeyDown("3")) proType = 3;
        if (Input.GetKeyDown("4")) proType = 4;
        if (Input.GetKeyDown("5")) proType = 5;
        if (Input.GetKeyDown("6")) proType = 6;



        if (proType==1)
        {
            if (Input.GetKeyDown("space"))
            {
                //Set position
                Vector3 position = new Vector3(transform.position.x, transform.position.y + (0.6f * transform.localScale.y), transform.position.z);
                // Fire projectile
                Instantiate(projectilePrefab, position, Quaternion.identity);
            }
        }

        if (proType == 2)
        {
            if (Input.GetKey("space"))
            {
                //Set position
                Vector3 position = new Vector3(transform.position.x, transform.position.y + (0.6f * transform.localScale.y), transform.position.z);
                // Fire projectile
                Instantiate(projectilePrefab, position, Quaternion.identity);
            }
        }

        if (proType == 3)
        {
            if (Input.GetKeyDown("space"))
            {
                //Set position
                Vector3 position = new Vector3(transform.position.x, transform.position.y + (0.6f * transform.localScale.y), transform.position.z);
                // Fire projectile
                Instantiate(projectilePrefab, position, Quaternion.identity);
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(30f, Vector3.forward));
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(-30f, Vector3.forward));
            }
        }

        if (proType == 4)
        {
            if (Input.GetKey("space"))
            {
                //Set position
                Vector3 position = new Vector3(transform.position.x, transform.position.y + (0.6f * transform.localScale.y), transform.position.z);
                // Fire projectile
                Instantiate(projectilePrefab, position, Quaternion.identity);
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(30f, Vector3.forward));
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(-30f, Vector3.forward));
            }
        }

        if (proType == 5)
        {
            if (Input.GetKeyDown("space"))
            {
                //Set position
                Vector3 position = new Vector3(transform.position.x, transform.position.y + (0.6f * transform.localScale.y), transform.position.z);
                // Fire projectile
                Instantiate(projectilePrefab, position, Quaternion.identity);
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(30f, Vector3.forward));
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(-30f, Vector3.forward));

                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(180f, Vector3.forward));
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(140f, Vector3.forward));
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(220f, Vector3.forward));


            }
        }

        if (proType == 6)
        {
            if (Input.GetKey("space"))
            {
                //Set position
                Vector3 position = new Vector3(transform.position.x, transform.position.y + (0.6f * transform.localScale.y), transform.position.z);
                // Fire projectile
                Instantiate(projectilePrefab, position, Quaternion.identity);
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(30f, Vector3.forward));
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(-30f, Vector3.forward));

                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(180f, Vector3.forward));
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(150f, Vector3.forward));
                Instantiate(projectilePrefab, position, Quaternion.AngleAxis(210f, Vector3.forward));
            }
        }

    }
}
