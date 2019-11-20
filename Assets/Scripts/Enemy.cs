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

    //Blatt 5
    private float MinRotateSpeed = 60f;
    private float MaxRotateSpeed = 120f;
    private float MinScale = .8f;
    private float MaxScale = 2f;
    private float currentRotationSpeed;
    private float currentScaleX;
    private float currentScaleY;
    private float currentScaleZ;
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
        transform.Translate(Vector3.down * amtToMove, Space.World);
        // Set new position and speed when enemy has reached the bottom of the screen
        if (transform.position.y <= -5)
        {
            Player.missed++;
            Player.UpdateStats();
            SetPositionAndSpeed();
        }
        float rotationSpeed = currentRotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(-1, 0, 0) * rotationSpeed);
    }

    public void SetPositionAndSpeed()
    {
        //Blatt5
        currentRotationSpeed = Random.Range(MinRotateSpeed, MaxRotateSpeed);
        currentScaleX = Random.Range(MinScale, MaxScale);
        currentScaleY = Random.Range(MinScale, MaxScale);
        currentScaleZ = Random.Range(MinScale, MaxScale);
        // Set new speed
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        // Set new position
        x = Random.Range(-6f, 6f);
        y = 7f;
        z = 0f;
        transform.position = new Vector3(x, y, z);
        transform.localScale = new Vector3(currentScaleX, currentScaleY, currentScaleZ);
    }
}
