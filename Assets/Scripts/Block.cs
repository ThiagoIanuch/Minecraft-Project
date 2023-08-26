using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static Vector3[] vertices = new Vector3[24] {
        // Front
        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(1, 1, 0),

        // Back
        new Vector3(1, 0, 1),
        new Vector3(0, 0, 1),
        new Vector3(1, 1, 1),
        new Vector3(0, 1, 1),

        // Right
        new Vector3(1, 0, 0),
        new Vector3(1, 0, 1),
        new Vector3(1, 1, 0),
        new Vector3(1, 1, 1),

        // Left
        new Vector3(0, 0, 1),
        new Vector3(0, 0, 0),
        new Vector3(0, 1, 1),
        new Vector3(0, 1, 0),

        // Top
        new Vector3(0, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(0, 1, 1),
        new Vector3(1, 1, 1),

        // Bottom
        new Vector3(0, 0, 1),
        new Vector3(1, 0, 1),
        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0)

    };

    public static int[] triangles = new int[36]
    {
        // Front
        0, 2, 3,
        0, 3, 1,

        // Back
        4, 6, 7,
        4, 7, 5,

        // Right
        8, 10, 11,
        8, 11, 9,

        // Left
        12, 14, 15,
        12, 15, 13,

        // Top
        16, 18, 19,
        16, 19, 17,

        // Bottom
        20, 22, 23,
        20, 23, 21
    };
}