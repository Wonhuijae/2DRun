using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpBtn : MonoBehaviour
{
    public Button BtnUp;
    public Button BtnDown;
    public AudioSource plAs;
    public AudioClip plDeath;
    public AudioClip plHit;
    public Image HpFront;
    public float hp = 100f;

    private Rigidbody2D plRb;
    private Animator plAnimator;

    private float upForce = 10f;
    private float downForce = -2f;
    private bool isDead = false;
    
    private float cnt = 0;
    private float curHp = 0;

    private float ScreenCenter;

    // Start is called before the first frame update
    void Awake()
    {
        plRb = gameObject.GetComponent<Rigidbody2D>();
        float screenWidth = Screen.width;
        ScreenCenter = screenWidth / 2;

        curHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 inputPosition = Input.mousePosition;

            if (inputPosition.x < ScreenCenter) //왼쪽
            {
                PlayerDown();
                BtnDown.GetComponent<ButtonController>().ChangeButtonState(true);
            }
            else
            {
                PlayerUp(); //오른쪽
                BtnUp.GetComponent<ButtonController>().ChangeButtonState(true);
            }
        }
        else
        {
            BtnUp.GetComponent <ButtonController>().ChangeButtonState(false);
            BtnDown.GetComponent<ButtonController>().ChangeButtonState(false);
        }

        cnt += Time.deltaTime;

        if(cnt >= 1)
        {
            cnt = 0;
            curHp--;
            HpFront.GetComponent<BarController>().SetCurHP(curHp);
        }
    }

    public void PlayerUp()
    {
        plRb.velocity = Vector2.zero;
        plRb.AddForce(new Vector2(0, upForce));
    }

    public void PlayerDown()
    {
        plRb.AddForce(new Vector2(0, downForce));
    }

    void Die()
    {
        Debug.Log("Die");
        isDead = true;
        plAs.PlayOneShot(plDeath);
    }

    public float GetHP()
    {
        return hp;
    }

    public float GetCurHP()
    {
        return curHp;
    }

    public void Flooding()
    {
        Die();
    }

    public void PlayerHit()
    {
        if(!isDead)
        {
            curHp -= 10;
            plAs.PlayOneShot(plHit);
            HpFront.GetComponent<BarController>().SetCurHP(curHp);
        }
    }
}
