using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControll : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public Transform Square;

   public void OnBeginDrag(PointerEventData eventData) //Вызывается, когда начинаем вести пальцем по экрану
    {
        if(Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if(eventData.delta.x > 0)
            {
                Square.position += new Vector3(10, 0, 0);
            }
            else
            {
                Square.position += new Vector3(-10, 0, 0);

            }
        }
        else
        {

            if (eventData.delta.y > 0)
            {
                Square.position += Vector3.up;
            }
            else
            {
                Square.position += Vector3.down;

            }

        }
    }

    public void OnDrag(PointerEventData eventData) //вызывается каждый кадр, когда начинаем вести пальцем по экрану
    {
        throw new System.NotImplementedException();
    }
}
