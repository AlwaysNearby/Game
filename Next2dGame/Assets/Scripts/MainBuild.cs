using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainBuild : Build
{

    [SerializeField] Canvas _buildMenu;




    private void OnMouseDown()
    {
        _buildMenu.gameObject.SetActive(true);
    }


    private void OnMouseExit()
    {
        _buildMenu.gameObject.SetActive(false);
    }


}
