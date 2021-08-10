using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    //Script Communication
    private Player _player;
    private Animator _anim;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        if(_player = null)
        {
            Debug.LogError("PLayer NOT FOUND :)");
        }
        _anim = GetComponent<Animator>();

        if(_anim == null)
        {
            Debug.LogError("Anim DED :(");
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -6.5)

        {       
            transform.position = new Vector3(Random.Range(-9f, 9f), 6.5f, 0f); 
        }
          
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            Player player = other.transform.GetComponent<Player>();

            _player.Score();

            if (player != null)
            {
                player.Damage();
            }
            _anim.SetTrigger("OnEnemyDeath");
            Destroy(this.gameObject, 2.5f);
        }


        if (other.tag == "Laser")
        {
            _player.Score();
            Destroy(other.gameObject);
            _anim.SetTrigger("OnEnemyDeath");
            Destroy(this.gameObject, 2.5f);
        }
    }


}
