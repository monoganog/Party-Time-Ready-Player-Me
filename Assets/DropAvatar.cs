using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DropAvatar : MonoBehaviour
{

    GameObject m_PlacedPrefab;
    bool partyStarted = false;

    public GameObject startText;

    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    public GameObject spawnedObject { get; private set; }

    /// <summary>
    /// Invoked whenever an object is placed in on a plane.
    /// </summary>
    public static event Action onPlacedObject;

    ARRaycastManager m_RaycastManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }


    public GameObject avatar;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            startText.SetActive(false);
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;

                    spawnedObject = Instantiate(avatar, hitPose.position, hitPose.rotation);


                    partyStarted = true;

                }
            }
        }
    }

    public void Drop()
    {
        Instantiate(avatar, cam.transform.position - Vector3.up, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
