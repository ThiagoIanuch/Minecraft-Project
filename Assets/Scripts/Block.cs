using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Block
{
    // Vertices do bloco
    public static Vector3[,] vertices = new Vector3[6, 4] {
        // Frente
        { 
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0) 
        },

        // Trás
        {
            new Vector3(1, 0, 1),
            new Vector3(0, 0, 1),
            new Vector3(1, 1, 1),
            new Vector3(0, 1, 1)
        },

        // Direita
        { 
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1),
            new Vector3(1, 1, 0),
            new Vector3(1, 1, 1) 
        },

        // Esquerda
        { 
            new Vector3(0, 0, 1),
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 1),
            new Vector3(0, 1, 0) 
        },

        // Cima
        { 
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
            new Vector3(0, 1, 1),
            new Vector3(1, 1, 1) 
        },

        // Baixo
        { 
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0)
        }
    };

    // Triângulos do bloco
    public static int[,] triangles = new int[6,6]
    {
        { 0, 2, 3, 0, 3, 1}, // Frente
        { 4, 6, 7, 4, 7, 5}, // Trás
        { 8, 10, 11, 8, 11, 9}, // Direita
        { 12, 14, 15, 12, 15, 13}, // Esquerda
        { 16, 18, 19, 16, 19, 17}, // Cima
        { 20, 22, 23, 20, 23, 21} // Baixo
    };

    // Uvs do bloco
    public static Vector2[] uvs = new Vector2[4]
    {
        new Vector2(0, 0),
        new Vector2(1, 0),
        new Vector2(0, 1),
        new Vector2(1, 1)
    };

    // Faces do bloco a serem checadas
    public static Vector3[] faces = new Vector3[6]
    {
        new Vector3(0, 0, -1), // Frente
        new Vector3(0, 0, 1), // Trás
        new Vector3(1, 0, 0), // Direita
        new Vector3(-1, 0, 0), // Esquerda
        new Vector3(0, 1, 0), // Cima
        new Vector3(0, -1, 0) // Baixo
    };
}

// Informações sobre o tipo de bloco
[System.Serializable]
public class BlockType
{
    public int id;
    public string name;
}

// Informações sobre todos os tipos de blocos
[System.Serializable]
public class BlockTypes
{
    public BlockType[] blocktypes;
}