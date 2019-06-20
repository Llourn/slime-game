using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class CatchUp : MonoBehaviour
{
    public Rigidbody innerSlimeRB;
    public float moveSpeed = 1.0f;

    public Transform innerSlime;
    public Transform outerSlime;
    public float distanceThreshold;
    public float minCatchUpSpeed = 1.0f;

    public float jumpForce = 10.0f;

    private void Update()
    {

        Vector3 velocity = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0.0f, CrossPlatformInputManager.GetAxis("Vertical")) * moveSpeed;
        innerSlimeRB.AddForce(velocity, ForceMode.Force);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            innerSlimeRB.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
        }


        float slimeDistance = Vector3.Distance(innerSlime.position, outerSlime.position);
        if (slimeDistance > distanceThreshold)
        {
            float catchUpSpeed = minCatchUpSpeed * ((slimeDistance - distanceThreshold) / 0.1f);
            catchUpSpeed = (catchUpSpeed > minCatchUpSpeed) ? catchUpSpeed : minCatchUpSpeed;
            outerSlime.position = Vector3.Lerp(outerSlime.position, innerSlime.position, Time.deltaTime * catchUpSpeed);
        }
    }

    
}
