using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{


    private CinemachineVirtualCamera virtualCamera;

    private CinemachineBasicMultiChannelPerlin noisePerlin;

    private float AmplitudeGain;
    private float FrequencyGain;
    private float shakerTimer;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noisePerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }



    private void Start()
    {
        AmplitudeGain = 1f;
        FrequencyGain = 30f;

    }


    public void Shake()
    {
        shakerTimer =  Random.Range(0.3f, 0.5f);

        noisePerlin.m_AmplitudeGain = AmplitudeGain;
        noisePerlin.m_FrequencyGain = FrequencyGain;
        StartCoroutine(Jiggle(shakerTimer));

    }



    private IEnumerator Jiggle(float time)
    {
        yield return new WaitForSeconds(time); 
            
        noisePerlin.m_AmplitudeGain = 0f;
        noisePerlin.m_FrequencyGain = 0f;
    }
  

}
