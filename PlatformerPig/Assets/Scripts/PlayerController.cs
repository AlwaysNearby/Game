using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Player _player;
    void Start()
    {
       _player = _player == null ? GetComponent<Player>() : _player;

    }

    // Update is called once per frame
    void Update()
    {
        if(_player != null)
        {

            _player.Move(Input.GetAxisRaw("Horizontal"));



            if(Input.GetKeyDown(KeyCode.Space))
            {
                _player.Jump();
            }


            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                _player.Attack();
            }

          

        }
    }
}
