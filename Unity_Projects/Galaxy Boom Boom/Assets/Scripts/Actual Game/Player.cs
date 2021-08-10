using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player's Basic Variables
    [SerializeField]
    private float _speed = 9.0f;
    [SerializeField]
    private GameObject _LaserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canfire = -1f;
    [SerializeField]
    private int _lives = 3;
    

    //PowerUps
    [SerializeField]
    private GameObject _TripleShotPrefab;
    private bool _TripleShotActive = false;
    private  bool _ShieldsActive = false;
    [SerializeField]
    private GameObject _ShieldVisual;
    
    

    //Script Communication Variables
    private UI _ui;
    private SpawnManager _spawnManager;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);


        _ui = GameObject.Find("Canvas").GetComponent<UI>();
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        
        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager IS NULL!!!");
        }
         
        if(_ui == null)
        {
            Debug.LogError("The UI Is NOT Responding!!!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovements();

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > _canfire)
        {
            FirePhewPhew();         
        }

       




    }
    public void FireButton()
    {
        Touch myTouch = Input.GetTouch(0);
        Touch[] myTouches = Input.touches;

        if (Time.time > _canfire)
        {
            for (var i = 0; i < Input.touchCount; i++)
            {
                FirePhewPhew();
            }
        }
    }

    void PlayerMovements()
    {
        //this is for Joystick OBVIOUSLY!!
        float Horizontaljoystick = joystick.Horizontal;
        float Vericaljoystick = joystick.Vertical;
       //This ISn't for joystick
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
                            //takes new vector3 and multiples by realtime(Time.deltaTime) 
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);   
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
       
        //Optimal code = tansform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);  
       
        transform.Translate(new Vector2(Horizontaljoystick, Vericaljoystick) * _speed * Time.deltaTime);
       
        if(transform.position.x <=-11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }

        else if(transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }

        if(transform.position.y <= -4.7f)
        {
            transform.position = new Vector3(transform.position.x, -4.7f, 0);
        }

        else if(transform.position.y >= 4.7f)
        {
            transform.position = new Vector3(transform.position.x, 4.7f, 0);
            //optimal code = transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 4.7, -4.7), 0);

        }

    }

    public void Damage()
    {
        if (_ShieldsActive == true)
        {
            _ShieldsActive = false;
            _ShieldVisual.SetActive(false);
            return;
        }
        else
        {
            _lives -= 1;

            _ui.UpdateLives(_lives);

            if (_lives < 1)
            {
                
                _spawnManager.OnPlayerDeath();
                Destroy(this.gameObject);
            }
        }
    }

    //Laser//Triple Shot Spawning
    void FirePhewPhew()
    {
        _canfire = Time.time + _fireRate;

        if (_TripleShotActive == true)
        {
            Instantiate(_TripleShotPrefab, transform.position, Quaternion.identity);
        }
        
        else
        {
            Instantiate(_LaserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
       
    }

    //TripleShotPowerUp

    public void TripleShotActive()
    {
        _TripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(8);
        _TripleShotActive = false;
    }

    //SpeedPowerUp
     public void SpeedPowerUp()
    {
        _speed = 15;
        StartCoroutine(SpeedDownRoutine());
    }
    IEnumerator SpeedDownRoutine()
    {
        yield return new WaitForSeconds(5);
        _speed = 9;
    }

    //ShieldsPowerUp

    public void IsShieldsActive()
    {
        _ShieldsActive = true;
        _ShieldVisual.SetActive(true);
    }

    public void Score ()
    {
        _ui.Points();
    }
}

