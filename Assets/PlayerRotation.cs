using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * 50f * Time.deltaTime;
        gameObject.transform.Rotate(Vector3.up * x);
    }
}
