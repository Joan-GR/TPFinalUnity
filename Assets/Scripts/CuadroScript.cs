using UnityEngine;

/// <summary>
/// Simple script: adjuntarlo al trigger en el piso (Collider con IsTrigger = true).
/// Cuando el jugador entra, aplica una fuerza tipo Impulse a un Rigidbody objetivo
/// para que salga despedido desde la pared (la dirección se calcula usando la posición de la pared).
/// Diseñado para Unity 2018; código lo más simple posible.
/// </summary>
public class CuadroScript : MonoBehaviour
{
    public Rigidbody target;
    public Transform wall;
    public float force = 8f;
    bool triggered = false;
    public bool derechaOIzquierda = true;

    void OnTriggerEnter(Collider other)
    {
        if (triggered == true)
        {
            return;
        }
        else if (derechaOIzquierda == true)
        {
            // dirección desde la pared hacia el objeto
            Vector3 dir = (target.position - wall.position).normalized;
            if (dir.sqrMagnitude < 0.0001f) dir = wall.forward;

            Vector3 finalDir = (dir + Vector3.forward).normalized;

            // aplica la fuerza como en tu snippet original
            target.AddForce(finalDir * force, ForceMode.Impulse);

            triggered = true;
        }
        else
        {
            // dirección desde la pared hacia el objeto
            Vector3 dir = (target.position - wall.position).normalized;
            if (dir.sqrMagnitude < 0.0001f) dir = wall.forward;

            Vector3 finalDir = (dir + Vector3.back).normalized;

            // aplica la fuerza como en tu snippet original
            target.AddForce(finalDir * force, ForceMode.Impulse);

            triggered = true;
        }
    }
}