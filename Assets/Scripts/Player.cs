using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _nextFire = 0.0f;


	void Start ()
    {
             
	}	
	
	void Update ()
    {
        Movement();

        if (Input.GetButton("Fire1") && Time.time > _nextFire || Input.GetKey(KeyCode.Space) && Time.time > _nextFire)
        {
            FireLaser();
        }
        
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);

        if (transform.position.y > 1.5f)
        {
            transform.position = new Vector3(transform.position.x, 1.5f, 0);

        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        if (transform.position.x <= -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
        else if (transform.position.x >= 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
    }

    private void FireLaser()
    {      
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);

        _nextFire = Time.time + _fireRate;
    }
}

