using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTileMap : MonoBehaviour
{

    List<TileElementMisi> FullTiles = new List<TileElementMisi>();
    List<TileElementMisi> EmptyTiles = new List<TileElementMisi>();

    public int[] randomIndexs;
    // Use this for initialization
    void Start()
    {
        foreach (Transform childT in transform)
        {
            childT.GetChild(0).GetComponent<TileElementMisi>().InitTileElement();
            EmptyTiles.Add(childT.GetChild(0).GetComponent<TileElementMisi>());
        }

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
            int idx = Random.Range(0, EmptyTiles.Count);
            FillTile(EmptyTiles[idx]);
        }
    }
    public void EmptyTile(TileElementMisi t)
    {
        FullTiles.Remove(t);
        EmptyTiles.Add(t);
    }
    public void FillTile(TileElementMisi t)
    {
        FullTiles.Add(t);
        EmptyTiles.Remove(t);
        t.Appear(true);
    }


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
}
