using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuGaze : MonoBehaviour
{
    // Variables for distance from camera and menu

    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    public GameObject animarMenu;
    //MenuAnimacion menuAnimado;

    private bool gaze = false;
    private Vector3 _startingPosition;


    public void OnPointerMenuQEnter()
    {
	
     	gaze = true;
	Debug.Log("Se toca menu...........");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
			Application.Quit();
        #endif
    }

    public void OnPointerMenuL0Enter()
    {
        SceneManager.LoadScene(2);
        
    }

    public void OnPointerExit()
    {
	gaze = false;
	Debug.Log("Se deja de tocar menu");
    }

    public void OnPointerMenuL0Exit()
    {
	gaze = false;
	Debug.Log("Se deja de tocar menu");
    }


    public void OnPointerMenuQExit()
    {
	gaze = false;
	Debug.Log("Se deja de tocar menu");
    }

    private void Update()
    {
	if(gaze)
	{
		ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
	}
    }
    private void Start()
    {
	_startingPosition = transform.parent.localPosition;
    }
}