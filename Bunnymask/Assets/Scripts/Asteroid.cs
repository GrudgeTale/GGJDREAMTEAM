using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;

    public float size = 1.0f;

    public float winSize = 0.5f;

    public float maxSize = 1.5f;

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
    void Update()
    {
        
    }
}
