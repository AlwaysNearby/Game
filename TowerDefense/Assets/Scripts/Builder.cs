using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class Builder : MonoBehaviour
{


    public LayerMask whatIsPlaceForBuild;

    [SerializeField] private GameObject _visibleTowerInBuild;
    
    private Tower _currentBuild;
    private InputSystem _input;
    private Camera _mainCamera;
    private bool InBuild;
    
    


    private void Awake()
    {
        _input = new InputSystem();
        _mainCamera = Camera.main;
        InBuild = false;
    }


    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }


    private void Start()
    {
        
        _visibleTowerInBuild = Instantiate(_visibleTowerInBuild, Vector3.zero, quaternion.identity);
        _visibleTowerInBuild.SetActive(false);
        _input.InputPlayer.ClickDown.performed += context =>
        {
            InBuild = false;
            _currentBuild = null;
        };
    }


    public void SetTowerToBuild(Tower tower)
    {
        if (_currentBuild == null)
        {
            InBuild = true;
            _currentBuild = tower;
            StartCoroutine(Building(_visibleTowerInBuild, _currentBuild));
        }
    }

    
    private IEnumerator Building(GameObject visibleTower, Tower tower)
    {
        visibleTower.SetActive(true);
        visibleTower.GetComponent<SpriteRenderer>().sprite = tower.GetComponent<SpriteRenderer>().sprite;

        while (InBuild)
        {
            var clickPosition = _mainCamera.ScreenToWorldPoint(_input.InputPlayer.Click.ReadValue<Vector2>());
            visibleTower.transform.position = new Vector3(clickPosition.x, clickPosition.y, 0);
            yield return null;
        }

        var placeForTower = FindPlaceForTower(visibleTower);
        if(placeForTower != null)
        {
           placeForTower.ToPut(tower);
        }
        visibleTower.SetActive(false);

    }



    private PlaceForTower FindPlaceForTower(GameObject tower)
    {
        float radius = 0.25f;
        var colliderPlaces = Physics2D.OverlapCircle(tower.transform.position, radius, whatIsPlaceForBuild);
        return colliderPlaces == null ? null : colliderPlaces.GetComponent<PlaceForTower>();
    }
    



    


}
