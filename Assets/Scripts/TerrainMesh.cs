using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TerrainMesh : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private float heightPower;
    private Mesh _mesh;
    private Vector3[] _vertices;
    private Vector2[] _uvs;
    private int[] _triangles;
    // Start is called before the first frame update
    
    void Start()
    {
        _mesh = new Mesh();
        _vertices = new Vector3[(size + 1) * (size + 1)];
        _uvs = new Vector2[_vertices.Length];
        _triangles = new int[_vertices.Length * 6];
        GetComponent<MeshFilter>().mesh = _mesh;
        AddVertices();
        CreateShape();
        ApplyMesh();
        
    }
    
    private void AddVertices()
    {
        int pos = 0;
        for (float z = 0; z <= size; z++)
        {
            for (float x = 0; x <= size; x++)

            {
                
                _vertices[pos] = new Vector3(x*8,0,z*8);
                _uvs[pos] = new Vector2(x, z);
                pos++;
            }
        }
    }
    
    private void CreateShape()
    {
        int offset = 0;
        for (int z = 0; z < size; z++)
        {
            int row = z * (size + 1);
            for (int x = 0; x < size; x++)
            {
                _triangles[offset + 0] = x + row;
                _triangles[offset + 1] = x + size + 1 + row;
                _triangles[offset + 2] = x + 1 + row;
                _triangles[offset + 3] = x + 1 + row;
                _triangles[offset + 4] = x + size + 1 + row;
                _triangles[offset + 5] = x + size + 2 + row;
                offset = offset + 6;    
            }
        }
    }
    
    private void ApplyMesh()
    {
        _mesh.vertices = _vertices;
        _mesh.uv = _uvs;
        _mesh.triangles = _triangles;
    }
}
