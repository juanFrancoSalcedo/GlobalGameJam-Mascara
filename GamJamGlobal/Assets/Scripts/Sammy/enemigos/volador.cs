using System.Collections.Generic;
using System;
using UnityEngine;

public class volador : MonoBehaviour
{
    public float radiobusqueda;
    public LayerMask capaJugador;
    public Transform transformJugador;
    public float velocidadMovimiento, velocidadRabia;
    public float distanciaMaxima;
    public Vector3 puntoInicial;
    public bool mirandoDerecha;
    public EstadosMovimiento estadoActual;
    public MaskType maskRequierement;

    StateSettings currentSetting, lastSetting;
    [SerializeField] List<StateSettings> settings;
    public enum EstadosMovimiento
    {
        Esperando,

        Siguiendo,

        Volviendo,
    }
    private void Start()
    {
        puntoInicial = transform.position;
    }

    private void Update()
    {
        switch (estadoActual)
        {
            case EstadosMovimiento.Esperando:
                EstadoEsperando();
                break;
            case EstadosMovimiento.Siguiendo:
                EstadoSiguiendo();
                break;
            case EstadosMovimiento.Volviendo:
                EstadoVolviendo();
                break;

        }
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radiobusqueda, capaJugador);

        if (jugadorCollider)
        {
            transformJugador = jugadorCollider.transform;
            AlternarEstado();
        }
    }
    private void EstadoEsperando()
    {
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radiobusqueda, capaJugador);

        if (jugadorCollider)
        {
            transformJugador = jugadorCollider.transform;
            estadoActual = EstadosMovimiento.Siguiendo;
        }
    }
    private void EstadoSiguiendo()
    {
        if (transformJugador == null)
        {
            estadoActual = EstadosMovimiento.Volviendo;
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, transformJugador.position, velocidadMovimiento * Time.deltaTime);

        GirarObjetivo(transformJugador.position);

        if (Vector2.Distance(transform.position, puntoInicial) > distanciaMaxima ||
            Vector2.Distance(transform.position, transformJugador.position) > distanciaMaxima)

        {
            estadoActual = EstadosMovimiento.Volviendo;
            transformJugador = null;
        }
    }

    private void EstadoVolviendo()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntoInicial, velocidadMovimiento * Time.deltaTime);

        GirarObjetivo(puntoInicial);

        if (Vector2.Distance(transform.position, puntoInicial) < 0.1f)
        {
            estadoActual = EstadosMovimiento.Esperando;
        }
    }
    private void GirarObjetivo(Vector3 objetivo)
    {
        if (objetivo.x > transform.position.x && !mirandoDerecha)
        {
            Girar();
        }
        else if (objetivo.x < transform.position.x && mirandoDerecha)
        {
            Girar();
        }
    }
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiobusqueda);
        Gizmos.DrawWireSphere(puntoInicial, distanciaMaxima);
    }

    public void AlternarEstado()
    {
      
    }
}

[Serializable]
public class StateSettings
{
    [SerializeField] MaskType _mask;
    [SerializeField] GameObject _visual;
    [SerializeField] float _speed;
    public MaskType Mask { get => _mask; set => _mask = value; }
    public GameObject Visual { get => _visual; set => _visual = value; }
    public float Speed { get => _speed; set => _speed = value; }
}
