using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Player player;
    private int lives = 20;
    private UI ui;
    public GameObject BossPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("GameOver Canvas").GetComponent<UI>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       // if( ui.Score == 20)
        //{
          //  Instantiate(BossPrefab, new Vector2(0f, 7f), Quaternion.identity);
        //}
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.Damage();
        }
        
        if(other.tag == "laser")
        {
            Damage(); 
        }
    }

    private void Damage()
    {
        lives -= 1;

        if (lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
