using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCreator : MonoBehaviour
{
    public int xCount = 10;
    public int yCount = 10;

    public Cell CellPrefab;

    private Cell[,] cells;

    public float interval = 1;

    // Start is called before the first frame update
    void Start()
    {
        cells = new Cell[xCount, yCount];

        CreateCells(50);
        StartCoroutine(Timer());
    }

    private void CreateCells(double aliveChance)
    {
        Vector3 pos;
        Cell cell;
        for (int i = 0; i < xCount; i++)
        {
            for (int j = 0; j < yCount; j++)
            {
                pos = new Vector3(i, 0, j);
                cell = Instantiate(CellPrefab, pos, Quaternion.identity);
                cell.IsAlive = Random.Range(0, 100) < aliveChance;

                cells[j, i] = cell;
            }
        }
    }

    private int GetNeighboursCount(int x, int y) 
    {
        int count = 0;
        for(int i = x-1; i < x+2; i++)
        {
            for (int j = y-1; j < y+2; j++)
            {
                if (i >= 0 && i < xCount && j >= 0 && j < yCount)
                {
                    if (cells[i, j].IsAlive)
                        count++;
                }
            }
        }
        if (cells[x, y].IsAlive)
            count--;
        return count;
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            DoStep();
        }
    }

    private void DoStep()
    {
        int aliveNeighbours = 0;
        for (int i = 0; i < xCount; i++)
        {
            for (int j = 0; j < yCount; j++)
            {
                aliveNeighbours = GetNeighboursCount(i,j);
                if(cells[i,j].IsAlive)
                {
                    if (aliveNeighbours < 2)
                        cells[i, j].WillBeAlive = false;
                    if (aliveNeighbours > 3)
                        cells[i, j].WillBeAlive = false;
                } else
                {
                    if (aliveNeighbours == 3)
                        cells[i, j].WillBeAlive = true;
                }

            }
        }
        foreach (var cell in cells)
        {
            cell.ApplyState();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
