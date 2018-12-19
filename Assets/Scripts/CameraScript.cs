using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    public GameObject objectToFollow;
    public Vector3 camera;
 
    public float speed;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;
        
        Vector3 position = this.transform.position;
        if (objectToFollow.transform.position.x > 0)
            {
            Debug.Log("cono");
                position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

                this.transform.position = position;
            }
        }
    
}
    