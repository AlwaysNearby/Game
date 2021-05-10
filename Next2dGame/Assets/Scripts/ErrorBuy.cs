using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorBuy : MonoBehaviour
{
    [SerializeField] private Text _error;






    public void ShowText(string textError)
    {
       
        _error.text = textError;


    }
}
