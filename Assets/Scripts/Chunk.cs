using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();

    int chunkWidth = 10;
    int chunkHeight = 16;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        Vector3 vertexPos;
        int trianglePos = 0;

        for(int y = 0; y < chunkHeight; y++)
        {
            for(int x = 0; x < chunkWidth; x++)
            {
                for(int z = 0; z < chunkWidth; z++)
                {
                    vertexPos = new Vector3(x, y, z);

                    for (int i = 0; i < 24; i++)
                    {
                        vertices.Add(Block.vertices[i] + vertexPos);
                    }

                    for (int i = 0; i < 36; i++)
                    {
                        triangles.Add(Block.triangles[i] + trianglePos);
                    }

                    trianglePos += 24;
                }
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();
    }
}
