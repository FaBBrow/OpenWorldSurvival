using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager instance;
    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public Canvas getCamvas()
    {
        return canvas;
    }
}