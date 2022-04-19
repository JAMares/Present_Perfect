using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sentPosController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource explanaxion;
    private Renderer _myRenderer;
    public AudioSource background;
    void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        
    }

    public void OnPointerEnter()
    {
        background.Stop();
        explanaxion.Play();
    }

    public void OnPointerExit()
    {
        background.Play();
        explanaxion.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
