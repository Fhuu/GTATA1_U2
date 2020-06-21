
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshFilter))]
public class TerrainMesh : MonoBehaviour
{
    public GameObject container, prefab, prefabBrownish;
    public int xSize, zSize;
    // Start is called before the first frame update
    
    void Start()
    {
        AddVertices();
    }
    

    private void AddVertices()
    {
        
        for (int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                if (Random.Range(0, 2) == 1)
                {
                    var createdObject = Instantiate(prefab, new Vector3((x - xSize / 2) * 2, 0, (z - zSize / 2) * 2),Quaternion.identity);
                    createdObject.transform.parent = container.transform;
                }
                else
                {
                    var createdObject = Instantiate(prefabBrownish, new Vector3((x - xSize / 2) * 2, 0, (z - zSize / 2) * 2),Quaternion.identity);          
                    createdObject.transform.parent = container.transform;
                }
            }
        }
    }
}
