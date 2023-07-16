using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform target;
    public Vector2 targetpos;
    public Vector3 target3Dpos;
    public float smothing;
    public float offsetX, offsetZ, offsetY;
    public float leftBoundry;
    public float rightBoundry;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /*
        targetpos = new Vector2(target.transform.position.x,target.transform.position.y);
        transform.position = Vector2.Lerp(transform.position,targetpos,smothing * Time.deltaTime);
        */
        #region 3dOBJ follow
        if (transform.position.x >  rightBoundry || transform.position.x < leftBoundry)
        {
            target3Dpos = new Vector3(target.transform.position.x - offsetX, target.transform.position.y - offsetY, transform.position.z - offsetZ);
            transform.position = Vector3.Lerp(transform.position, target3Dpos, smothing * Time.deltaTime);
        }
        
        #endregion
    }

    
}
