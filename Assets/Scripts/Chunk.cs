using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    private static int chunkWidth = 16;
    private static int chunkHeight = 256;
    private BlockType[,,] chunkMap = new BlockType[chunkWidth, chunkHeight, chunkWidth];

    private Mesh mesh;
    private List<Vector3> vertices = new List<Vector3>();
    private List<int> triangles = new List<int>();
    private List<Vector2> uvs = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateChunk();
    }

    // Gera o chunk
    private void GenerateChunk()
    {
        // Gera o mapa do chunk
        for (int y = 0; y < chunkHeight; y++)
        {
            for (int x = 0; x < chunkWidth; x++)
            {
                for (int z = 0; z < chunkWidth; z++)
                {
                    chunkMap[x, y, z] = BlockType.Stone;
                }
            }
        }

        // Gera cada bloco no chunk
        Vector3 vertexPos;
        int trianglePos = 0;

        for (int y = 0; y < chunkHeight; y++)
        {
            for (int x = 0; x < chunkWidth; x++)
            {
                for (int z = 0; z < chunkWidth; z++)
                {
                    vertexPos = new Vector3(x, y, z);

                    for (int i = 0; i < 6; i++)
                    {
                        if (CheckBlock(vertexPos + Block.faces[i]) == BlockType.Air)
                        {
                            // Adiciona os vertices e tri�ngulos
                            for (int j = 0; j < 4; j++)
                            {
                                vertices.Add(Block.vertices[i, j] + vertexPos);
                            }

                            for (int j = 0; j < 6; j++)
                            {
                                triangles.Add(Block.triangles[i, j] + trianglePos);
                                
                            }

                            // Adiciona os uvs
                            for (int j = 0; j < 4; j++)
                            {
                                uvs.Add(Block.uvs[j]);
                            }
                        }
                        else
                        {
                            trianglePos -= 4; // Diminui os triangulos se a face n�o existir
                        }

                    }
                    trianglePos += 24; // Soma a quantia de tri�ngulos em um bloco
                }
            }
        }

        GenerateMesh();
    }

    // Verifica se existem blocos adjacentes
    private BlockType CheckBlock(Vector3 blockPos)
    {
        int x = (int)blockPos.x;
        int y = (int)blockPos.y;
        int z = (int)blockPos.z;

        if (x < 0 || x > chunkWidth - 1 || y < 0 || y > chunkHeight - 1 || z < 0 || z > chunkWidth - 1)
        {
            return BlockType.Air;
        }

        return chunkMap[x, y, z];
    }

    // Gera a malha do chunk
    private void GenerateMesh()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();
    }
}