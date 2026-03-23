using UnityEngine;

public class SlowEnemy :  BaseEnemy
{
    private void Awake()
    {
        gravityScale = 0.5f;
    }
}
