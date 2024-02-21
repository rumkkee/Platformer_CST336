using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelResources : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    public static LevelResources instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public Coin GetCoin() => _coinPrefab;

}
