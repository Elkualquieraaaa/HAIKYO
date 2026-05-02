using UnityEngine;

public class ActivarSistema : MonoBehaviour
{
    public SistemaEventos sistema;
    public int eventoAlEntrar = 0;
    public int eventoAlSalir = 1;

    private bool yaActivado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !yaActivado)
        {
            sistema.ActivarEvento(eventoAlEntrar);
            yaActivado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")&& yaActivado)
        {
            sistema.ActivarEvento(eventoAlSalir);
        }
    }
}
