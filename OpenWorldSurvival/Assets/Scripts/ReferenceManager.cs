using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager instance;
    [SerializeField] private Canvas canvas;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    public Canvas getCamvas()
    {
        return canvas;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
