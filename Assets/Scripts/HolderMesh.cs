using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class HolderMesh : MonoBehaviour
{
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
        gameObject.AddComponent<MeshCollider>();
        AddVertices();
        CreateShape();
        ApplyMesh();
        gameObject.GetComponent<MeshCollider>().sharedMesh = _mesh;
    }

    private void AddVertices()
    {
        int pos = 0;
        int counter = 0;
        int offset = 0;
        double angle = 2 * Math.PI / smoothness;
        for (int u = 5; u <= smoothness + 5; u++,counter++)
        {
            if (counter >= 4)
            {
                offset += 7;
                counter = 0;
            }
            for (int v = 0; v <= smoothness; v++,pos++)
            {
                float x = (float) ((u + offset) * Math.Cos(angle * v));
                float z = (float)((u + offset) * Math.Sin(angle * v));
                float y = -(u*2 + offset);
                _vertices[pos] = new Vector3(x,y,z);
                _uvs[pos] = new Vector2(u, v);
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
                _triangles[offset + 2] = x + row;
                _triangles[offset + 1] = x + smoothness + 1 + row;
                _triangles[offset + 0] = x + 1 + row;
                _triangles[offset + 5] = x + 1 + row;
                _triangles[offset + 4] = x + smoothness + 1 + row;
                _triangles[offset + 3] = x + smoothness + 2 + row;
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