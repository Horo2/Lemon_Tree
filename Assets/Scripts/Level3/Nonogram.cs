using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nonogram : MonoBehaviour
{
    public int gridSize = 5; // Adjust grid size as needed
    public GameObject cellPrefab;
    public Transform gridParent;

    public DialogSystem dialogSystem;


    private int[,] solution = new int[,] { // 我也不知道向哪旋转：）
        {1, 1, 1, 1, 0, 0, 1},
        {1, 0, 0, 1, 0, 0, 1},
        {1, 0, 0, 1, 1, 1, 1},
        {0, 0, 0, 0, 0, 0, 0},
        {1, 0, 0, 1, 1, 1, 1},
        {1, 0, 0, 1, 0, 0, 1},
        {1, 1, 1, 1, 0, 0, 1}
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
                GameObject cell = Instantiate(cellPrefab, gridParent.position + new Vector3(i, -0.6f, j), Quaternion.identity);
                cell.transform.SetParent(gridParent);
                cells[i, j] = cell;

                // Add Cell component to the cell and set up its properties
                Cell cellScript = cell.GetComponent<Cell>();
                // Add an event listener to each cell to check completion on interaction
                cellScript.OnCellChanged += CheckPuzzleCompletion;
            }
        }
        dialogSystem.GetComponent<DialogSystem>().enabled = false;
    }

    void CheckPuzzleCompletion()
    {
        bool puzzleSolved = IsPuzzleSolved();
        Debug.Log("Checking: " + puzzleSolved);
        if (puzzleSolved)
        {
            Debug.Log("Puzzle Solved!");
            dialogSystem.GetComponent<DialogSystem>().enabled = true;
            dialogSystem.dialogIndex = 6;
            // Implement your logic for completing the puzzle
            SceneManager.LoadSceneAsync("Level Selection");
        }
    }

    // Function to check if the puzzle is solved
    bool IsPuzzleSolved()
    {
        int[,] current = new int[,] { //向左旋转90°
        { 1, 0, 0, 1, 1, 1, 1},
        {1, 0, 0, 1, 0, 0, 1},
        {1, 1, 1, 1, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 0},
        {1, 1, 1, 1, 0, 0, 1},
        {1, 0, 0, 1, 0, 0, 1},
        {1, 0, 0, 1, 1, 1, 1}
        };

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Cell currentCell = cells[i, j].GetComponent<Cell>();
                int solutionValue = solution[i, j];

                if (currentCell.isLit)
                {
                    current[i, j] = 1;
                }
                else
                {
                    current[i, j] = 0;
                }
                
                // Compare the integer solution value with the IsLit boolean property
                if ((solutionValue == 1 && !currentCell.isLit) || (solutionValue == 0 && currentCell.isLit))
                {
                    return false;
                }
            }
        }
        //int rows = 7;
        //int columns = 7;
        //Debug.Log("start");
        //// Printing the array
        //for (int a = 0; a < rows; a++)
        //{
        //    for (int k = 0; k < columns; k++)
        //    {
        //        Debug.Log(current[a, k] + " ");
        //    }
        //    Debug.Log("-----------------------");
        //}
        //return false;
        GameObject gameObject = GameObject.Find("GameStateManager");
        gameObject.GetComponent<GameStateManager>().nextPhase();
        return true;
    }


}