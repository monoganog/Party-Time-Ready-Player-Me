using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DropAvatar : MonoBehaviour
{

    public GameObject avatar;
    public Camera cam;

    GameObject m_PlacedPrefab;
    bool partyStarted = false;

    public GameObject startText;

    public GameObject spawnedObject { get; private set; }

    ARRaycastManager m_RaycastManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!partyStarted && Input.touchCount > 0)
        {
            startText.SetActive(false);
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;

                    Drop(hitPose);
                }
            }
        }
    }

    public void Drop(Pose pose)
    {
        spawnedObject = Instantiate(avatar, pose.position, pose.rotation);
        partyStarted = true;
    }
}
