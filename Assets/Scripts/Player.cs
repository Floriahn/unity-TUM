﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int score = 0;
    public static int lives = 3;
    public static int scoreWithoutDead = 0;
    public static Text playerStats;
    public static int missed = 0;
    public float projectileOffset;

    public float playerSpeed;

    public GameObject projectilePrefab;
    public GameObject explosionPrefab;

    //Projektile type
    public static float proType = 1;
    public static float oldLives;

    //Blinking
    private float shipInvisibleTime = 1.5f;
    private float shipMoveOnToScreenSpeed =5f;
    private float blinkRate = .1f;
    private int numberOfTimesToBlink = 10;
    private int blinkCount;

    // Start is called before the first frame update
    enum State
    {
        Playing,
        Explosion,
        Invincible
    };

    private State state = State.Playing;

    void Start()
    {
        oldLives = lives;
        playerStats = GameObject.Find("PlayerStats").GetComponent<Text>();
        UpdateStats();
    }

    public static void UpdateStats()
    {
        playerStats.text = "Score: " + score.ToString() +
                         "\nLives: " + lives.ToString() +
                         "\nMissed: " + missed.ToString();
    }

    public static void UpdateWeapon()
    {
        if (oldLives == lives)
        {
            scoreWithoutDead += 1;
        }
        else
        {
            oldLives = lives;
            scoreWithoutDead = 0;
            proType = 1;
        }
        if (scoreWithoutDead >= 3)
        {
            proType++;
            scoreWithoutDead = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (state != State.Explosion)
        {
            // Move player depending on input
            float amtToMovex = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime;
            transform.Translate(Vector3.right * amtToMovex);
            // Move in Y
            float amtToMovey = Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * amtToMovey);
            // Screen wrap x
            if (transform.position.x < -7.4f)
            {
                transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 7.4f)
            {
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

            //Change weapon manually
            if (Input.GetKeyDown("1")) proType = 1;
            if (Input.GetKeyDown("2")) proType = 2;
            if (Input.GetKeyDown("3")) proType = 3;
            if (Input.GetKeyDown("4")) proType = 4;
            if (Input.GetKeyDown("5")) proType = 5;
            if (Input.GetKeyDown("6")) proType = 6;



            if (proType == 1)
            {
                if (Input.GetKeyDown("space"))
                {
                    //Set position
                    Vector3 position = new Vector3(transform.position.x, transform.position.y + projectileOffset, transform.position.z);
                    // Fire projectile
                    Instantiate(projectilePrefab, position, Quaternion.identity);
                }
            }

            if (proType == 2)
            {
                if (Input.GetKey("space"))
                {
                    //Set position
                    Vector3 position = new Vector3(transform.position.x, transform.position.y + projectileOffset, transform.position.z);
                    // Fire projectile
                    Instantiate(projectilePrefab, position, Quaternion.identity);
                }
            }

            if (proType == 3)
            {
                if (Input.GetKeyDown("space"))
                {
                    //Set position
                    Vector3 position = new Vector3(transform.position.x, transform.position.y + projectileOffset, transform.position.z);
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
                    Vector3 position = new Vector3(transform.position.x, transform.position.y + projectileOffset, transform.position.z);
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
                    Vector3 position = new Vector3(transform.position.x, transform.position.y + projectileOffset, transform.position.z);
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
                    Vector3 position = new Vector3(transform.position.x, transform.position.y - (0.6f * transform.localScale.y), transform.position.z);
                    // Fire projectile
                    Instantiate(projectilePrefab, position, Quaternion.AngleAxis(180f, Vector3.forward));
                    Instantiate(projectilePrefab, position, Quaternion.AngleAxis(110f, Vector3.forward));
                    Instantiate(projectilePrefab, position, Quaternion.AngleAxis(250f, Vector3.forward));
                }
            }
        }

    }

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Enemy" && state == State.Playing)
        {
            lives--;
            UpdateStats();
            Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
            enemy.SetPositionAndSpeed();
            StartCoroutine(DestroyShip());
        }
    }

    IEnumerator DestroyShip()
    {
        blinkCount = 0;
        state = State.Explosion;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        transform.position = new Vector3(0f, -5.5f, transform.position.z);
        yield return new WaitForSeconds(shipInvisibleTime);
        if (lives > 0)
        {
            while (transform.position.y < -2.2f)
            {
                float amtToMove = shipMoveOnToScreenSpeed * Time.deltaTime;
                transform.position = new Vector3(0, transform.position.y + amtToMove, transform.position.z);
                yield return 0;
            }
            state = State.Invincible;
            while (blinkCount < numberOfTimesToBlink) 
            { 
                gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled; 
                if (gameObject.GetComponent<Renderer>().enabled) blinkCount++; 
                yield return new WaitForSeconds(blinkRate); 
            }
            state = State.Playing;
        }
        else
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
