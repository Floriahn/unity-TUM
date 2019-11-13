using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Fields
    public float currentSpeed;
    public float minSpeed;
    public float maxSpeed;
    private float x, y, z;  
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Set starting position and speed
        SetPositionAndSpeed();   
    }

    // Update is called once per frame
    void Update()
    {
        // Move enemy
        float amtToMove = currentSpeed * Time.deltaTime;
        transform.Translate(Vector3.down*amtToMove);
        // Set new position and speed when enemy has reached the bottom of the screen
        if(transform.position.y <= -5){
            Player.missed++;
            Player.UpdateStats();
            SetPositionAndSpeed();
        }
    }

    public void SetPositionAndSpeed(){
        // Set new speed
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        // Set new position
        x = Random.Range(-6f, 6f);
        y = 7f;
        z = 0f;
        transform.position = new Vector3(x, y, z);
    }
}
