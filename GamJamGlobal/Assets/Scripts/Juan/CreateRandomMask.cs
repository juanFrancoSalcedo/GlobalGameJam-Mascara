using UnityEngine;

public class CreateRandomMask : MonoBehaviour
{
    [SerializeField] MaskItem[] masks;
    void Start()
    {
        Instantiate(masks[Random.Range(0,masks.Length)],transform.position, Quaternion.identity);
    }
}
