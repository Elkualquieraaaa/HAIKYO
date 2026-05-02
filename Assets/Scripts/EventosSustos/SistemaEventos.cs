using UnityEngine;
using System.Collections;

[System.Serializable]
public class Evento
{
    public string nombre;

    public GameObject[] activar;
    public GameObject[] desactivar;

    public float delay;

    public int[] siguientesEventos; //Estos son los eventos que se activan despues.
}


public class SistemaEventos : MonoBehaviour
{
    public Evento[] eventos;

    public void ActivarEvento(int index)
    {
        if (index < 0 || index >= eventos.Length) return;

        StartCoroutine(Ejecutar(eventos[index]));
    }

    IEnumerator Ejecutar(Evento e)
    {
        //Espera
        yield return new WaitForSeconds(e.delay);

        //Activar
        foreach (GameObject obj in e.activar)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        //Desactivar
        foreach (GameObject obj in e.desactivar)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        //Activar siguientes eventos
        foreach (int i in e.siguientesEventos)
        {
            ActivarEvento(i);
        }
    }
    
}
