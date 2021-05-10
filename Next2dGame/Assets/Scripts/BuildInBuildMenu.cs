using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class BuildInBuildMenu : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{

    [SerializeField] private Build _prebafBuild;



    public EventClickOnBuild clickOnBuild;

    public EventShowErrorBuy purchaseError;

    public void OnPointerDown(PointerEventData eventData)
    {


        if (_prebafBuild.Cost > 0)
        {
            purchaseError.Invoke("Lack of funds");

        }
        else
        {

            clickOnBuild.Invoke(_prebafBuild);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        purchaseError.Invoke("");
    }
}



[System.Serializable]
public class EventClickOnBuild : UnityEvent<Build> { }
[System.Serializable]
public class EventShowErrorBuy : UnityEvent<string> { }
