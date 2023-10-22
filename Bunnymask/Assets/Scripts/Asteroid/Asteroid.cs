using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

   

    //public Sprite[] sprites;
    [SerializeField]
    public float nsize = 1.0f;
    [SerializeField]
    public float nminSize = 2.0f;
    [SerializeField]
    public float nmaxSize = 3.0f;
    [SerializeField]
    public float nspeed = 50.0f;
    [SerializeField]
    public float nmaxLifetime = 30.0f;
    [SerializeField]
    private float health = 1;



   // private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rigidbody;

 

    // Start is called before the first frame update

    private void Awake()
    {
        // nspeed = nspeed;
        // nmaxSize = nmaxSize;
    // _spriteRenderer = GetComponent<SpriteRenderer>();   
    _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()

    {
        

        //   _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.nsize;

        _rigidbody.mass = this.nsize;
    }



    // Update is called once per frame
    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.nspeed);
         
        Destroy(this.gameObject, this.nmaxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health -= 1;
        if (health <= 0)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                health -= 1;
                FindObjectOfType<GameManager>().AsteroidDestroyed(this);
                Destroy(this.gameObject);
            }
        }
    }

    /*
    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }
    */

}
