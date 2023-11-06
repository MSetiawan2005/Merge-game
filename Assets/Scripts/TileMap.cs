using UnityEngine;
using System.Collections.Generic;

public class TileMap : MonoBehaviour
{
    List<TileElement> FullTiles = new List<TileElement>();
    List<TileElement> EmptyTiles = new List<TileElement>();
    // Use this for initialization

    //public int[] randomIndexs;

    void Start()
    {
        foreach (Transform childT in transform)
        {
            childT.GetChild(0).GetComponent<TileElement>().InitTileElement();
            EmptyTiles.Add(childT.GetChild(0).GetComponent<TileElement>());
        }

        //randomIndex();
        InvokeRepeating("CreateNewTile", 0.0f, 0.1f);
    }

    void CreateNewTile()
    {
        if (EmptyTiles.Count == 0)
        {
            Debug.Log("Game Ended!");
        }
        else
        {
            int idx = Random.Range(0, EmptyTiles.Count );
            FillTile(EmptyTiles[idx]);
        }
    }
    public void EmptyTile(TileElement t)
    {
        FullTiles.Remove(t);
        EmptyTiles.Add(t);
    }
    public void FillTile(TileElement t)
    {
        FullTiles.Add(t);
        EmptyTiles.Remove(t);
        t.Appear(true);
    }


    /*
    public void randomIndex()
    {
        for (int i = 0; i < randomIndexs.Length; i++)
        {
            int a = randomIndexs[i];
            int result = Random.Range(0, randomIndexs.Length);
            randomIndexs[i] = randomIndexs[result];
            randomIndexs[result] = a;
        }
    }

    */
}
