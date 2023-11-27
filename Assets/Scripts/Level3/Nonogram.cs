using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nonogram : MonoBehaviour
{
    public int gridSize = 5; // Adjust grid size as needed
    public GameObject cellPrefab;
    public Transform gridParent;

    private int[,] solution = new int[,] { //向左旋转90°
        {1, 1, 1, 1, 1},
        {1, 0, 0, 0, 0},
        {1, 0, 0, 0, 0},
        {1, 0, 0, 0, 0},
        {1, 0, 0, 0, 0}
    }; // Replace this with your puzzle solution

    private GameObject[,] cells;

    void Start()
    {
        cells = new GameObject[gridSize, gridSize];


        // Create grid of cells
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(i, 0, j), Quaternion.identity);
                cell.transform.SetParent(gridParent);
                cells[i, j] = cell;

                // Add Cell component to the cell and set up its properties
                Cell cellScript = cell.GetComponent<Cell>();
                // Add an event listener to each cell to check completion on interaction
                cellScript.OnCellChanged += CheckPuzzleCompletion;
            }
        }
    }

    void CheckPuzzleCompletion()
    {
        bool puzzleSolved = IsPuzzleSolved();
        Debug.Log("Checking: " + puzzleSolved);
        if (puzzleSolved)
        {
            Debug.Log("Puzzle Solved!");
            // Implement your logic for completing the puzzle
        }
    }

    // Function to check if the puzzle is solved
    bool IsPuzzleSolved()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Cell currentCell = cells[i, j].GetComponent<Cell>();
                int solutionValue = solution[i, j];

                // Compare the integer solution value with the IsLit boolean property
                if ((solutionValue == 1 && !currentCell.isLit) || (solutionValue == 0 && currentCell.isLit))
                {
                    return false;
                }
            }
        }
        return true;
    }
}