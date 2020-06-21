using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float _yRotation;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * 50f * Time.deltaTime;
        gameObject.transform.Rotate(Vector3.up * x);
    }
}
