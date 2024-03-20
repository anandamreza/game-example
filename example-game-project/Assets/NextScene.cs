using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public VideoPlayer myVideo;
    // Start is called before the first frame update
    void Start()
    {
        myVideo.loopPointReached += nextScene;
    }

    // Update is called once per frame
    void nextScene(VideoPlayer vp){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
