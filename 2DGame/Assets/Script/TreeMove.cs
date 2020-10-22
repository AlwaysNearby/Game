using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMove : MonoBehaviour
{
    [SerializeField] private Transform[] Tree;
    private float speed = 5.0f;
    private float speedTree = 0f;
    private float Reload = 0f;
    private float ReloadTime = 0.25f;

    // Update is called once per frame
    void Update()
    {
        if (Reload <= 0)
        {
            speedTree = (speedTree + speed) % 2;
            for(var i = 0; i < Tree.Length; i++)
            {
                Tree[i].localRotation = Quaternion.Euler(0, 0, speedTree * Mathf.Pow(-1, i));

            }
            Reload = ReloadTime;
        }
        else
        {
            Reload -= Time.deltaTime;
        }

    }
}
