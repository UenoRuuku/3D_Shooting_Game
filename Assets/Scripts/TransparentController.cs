using UnityEngine;

public class TransparentController : MonoBehaviour
{
    // 半透明材质(Material)
    public Material transparentMaterial;
    // 碰撞检测范围
    public float checkRange = 5f;
    // 要检测的tag
    public string checkTag = "Player";

    private Material originalMaterial;

    private void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        bool isVisible = false;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRange);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(checkTag))
            {
                isVisible = true;
                break;
            }
        }

        if (isVisible)
        {
            GetComponent<Renderer>().material = transparentMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, checkRange);
    }
}
