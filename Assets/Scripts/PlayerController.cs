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
    public AudioClip plHeal;
    public Image HpFront;
    public float hp = 100f;

    private Rigidbody2D plRb;
    private Animator plAnimator;

    private float upForce = 150f;
    private float downForce = -10f;
    private bool isDead = false;
    
    private float cnt = 0;
    private float curHp = 0;

    private float ScreenCenter;
    private bool pressdPause = false;
    private GameManager gm;
    private bool isHit = false;
    private float HitTime = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        plRb = gameObject.GetComponent<Rigidbody2D>();
        float screenWidth = Screen.width;
        ScreenCenter = screenWidth / 2;
        plAnimator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        PlayerInit();
        gm = GameManager.Instance;
        
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
                if (!pressdPause)
                {
                    PlayerUp(); //오른쪽
                    BtnUp.GetComponent<ButtonController>().ChangeButtonState(true);
                }
                else
                {

                }
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

        if (Time.time >= HitTime + 3f) isHit = false;

        plAnimator.SetBool("Hit", isHit);
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
        gameObject.GetComponent<SpriteRenderer>().color = new Color(90, 90, 90);
        gameObject.transform.position = new Vector2(-5, -4.5f);
        isDead = true;
        plAs.PlayOneShot(plDeath);
        gm.GameOver();
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
        if(!isDead && !isHit)
        {
            curHp -= 10;
            plAs.PlayOneShot(plHit);
            HpFront.GetComponent<BarController>().SetCurHP(curHp);
            isHit = true;
            HitTime = Time.time;
        }
    }

    public void PlayerHeal()
    {
        if(!isDead)
        {
            curHp += 10;
            plAs.PlayOneShot(plHeal);

            HpFront.GetComponent<BarController>().SetCurHP(curHp);
        }
    }

    public void PausedPress()
    {
        pressdPause = true;
    }

    public void PausedRelease()
    {
        pressdPause = false;
    }

    public void PlayerInit()
    {
        hp = 100f;
        curHp = hp;
        isDead = false;
    }
}
