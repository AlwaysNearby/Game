using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    private Vector3 direction;




    public GameObject _effectBonus;



    void Start()
    {
        var target = GameObject.FindGameObjectWithTag("Player");
        direction = target.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction.normalized * Time.deltaTime;
    }




    public void CreateBonus()
    {
        var parent = GameObject.FindGameObjectWithTag("Player");
        var shield = Instantiate(_effectBonus, new Vector3(0, 0, 0), Quaternion.Euler(0,0,parent.transform.localEulerAngles.z));
        shield.transform.SetParent(parent.transform);
        

    }
}
