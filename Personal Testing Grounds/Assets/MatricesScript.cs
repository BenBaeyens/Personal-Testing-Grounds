using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatricesScript : MonoBehaviour
{

    [Range(0, 25)] public int x = 10;
    [Range(0, 25)] public int y = 10;
    [Range(0.01f, 2.5f)] public float objectSize = 0.4f;
    [Range(0.5f, 10f)] public float spaceBetweenObjects = 1f;

    public PrimitiveType type = PrimitiveType.Sphere;

    List<List<GameObject>> grid = new List<List<GameObject>>();

    [HideInInspector] int originalx;
    [HideInInspector] int originaly;
    [HideInInspector] PrimitiveType originalType;
    [HideInInspector] float originalObjectSize;
    [HideInInspector] float originalSpaceBetweenObjects;

    private void Start()
    {
        originalx = x;
        originaly = y;
        originalType = type;
        originalObjectSize = objectSize;
        CreateGrid();
    }

    private void Update()
    {
        if (x != originalx || y != originaly || type != originalType || objectSize != originalObjectSize || spaceBetweenObjects != originalSpaceBetweenObjects)
        {
            ClearGrid();
            CreateGrid();
            originalx = x;
            originaly = y;
            originalType = type;
            originalObjectSize = objectSize;
            originalSpaceBetweenObjects = spaceBetweenObjects;
        }
    }

    private void ClearGrid()
    {
        for (int r = 0; r < originalx; r++)
        {
            for (int c = 0; c < originaly; c++)
            {
                Destroy(grid[r][c]);
            }
        }
        grid.Clear();
    }

    private void CreateGrid()
    {
        for (int r = 0; r < x; r++)
        {
            grid.Add(new List<GameObject>());
            for (int c = 0; c < y; c++)
            {
                grid[r].Add(GameObject.CreatePrimitive(type));
                grid[r][c].transform.position = new Vector3(c * spaceBetweenObjects, 0, r * spaceBetweenObjects);
                grid[r][c].transform.localScale *= objectSize;
            }
        }
    }

}
