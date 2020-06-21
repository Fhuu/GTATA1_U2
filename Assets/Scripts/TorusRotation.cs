using UnityEngine;

public class TorusRotation : MonoBehaviour
{
    public int x, y, z;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(x * Time.deltaTime,y * Time.deltaTime,z * Time.deltaTime);
    }
}
