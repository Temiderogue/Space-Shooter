﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundary : MonoBehaviour {

    public void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
