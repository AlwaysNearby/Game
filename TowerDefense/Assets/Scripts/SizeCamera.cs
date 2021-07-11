using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeCamera : MonoBehaviour
{
    

    public Vector2 DefaultResolution = new Vector2(1280, 720);
    
    
    private float   DesignOrthographicSize;
    private float   DesignAspect;
    private float DesignWidth;
    
    
    
    
    


    void Start()
    {

        DesignOrthographicSize = Camera.main.orthographicSize;
        DesignAspect = DefaultResolution.x / DefaultResolution.y;
        DesignWidth = DesignOrthographicSize * DesignAspect;

        float wantedSize = DesignWidth / Camera.main.aspect;
        Camera.main.orthographicSize = wantedSize;



    }
    
}
