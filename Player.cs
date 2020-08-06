using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool CanTripleShot = false;
    public bool CanSpeedBoost = false;
    public bool CanShields = false;
    //public bool CanDoubleShot = false; 
    //public bool VeryPowerfullShot = false;

    [SerializeField]
    private GameObject _laserPrefab;

    //[SerializeField]
    //private GameObject _PowerDoubleShotPrefab;

    [SerializeField]
    private GameObject _TripleShotPrefab;

    //[SerializeField]
    //private GameObject _VeryPowerfullShotPrefab;

    [SerializeField]
    private float _FireRate = 0.25f;        
    private float _CanFire = 0.0f;

    private float _SpeedRate = 0.25f;
    private float _CanSpeed = 0.0f;

    [SerializeField]
    public float _velocidade = 5.0f;

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        Moviment();

        if (Time.time > _CanSpeed)
        {
            if (CanSpeedBoost == true)
            {
                _velocidade = 20.0f;
            }
            _CanSpeed = Time.time + _SpeedRate;
        }
        
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0)) 
        {
            Shot();
        } 
    }

        private void Shot() 
    {
        if (Time.time > _CanFire)
        {
            if (CanTripleShot == true)
            {
                Instantiate(_TripleShotPrefab, transform.position, Quaternion.identity);
            // }
            //else if(CanPowerDoubleShot == true)
            //{
            //    Instantiate(_PowerDoubleShotPrefab, transform.position, Quaternion.identity);
            //}
            //else if(CanVeryPowerfullShot == true)
            //{
            //    Instantiate(_VeryPowerfullShotPrefab, transform.position + new Vector3(0, 0.91f, 0), Quaternion.identity);
            } else Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.91f, 0), Quaternion.identity);

            _CanFire = Time.time + _FireRate;                     
          
        }
    }

    private void Moviment()
    {
        float EntradaHorizontal = Input.GetAxis("Horizontal");
        float EntradaVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * _velocidade * EntradaHorizontal);
        transform.Translate(Vector3.up * Time.deltaTime * _velocidade * EntradaVertical);
                
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }

    public void SpeedBoostPowerOn()
    {
        CanSpeedBoost = true;
        StartCoroutine(SpeedBoostDownRotine());
    }

    public IEnumerator SpeedBoostDownRotine()
    {
        yield return new WaitForSeconds(5.0f);
        CanSpeedBoost = false;
        _velocidade = 5.0f;
    }

    public void TripleShotPowerOn() 
    {
        CanTripleShot = true;
        StartCoroutine(TripleShotPowerDownRotine());
    }

    public IEnumerator TripleShotPowerDownRotine() 
    {
        yield return new WaitForSeconds(5.0f);
        CanTripleShot = false;
    }
}
