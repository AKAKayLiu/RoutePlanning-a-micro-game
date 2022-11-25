using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchMenu : MonoBehaviour
{

    public static BranchMenu Instance;
    private void Awake()
    {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

}
