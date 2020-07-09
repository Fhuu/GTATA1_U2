using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    // Start is called before the first frame update


    // Update is called once per frame

    void FixedUpdate()
    {
        GetDirection();
    }

    private void GetDirection()
    {
        if(Input.GetKey(KeyCode.A)) gameObject.transform.Translate(Vector3.left * (Time.deltaTime * movementSpeed));
        if(Input.GetKey(KeyCode.D)) gameObject.transform.Translate(Vector3.right * (Time.deltaTime * movementSpeed));
        if(Input.GetKey(KeyCode.S)) gameObject.transform.Translate(Vector3.back * (Time.deltaTime * movementSpeed));
        if(Input.GetKey(KeyCode.W)) gameObject.transform.Translate(Vector3.forward * (Time.deltaTime * movementSpeed));
        if(Input.GetKey(KeyCode.Space)) gameObject.transform.Translate(Vector3.up *  (Time.deltaTime * movementSpeed));
        if(Input.GetKey(KeyCode.LeftControl)) gameObject.transform.Translate(Vector3.down * (Time.deltaTime * movementSpeed));
    }
}
