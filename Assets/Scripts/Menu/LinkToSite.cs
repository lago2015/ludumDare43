﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkToSite : MonoBehaviour {


    public string url = "https://www.rednorthstudios.com";


    public void OpenInternet()
    {
        Application.OpenURL(url);
    }
}
