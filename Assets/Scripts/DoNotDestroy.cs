using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    public string tag;

    private void Awake()
    {
        DontDestroy(tag);
    }

    public void DontDestroy( string tag)
    {
        GameObject[] gameObject = GameObject.FindGameObjectsWithTag(tag);

        if (gameObject.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
