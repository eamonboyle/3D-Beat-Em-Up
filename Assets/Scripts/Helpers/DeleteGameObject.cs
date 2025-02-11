﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameObject : MonoBehaviour
{
    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeleteGameObjectAfter", timer);
    }

    void DeleteGameObjectAfter()
    {
        Destroy(gameObject);
    }
}
