using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;

    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("DoorOpen", true);
        anim.SetBool("DoorClose", false);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("DoorOpen", false);
        anim.SetBool("DoorClose", true);
    }
}