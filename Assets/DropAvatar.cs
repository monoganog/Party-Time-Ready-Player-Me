using UnityEngine;

public class DropAvatar : MonoBehaviour
{
    public GameObject avatar;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Drop()
    {
        Instantiate(avatar, cam.transform.position - Vector3.up, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
