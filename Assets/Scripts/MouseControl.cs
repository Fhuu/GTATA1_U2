using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private float _xRotation;
    // Start is called before the first frame update
    void Start()
    {
        _xRotation = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse Y") * 50f * Time.deltaTime;
        _xRotation -= y;
        gameObject.transform.localRotation = Quaternion.Euler(_xRotation, 0,0);
    }
}
