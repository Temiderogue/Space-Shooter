using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    Rigidbody _ship;

    public float speed = 15;
    public float tilt = 2;

    public float xMin, xMax, zMin, zMax;

    public GameObject LaserGun;
    public GameObject LaserShot;
    public GameObject PlayerExplosion;

    public float shotDelay;
    private float nextshot;

    bool isGamePaused = false;
    bool isPlayerDead=false;

    public GameObject restartButton;

    Vector3 startPos;

    void Start()
    {
        _ship = GetComponent<Rigidbody>();
        startPos = transform.position;
        activateRestartButton(false);

    }
	
	void Update () {
        if ((isGamePaused || isPlayerDead) == true)
        {
            gameObject.SetActive(false);
            Pause();
            activateRestartButton(true);
        }
        else
        {
            Time.timeScale = 1f;
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
            _ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

            _ship.rotation = Quaternion.Euler(_ship.velocity.z, 0,  -_ship.velocity.x * tilt);

            var positionX = Mathf.Clamp(_ship.position.x, xMin, xMax);
            var positionZ = Mathf.Clamp(_ship.position.z, zMin, zMax);
            var positionY = _ship.position.y;

            _ship.position = new Vector3(positionX, positionY, positionZ);

            if (Time.time > nextshot && Input.GetButton("Fire1"))
            {
                Instantiate(LaserShot, LaserGun.transform.position, Quaternion.identity);
                nextshot = Time.time + shotDelay;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            Instantiate(PlayerExplosion, _ship.transform.position, Quaternion.identity);
            isPlayerDead = true;
            transform.position = startPos;
        }

    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    void activateRestartButton(bool toggle)
    {
        restartButton.SetActive(toggle);
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        isPlayerDead = false;
        isGamePaused = false;
        Time.timeScale = 1f;
        activateRestartButton(false);
        var Asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        for (int i = 0; i < Asteroids.Length; i++)
        {
            Destroy(Asteroids[i]);
        }
    }
}
