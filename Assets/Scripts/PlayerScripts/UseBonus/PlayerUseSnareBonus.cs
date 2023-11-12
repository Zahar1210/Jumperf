using UnityEngine;

public class PlayerUseSnareBonus : MonoBehaviour
{
    [SerializeField] private CheckBonuses checkBonuses;
    [SerializeField] private CheckPlatform checkPlatform;

    public void Contusion()
    {
        checkPlatform.enabled = false;
        checkBonuses.enabled = false;
    }
}
