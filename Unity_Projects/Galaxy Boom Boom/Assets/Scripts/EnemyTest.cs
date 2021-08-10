using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    //Script Communication
    private Player _player;
    private Animator _anim;
    private BoxCollider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
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

            player.Score();

            if (player != null)
            {
                player.Damage();
            }

            
            _anim.SetTrigger("OnEnemyDeath");
            _collider.gameObject.SetActive(false);
            Destroy(this.gameObject, 2.3f);
        }
      
    }

}
