using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenciManager : MonoBehaviour
{

    public static PersistenciManager Instance;

    public string PlayerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }


}
