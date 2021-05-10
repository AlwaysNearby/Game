using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

  


    [SerializeField] private LineRenderer _trajectory;
    private Gun gun;



    void Start()
    {
        gun = FindObjectOfType<Gun>().GetComponent<Gun>();
    }


    public Vector3[] CalculatePoints(Vector3 speed)
    {
        Vector3[] points = new Vector3[100];
        Vector3 origin = gun.transform.position;
        for(var i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
        }


        return points;
    }

    public void Draw(Vector3[] path)
    {

        _trajectory.SetPositions(path);

    }

    
 }

