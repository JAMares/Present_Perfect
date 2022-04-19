using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointerMenu : MonoBehaviour
{
    private const float _maxDistance = 50.0f;
    private GameObject _gazedAtObject = null;
    public float tiempoclick=2.0f;
    private float tiempotrasncurrido = 0.0f;
    public Image puntero;
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {

        // Revisamos si el rayo esta golpeando algo
        DispararRayo();


        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
    }

    void DispararRayo()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {

            tiempotrasncurrido += Time.deltaTime;
            puntero.fillAmount = (1.0f * tiempotrasncurrido)/tiempoclick;
            Debug.Log(tiempotrasncurrido);
           
            // GameObject detected in front of the camera.
            if ((_gazedAtObject != hit.transform.gameObject) && tiempotrasncurrido >= tiempoclick)
            {

                if (hit.transform.name == "ButtonLevel0")
                {
                    _gazedAtObject?.SendMessage("OnPointerMenuL0Exit");
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("OnPointerMenuL0Enter");
                }

                if (hit.transform.name == "ButtonQuit")
                {

                    _gazedAtObject?.SendMessage("OnPointerMenuQExit");
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("OnPointerMenuQEnter");
                }

                if (hit.transform.name == "ButtonLevel1")
                {

                    _gazedAtObject?.SendMessage("OnPointerMenuL1Exit");
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("OnPointerMenuL1Enter");
                }

                // New GameObject.
                /*  _gazedAtObject?.SendMessage("OnPointerExit");
                  _gazedAtObject = hit.transform.gameObject;
                  _gazedAtObject.SendMessage("OnPointerEnter");
                  */
                if (hit.transform.tag == "Menu")
                {
                    _gazedAtObject?.SendMessage("DetenerAnimacionExit");
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("DetenerAnimacion");
                }

                 if (hit.transform.tag == "teleport")
                {
                    _gazedAtObject?.SendMessage("DetenerAnimacionExit");
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("DetenerAnimacion");
                }

                tiempotrasncurrido = 0.0f;


            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            //_gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject?.SendMessage("CargarAnimacion");
            _gazedAtObject = null;
            puntero.fillAmount = 0.0f;

        }
    }

    
}
