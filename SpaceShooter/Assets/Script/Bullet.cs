using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float direction;
    private float speed;
    [SerializeField] private float dmg;

    private void Start()
    {
        speed = 5.0f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(Mathf.Sin(direction), Mathf.Cos(direction), 0)*speed * Time.deltaTime;
    }


    public void SetSpeed(float angle)
    {
        direction = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Meteor")
        {
            var hp = collision.GetComponent<Health>();
            hp.TakeDamage(dmg);
            Destroy(this.gameObject);
        }
    }
}
