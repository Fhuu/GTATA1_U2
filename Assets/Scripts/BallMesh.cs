using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class BallMesh : MonoBehaviour
{
    public int r;
    public int smoothness;
    private Mesh _mesh;
    private Vector3[] _vertices;
    private Vector2[] _uvs;
    private int[] _triangles;


    // Start is called before the first frame update
    void Start()
    {
        _mesh = new Mesh();
        _vertices = new Vector3[(smoothness + 1) * (smoothness + 1) * 2];
        _uvs = new Vector2[_vertices.Length];
        _triangles = new int[_vertices.Length * 6];
        GetComponent<MeshFilter>().mesh = _mesh;
        AddVertices();
        CreateShape();
        ApplyMesh();
        
    }
    /**
     * Formula:
     * r > 0, center (x0,y0,z0)
     * x = x0 + r sin(beta)cos(gamma)
     * y = y0 + r sin(beta)sin(gamma)
     * z = z0 + r cos(beta)
     * 0 < beta < pi, 0 < gamma < 2pi
    */
    private void AddVertices()
    {
        int pos = 0;

        double angle = 2 * Math.PI / smoothness;
        for (int betaPart = 0; betaPart <= smoothness; betaPart++)
        {
            var v = (1f / smoothness) * betaPart;
            for (int gammaPart = 0; gammaPart <= smoothness; gammaPart++)
            {
                var u = (1f / smoothness) * gammaPart;
                float x = (float)(r * Math.Sin(angle * betaPart) * Math.Cos(angle * gammaPart));
                float y = (float)(r * Math.Sin(angle * betaPart) * Math.Sin(angle * gammaPart));
                float z = (float)(r * Math.Cos(angle * betaPart));
                _vertices[pos] = new Vector3(x,y,z);
                _uvs[pos] = new Vector2(u, v);
                pos++;
            }
        }
        //print(pos);
    }
    
    private void CreateShape()
    {
        int offset = 0;
        for (int z = 0; z < smoothness; z++)
        {
            int row = z * (smoothness + 1);
            for (int x = 0; x < smoothness; x++)
            {
                _triangles[offset + 0] = x + row;
                _triangles[offset + 1] = x + smoothness + 1 + row;
                _triangles[offset + 2] = x + 1 + row;
                _triangles[offset + 3] = x + 1 + row;
                _triangles[offset + 4] = x + smoothness + 1 + row;
                _triangles[offset + 5] = x + smoothness + 2 + row;
                offset = offset + 6;    
            }
        }
        //print(offset + 6);
    }
    
    private void ApplyMesh()
    {
        _mesh.vertices = _vertices;
        _mesh.uv = _uvs;
        _mesh.triangles = _triangles;
    }
}
