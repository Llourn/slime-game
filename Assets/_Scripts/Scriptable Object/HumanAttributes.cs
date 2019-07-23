using UnityEngine;

[CreateAssetMenu(fileName = "Human", menuName = "Scriptable Objects/Human Attributes")]
public class HumanAttributes : ScriptableObject
{
    public Material headColorMat;
    public Material shirtColorMat;

    [Range(1.0f, 2.0f)]
    public float heightMultiplier = 1.0f;
    [Range(1.0f, 2.0f)]
    public float widthMultiplier = 1.0f;
    [Range(1.0f, 5.0f)]
    public float moveSpeedMultiplier = 1.0f;
}
