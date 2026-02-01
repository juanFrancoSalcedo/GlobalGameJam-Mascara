using UnityEngine;

public class disparoEnemigo : MonoBehaviour
{
    public Transform controladorDisparo;
    public float distaciaLinea;
    public LayerMask capaJugador;
    public bool jugadorEnRango;
    public GameObject BalaEnemigo;
    public float tiempoEntreDisparos;
    public float tiempoUltimoDisparo;
    public float tiempoEsperaDisparo;
    public Animator Animator;
    
    void Update()
    {
     jugadorEnRango = Physics2D.Raycast(controladorDisparo.position,transform.right, distaciaLinea, capaJugador); 
        if (jugadorEnRango)
        {
            if (Time.time >= tiempoEntreDisparos + tiempoUltimoDisparo)
            {
                tiempoUltimoDisparo = Time.time;
                
                Invoke(nameof(Disparar), tiempoEsperaDisparo);

            }
        }
    }

    private void Disparar()
    {
        Instantiate(BalaEnemigo, controladorDisparo.position, controladorDisparo.rotation);
    }
    private void OnDrawGizmos()
    {
       Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distaciaLinea);
    }

}
