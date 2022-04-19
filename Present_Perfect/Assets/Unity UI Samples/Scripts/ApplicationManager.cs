using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class ApplicationManager : MonoBehaviour {
	

public void Quit () 
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

public void CargarAula()
    {

		SceneManager.LoadScene(2);

    }


}
