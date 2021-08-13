using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private int Lives_ = 6;
    [SerializeField]
    private int speed_ = 3;//assteroid travelling speed
    private Player player;
    private SpawnManager spawnManager;
    private UI ui;
    private int speed = 1;//asteroid rotation speed
    void Start()
    {
        ui = GameObject.Find("GameOver Canvas").GetComponent<UI>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        player = GameObject.Find("Payer").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.down * speed_ * Time.deltaTime);
        if(transform.position.y <= -6.5f)
        {
            Destroy(this.gameObject);
        }

        
    }
    public void Damage()
    {
        Lives_ -= 1 ;
        if(Lives_ < 1)
        {
            Destroy(this.gameObject);
            ui.AsteroidPoints();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {     
            Destroy(other.gameObject);
            spawnManager.OnPlayerDeath();
            ui.GameOverSequence();
        }
        if(other.tag == "laser")
        {
            Damage();
            Destroy(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            
        }
    }
}
