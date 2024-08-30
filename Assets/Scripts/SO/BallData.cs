using UnityEngine;

[CreateAssetMenu(fileName = "New BallData", menuName = "Assets/BB/Create BallData")]
public class BallData : ScriptableObject
{
    public Sprite SpriteRender;
    public Vector2 bounceForce = new Vector2(245, 245);
    public float maxSpeed;
    public int minHealth;
    public int maxHealth;
}
