using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System.Linq;

public class Test : MonoBehaviour
{

    public string ReferenceImageName;
    private ARTrackedImageManager _TrackedImageManager;
    public Text debugAR;
    public Texture2D texture;
    GameObject testObj;

    private void Awake()
    {
        _TrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        if (_TrackedImageManager != null)
        {
            _TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        ListAllImages();
    }
    private void OnDisable()
    {
        if (_TrackedImageManager != null)
        {
            _TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs e)
    {
        foreach (var trackedImage in e.added)
        {
            Debug.Log($"Tracked image detected: {trackedImage.referenceImage.name} with size: {trackedImage.size}");
        }

        UpdateTrackedImages(e.added);
        UpdateTrackedImages(e.updated);
    }

    private void UpdateTrackedImages(IEnumerable<ARTrackedImage> trackedImages)
    {
        // If the same image (ReferenceImageName)
        var trackedImage =
            trackedImages.FirstOrDefault(x => x.referenceImage.name == ReferenceImageName);
        if (trackedImage == null)
        {
            return;
        }


        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            debugAR.text = "isTracking";
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            var trackedImageTransform = trackedImage.transform;
            transform.SetPositionAndRotation(trackedImageTransform.position, trackedImageTransform.rotation);

        }


        if (trackedImage.trackingState == TrackingState.Limited)
        {
            debugAR.text = "isNotTracking";
              gameObject.GetComponent<MeshRenderer>().enabled = false;
           // transform.parent = testObj.transform;
           // transform.position = trackedImage.transform.position;

        }
    }

    
  
    // Debug List of Images
    void ListAllImages()
    {
        debugAR.text = "Started";
        Debug.Log(
            $"There are {_TrackedImageManager.trackables.count} images being tracked.");

        foreach (var trackedImage in _TrackedImageManager.trackables)
        {
            Debug.Log($"Image: {trackedImage.referenceImage.name} is at " +
                      $"{trackedImage.transform.position}");
            debugAR.text = $"Image: {trackedImage.referenceImage.name} is at " +
                      $"{trackedImage.transform.position}";
        }
    }
}
