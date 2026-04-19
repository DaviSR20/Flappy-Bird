using System;
using UnityEngine;

public class PipeHit : MonoBehaviour
{
    public GameObject Pipe;
    private Pipe PipeGM;
    private void Start()
    {
        if (Pipe == null)
        {
            Pipe = GameObject.FindGameObjectWithTag("Pipe");
        }

        PipeGM = Pipe.GetComponent<Pipe>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PipeGM.PipeHit();
        }
    }
}
