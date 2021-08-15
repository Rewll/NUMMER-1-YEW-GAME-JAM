using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class sceneLoader1 : MonoBehaviour
{
    public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component

    void Start()
    {
        VideoPlayer.loopPointReached += LoadScene;
    }
    void LoadScene(VideoPlayer vp)
    {
        StartCoroutine(waitForABit());
    }

    IEnumerator waitForABit()
    {
        yield return new WaitForSecondsRealtime(3);
        Application.Quit();
    }
}