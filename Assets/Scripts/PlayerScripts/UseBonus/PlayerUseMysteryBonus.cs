using UnityEngine;

public class PlayerUseMysteryBonus : MonoBehaviour
{
    public int increaseJumpForce;
    public int decreaseJumpForce;

    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private int increaseJumpCount;
    [SerializeField] private int decreaseJumpCount;

    private int _count;
    private int _limitScore;
    private int _intervalScore;


    private void Start()
    {
        player = PlayerBehaviour.Instance;
    }

    public void UseMysteryBonus(bool isBonus)
    {
        player.UseJumpBonus = true;
        if (isBonus)
        {
            player.jumpForce += increaseJumpForce;
            player.JumpUpBonus = true;
        }
        else
        {
            player.jumpForce -= decreaseJumpForce;
            player.JumpDownBonus = true;
        }
    }

    public void IsBonusUsed()
    {
        if (player.UseJumpBonus)
        {
            _count++;
            if (player.JumpUpBonus && _count >= increaseJumpCount)
                ReturnInitialJumpForce();
            else if (player.JumpDownBonus && _count >= decreaseJumpCount)
                ReturnInitialJumpForce();
        }
    }

    private void ReturnInitialJumpForce()
    {
        player.EnableUseBonus();
        _count = 0;
        player.jumpForce = player.startJumpForce;
        if (player.startJumpForce != 19)//пока так 
        {
            player.startJumpForce = 19;
        }
        player.UseJumpBonus = false;
        player.JumpDownBonus = false;
        player.JumpUpBonus = false;
    }
}