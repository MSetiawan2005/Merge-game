using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic BM;

    private void Awake()
    {
        if(BM == null)
        {
            BM = this;
            DontDestroyOnLoad(BM);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
