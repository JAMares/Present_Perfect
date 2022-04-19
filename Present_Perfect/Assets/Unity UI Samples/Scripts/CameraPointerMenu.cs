using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointerMenu : MonoBehaviour
{
    private const float _maxDistance = 600.0f;
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

                if (hit.transform.name == "ButtonExit")
                {
                    _gazedAtObject?.SendMessage("Quit");
                    _gazedAtObject = hit.transform.gameObject;
                }

                if (hit.transform.name == "ButtonPlay")
                {

                    _gazedAtObject?.SendMessage("CargarAula");
                    _gazedAtObject = hit.transform.gameObject;
                }

                tiempotrasncurrido = 0.0f;


            }
        }
        else
        {
            _gazedAtObject?.SendMessage("CargarAnimacion");
            _gazedAtObject = null;
            puntero.fillAmount = 0.0f;

        }
    }
}