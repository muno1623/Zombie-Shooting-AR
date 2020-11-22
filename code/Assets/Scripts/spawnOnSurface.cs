using System.Collections.Generic;
using GoogleARCore;
using GoogleARCore.Examples.Common;
using UnityEngine;
using UnityEngine.EventSystems;

public class spawnOnSurface : MonoBehaviour
{
    private bool bazukaBool = false;
    private bool houseBool = true;
    public GameObject house;
    public GameObject bazuka;
    public GameObject zombie;
    private List<DetectedPlane> m_NewPlanes = new List<DetectedPlane>();
    public Camera FirstPersonCamera;
    private const float k_PrefabRotation = 180.0f;
    TrackableHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // If the player has not touched the screen, we are done with this update.
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        // Should not handle input if the player is pointing on UI.
        // If the player has not touched the screen, we are done with this update.

        // Should not handle input if the player is pointing on UI.
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }
        // Raycast against the location the player touched to search for planes.
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;

        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            // Use hit pose and camera pose to check if hittest is from the
            // back of the plane, if it is, no need to create the anchor.
            if ((hit.Trackable is DetectedPlane) &&
                Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
                    hit.Pose.rotation * Vector3.up) < 0)
            {
                Debug.Log("Hit at back of the current DetectedPlane");
            }
            else
            {
                // Choose the prefab based on the Trackable that got hit.


                if (hit.Trackable is DetectedPlane)
                {
                    DetectedPlane detectedPlane = hit.Trackable as DetectedPlane;
                    if (detectedPlane.PlaneType != DetectedPlaneType.Vertical)
                    {
                        if(houseBool == true)
                        {
                            SpawnHouse();
                            InvokeZombie();
                            InvokeBazuka();
                            houseBool = false;
                            
                        }
                        
                    }
                }
            }
        }
    }
    void InvokeZombie()
    {
        InvokeRepeating("SpawnZombie", 0f, 7f);
    }
    void InvokeBazuka()
    {
        InvokeRepeating("SpawnBazuka", 0f, 5f);
    }

    void SpawnBazuka()
    {
        Vector3 pos = new Vector3(Random.Range(hit.Pose.position.x + 20f, hit.Pose.position.x - 20f), hit.Pose.position.y, Random.Range(hit.Pose.position.z + 20f, hit.Pose.position.z - 20f));
        var gameObject = Instantiate(bazuka, pos, hit.Pose.rotation);
        // Compensate for the hitPose rotation facing away from the raycast (i.e.
        // camera).
        gameObject.transform.Rotate(0, k_PrefabRotation, 0, Space.Self);

        // Create an anchor to allow ARCore to track the hitpoint as understanding of
        // the physical world evolves.
        var anchor = hit.Trackable.CreateAnchor(hit.Pose);

        // Make game object a child of the anchor.
        gameObject.transform.parent = anchor.transform;
        
    }
    void SpawnZombie()
    {
        Vector3 pos = new Vector3(Random.Range(hit.Pose.position.x + 15f, hit.Pose.position.x - 15f), hit.Pose.position.y, Random.Range(hit.Pose.position.z + 15f, hit.Pose.position.z - 15f));
        var gameObject = Instantiate(zombie, pos, hit.Pose.rotation);
        // Compensate for the hitPose rotation facing away from the raycast (i.e.
        // camera).
        gameObject.transform.Rotate(0, k_PrefabRotation, 0, Space.Self);

        // Create an anchor to allow ARCore to track the hitpoint as understanding of
        // the physical world evolves.
        var anchor = hit.Trackable.CreateAnchor(hit.Pose);

        // Make game object a child of the anchor.
        gameObject.transform.parent = anchor.transform;

    }
    void SpawnHouse()
    {
        Vector3 pos = new Vector3(hit.Pose.position.x, hit.Pose.position.y, hit.Pose.rotation.z);
        var gameObject = Instantiate(house, hit.Pose.position, hit.Pose.rotation);
        // Compensate for the hitPose rotation facing away from the raycast (i.e.
        // camera).
        gameObject.transform.Rotate(0, k_PrefabRotation, 0, Space.Self);

        // Create an anchor to allow ARCore to track the hitpoint as understanding of
        // the physical world evolves.
        var anchor = hit.Trackable.CreateAnchor(hit.Pose);

        // Make game object a child of the anchor.
        gameObject.transform.parent = anchor.transform;

    }
}
