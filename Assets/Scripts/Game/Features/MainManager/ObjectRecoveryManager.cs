using UnityEngine;

public class ObjectRecoveryManager : MonoBehaviour
{
    [SerializeField] private PlatformReturnToPool platformReturn;
    [SerializeField] private float timeToCheck;

    private float _time;
    private Vector3 _platformPos;

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= timeToCheck)
        {
            Recovery();
            _time = 0f;
        }
    }

    private void Recovery()
    {
        GetPlatformDestroyerPosition();
        PlatformAbstract[] platforms = FindObjectsOfType<PlatformAbstract>();
        BonusAbstract[] bonuses = FindObjectsOfType<BonusAbstract>();
        foreach (PlatformAbstract platform in platforms)
        {
            if (platform != null && platform.transform.position.y < _platformPos.y)
                platform.EnablePlatform(false);
        }
        foreach (BonusAbstract bonus in bonuses)
        {
            if (bonus != null && bonus.transform.position.y < _platformPos.y)
                bonus.EnableBonus(false, null);
        }
    }

    private void GetPlatformDestroyerPosition()
    {
        _platformPos.y = platformReturn.gameObject.transform.position.y;
    }
}