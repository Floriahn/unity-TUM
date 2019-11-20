using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;

    public GameObject explosionPrefab;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move projectile


        if (transform.position.y > 6.4f)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -4.5f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180 - this.transform.rotation.eulerAngles.z);
        }
        if (transform.position.x > 7f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 270 + this.transform.rotation.eulerAngles.z);
        }
        if (transform.position.x < -7f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 270 + this.transform.rotation.eulerAngles.z);
        }





        float amtToMove = projectileSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * amtToMove);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemy")
        {

            Instantiate(explosionPrefab, this.transform.position, transform.rotation);
            enemy.minSpeed += 0.5f;
            enemy.maxSpeed += 1f;
            enemy.SetPositionAndSpeed();
            Player.score += 100;
            Player.UpdateStats();
            if (Player.score >= 1000)
            {
                SceneManager.LoadScene("Win");
            }
            Player.UpdateWeapon();
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}