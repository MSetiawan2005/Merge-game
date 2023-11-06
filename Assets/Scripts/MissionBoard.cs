using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBoard : MonoBehaviour
{
    [SerializeField]
    List<Sprite> TileSpritesMission = new List<Sprite>();
    public Stack TileSpritesStacked = new Stack();

    public int[] randomIndexs;
    void Awake()
    {
        FillSpritesStack();
    }
    void FillSpritesStack()
    {
        TileSpritesMission.Reverse();
        foreach (Sprite s in TileSpritesMission)
        {

            TileSpritesStacked.Push(s);
        }


    }
    public Stack GetTileSpritesStack()
    {
        return (Stack)TileSpritesStacked.Clone();
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
