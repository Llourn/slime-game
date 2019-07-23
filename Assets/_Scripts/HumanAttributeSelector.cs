using UnityEngine;
using UnityEngine.AI;

public class HumanAttributeSelector : MonoBehaviour
{
    [SerializeField] private HumanAttributes[] attributes = null;
    [SerializeField] private Renderer headRenderer = null;
    [SerializeField] private Renderer shirtRenderer = null;

    private HumanAttributes selectedAttributes;
    private NavMeshAgent agent;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        int r = Random.Range(0, attributes.Length);
        selectedAttributes = attributes[r];

        headRenderer.material = selectedAttributes.headColorMat;
        shirtRenderer.material = selectedAttributes.shirtColorMat;

        agent.speed = agent.speed * selectedAttributes.moveSpeedMultiplier;

        float y = transform.localScale.y * selectedAttributes.heightMultiplier;
        float x = transform.localScale.x * selectedAttributes.widthMultiplier;
        float z = transform.localScale.z * selectedAttributes.widthMultiplier;

        transform.localScale = new Vector3(x, y, z);
    }


}
