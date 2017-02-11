using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scenemager : MonoBehaviour
{
    public void GoToFase1()
    {
        //Transicao de fase pelo nome
        SceneManager.LoadScene("Fase1");
    }

    public void GoToFase2()
    {
        //Transicao de fase pelo indice
        SceneManager.LoadScene(2);
    }

    public void goToMenu()
    {        
        SceneManager.LoadScene(0);
    }
}
