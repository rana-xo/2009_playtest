using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultObject : MonoBehaviour, IObjectInteract
{
    private float timer;

   public void Interact()
    {
        Debug.Log(Random.Range(0, 100));
    }


    void Start()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Explode();
        }
    }

    private void Explode()
    {
        //pantalla blanca, pitido, game over a los 3seg

        timer += Time.deltaTime;

        if(timer < 3)
        {
            SceneManager.LoadSceneAsync(1); //gameover
        }

        
    }
}
