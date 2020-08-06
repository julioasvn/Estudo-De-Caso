using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerupID;// 0 = triple shot; 1 = speed boost; 2 = shields

    
    // Update is called once per frame
    private void Start()
    {
        transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 5.5f, 0);
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collaided with: " + other.name);

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                //enable triple shot
                if (_powerupID == 0)
                {
                    player.TripleShotPowerOn();
                }

                //enable speed boost
                if (_powerupID == 1) 
                {
                    player.SpeedBoostPowerOn();
                }
                
                //enable shields
                if (_powerupID == 2) 
                { 
                
                }
            }
            
            Destroy(this.gameObject);
            
        }
    }
}
