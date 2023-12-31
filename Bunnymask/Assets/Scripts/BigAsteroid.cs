using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : MonoBehaviour
{


    public Sprite[] sprites;

    


    [SerializeField]
    public float size = 1.0f;
    [SerializeField]
    public float minSize = 8.0f;
    [SerializeField]
    public float maxSize = 10.0f;
    [SerializeField]
    public float speed = 50.0f;
    [SerializeField]
    public float maxLifetime = 30.0f;

    [SerializeField]
    private float health = 2;


     private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rigidbody;



    // Start is called before the first frame update

    private void Awake()
    {

         _spriteRenderer = GetComponent<SpriteRenderer>();   
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()

    {

        
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        _rigidbody.mass = this.size;
    }



    // Update is called once per frame
    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            

        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1; 
            if (health <= 0)
            {
                if ((this.size * 0.5f) >= 3f)
                {
                    CreateSplit();
                    CreateSplit();
                }
                FindObjectOfType<GameManager>().BigAsteroidDestroyed(this);
                Destroy(this.gameObject);
            }
        }
    }

    
    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        BigAsteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }
    

}
