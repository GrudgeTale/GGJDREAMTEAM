using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 500.0f;

    public float maxLifetime = 10.0f;

    private Rigidbody2D _rigidBody;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Project(Vector2 direction)
    {
        _rigidBody.AddForce(direction * this.speed);

         Destroy(this.gameObject, this.maxLifetime);
    }
}
