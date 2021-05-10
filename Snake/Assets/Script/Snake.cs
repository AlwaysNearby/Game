using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    public GameObject Tail;
   

    
    


    [SerializeField] List<Transform> _tail;
    Vector3 currentDirection;
    Vector3 end;
    float speed = 3;



    



    private void Start()
    {

        currentDirection = new Vector3(0, 0, 0);
        end = transform.position + currentDirection;
    }


    private void Update()
    {



        currentDirection = InputHandler(currentDirection);
        if(Vector3.Distance(transform.position, end) < float.Epsilon)
        {
            end = transform.position + currentDirection;
            Rotate(currentDirection);

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, end, speed*Time.deltaTime);
        }
        MoveTail();
        
    }


    void Add()
    { 
        var tail = Instantiate(Tail, gameObject.transform.position, Quaternion.identity);
        _tail.Add(tail.transform);
        
    }



    
    void MoveTail()
    {

        Vector3 prevPosition = transform.position;

        foreach (var bones in _tail)
        {
            if(Vector3.Distance(bones.position, prevPosition) > 0.35f)
            {
                Vector3 currentPosition = bones.position;
                bones.position = prevPosition;
                prevPosition = currentPosition;   
                
            }
            else
            {
                break;
            }
        }
    }

    void Rotate(Vector3 direction)
    {
        if(direction.x == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (direction.x == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }

        if(direction.y != 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90 * direction.y);
            
        }
    }

    public Vector3 InputHandler(Vector3 direction)
    {

        if(Input.GetKeyDown(KeyCode.W))
        { 
            if(direction.y != - 1)
                direction =  new Vector3(0, 1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if(direction.y !=  1)
                 direction = new Vector3(0, -1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if(direction.x != 1)
                 direction = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if(direction.x != - 1)
                 direction = new Vector3(1, 0, 0);
        }


        return direction;


    }


    public void IncreaseSpeed()
    {
        speed += 0.5f;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Apple")
        {
            Add();
            Destroy(collision.gameObject);
            GameManager.instance.loadFood();
            GameManager.instance.AddScore();
            GameManager.instance.PlaySoud();
        }

        if(collision.gameObject.tag == "Tail" || collision.gameObject.tag == "Ground")
        {
            foreach (var bones in _tail)
                Destroy(bones.gameObject);
            Destroy(this.gameObject);
            GameManager.instance.GameOver();
        }
    }

}
