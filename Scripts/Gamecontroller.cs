using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamecontroller : MonoBehaviour {
   public GameObject[] cameras;
    private int GameCameraIndex = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            ChangeCamera(1);

        }
        if (Input.GetMouseButtonDown(1))
        {
            ChangeCamera(-1);

        }
    }

    void FocusOnCamera (int index)
    {

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(i == index);

        }
    }

    void ChangeCamera (int direction)
    {

        GameCameraIndex += direction;
        if(GameCameraIndex >= cameras.Length)
        {
            GameCameraIndex = 0;

        }

        if ( GameCameraIndex < 0)
        {
            GameCameraIndex = cameras.Length - 1;
        }
        FocusOnCamera(GameCameraIndex);
    }
}
