using UnityEngine;

public class MoveCam : MonoBehaviour
{
    // le digo a la camara que se mueva con el visor
    public Transform cameraPosition;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
