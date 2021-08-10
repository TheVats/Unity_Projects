using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //Script Communication
    private Player _player;

    [SerializeField]
    private float _speed = 3;
    [SerializeField]// 0 = Triple Shot, 1 = Speed, 2 = Shield
    private int IDpowerup;
    
    // Start is called before the first frame update
    void Start()
    {
        //This code is IMPORTANT!!
        _player = GameObject.Find("Player").GetComponent<Player>();
          
        if (_player == null)
        {
            Debug.Log("Error");
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -8.0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            switch(IDpowerup)
            {
                case 0:
                    _player.TripleShotActive();
                    Destroy(this.gameObject);
                    break;

                case 1:
                    _player.SpeedPowerUp();
                    Destroy(this.gameObject);
                    break;

                case 2:
                    _player.IsShieldsActive();
                    Destroy(this.gameObject);
                    break;

            }
        }

    }


}
