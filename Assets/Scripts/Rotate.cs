using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform ballGenerator;
    public int speed;

    private float _rotation;
    // Start is called before the first frame update
    void Start()
    {
        _rotation = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_rotation >= 360.0f)
        {
            _rotation = 0.0f;
        }

        _rotation += speed * Time.deltaTime;
        ballGenerator.localRotation = Quaternion.Euler(67,_rotation, 67);
    }
}
