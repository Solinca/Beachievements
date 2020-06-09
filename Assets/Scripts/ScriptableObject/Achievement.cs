using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement")]
public class Achievement : ScriptableObject
{
    public Sprite sprite;
    public string title;
    public string description;
    public string hint;
    public bool collected = false;
    public int order = 0;
}
