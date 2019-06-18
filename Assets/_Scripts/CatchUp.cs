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

    
    public Vector3 moveStretch;
    public float stretchingThreshold;
    public float stretchSpeed = 1.0f;



    private void Update()
    {

        Vector3 velocity = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0.0f, CrossPlatformInputManager.GetAxis("Vertical")) * moveSpeed;
        innerSlimeRB.AddForce(velocity, ForceMode.Force);



        float slimeDistance = Vector3.Distance(innerSlime.position, outerSlime.position);
        if (slimeDistance > distanceThreshold)
        {
            float catchUpSpeed = minCatchUpSpeed * ((slimeDistance - distanceThreshold) / 0.1f);
            catchUpSpeed = (catchUpSpeed > minCatchUpSpeed) ? catchUpSpeed : minCatchUpSpeed;
            outerSlime.position = Vector3.Lerp(outerSlime.position, innerSlime.position, Time.deltaTime * catchUpSpeed);
        }

        //if (Vector3.Distance(innerSlime.position, outerSlime.position) > stretchingThreshold)
        //{
        //    outerSlime.localScale = Vector3.Lerp(outerSlime.localScale, moveStretch, Time.deltaTime * stretchSpeed);
        //}
        //else
        //{
        //    outerSlime.localScale = Vector3.Lerp(outerSlime.localScale, Vector3.one, Time.deltaTime * stretchSpeed);
        //}

        //outerSlime.LookAt(innerSlime);
    }

    
}
