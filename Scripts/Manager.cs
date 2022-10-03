using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Manager : MonoBehaviour
{
    private ARTrackedImageManager _TrackedImageManager;
   
    public Texture2D texture;
   

    private void Awake()
    {
        _TrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void Referesh()
    {
        SceneManager.LoadScene(0);
    }
    public void AddImagesBtn()
    {
        AddImage(texture);
    }

    // Add Image at run time
    void AddImage(Texture2D imageToAdd)
    {
        if (_TrackedImageManager.referenceLibrary is MutableRuntimeReferenceImageLibrary mutableLibrary)
        {
            mutableLibrary.ScheduleAddImageJob(
                imageToAdd,
                "my new image",
                0.5f /* 50 cm */);
            Debug.Log("Image Added");
        }
    }
}
