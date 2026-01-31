using UnityEngine;

public class balaEnemigo : MonoBehaviour
{
    public float velocidad;
    public int daño;

    private void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * Vector2.left);
    }

}
