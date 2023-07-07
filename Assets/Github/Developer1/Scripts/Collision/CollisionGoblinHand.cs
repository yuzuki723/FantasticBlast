using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGoblinHand : MonoBehaviour
{
    public GoblinAttack m_goblinAttack;
    public GoblinSliderHPBer m_goblinSliderHPBer;

    [SerializeField]
    [Tooltip("“–‚½‚è”»’è‚ğ“ü‚ê‚é")]
    private SphereCollider m_sphereCollider;

    // Start is called before the first frame update
    private void Start()
    {
        //‰Šú‰»‚Éfalse‚É‚·‚é‚Æ‚È‚º‚©“–‚½‚è”»’è‚ª
        //‹N‚«‚È‚¢‚Ì‚Å‚Ğ‚Æ‚Ü‚¸true‚É‚·‚é(Œ»İ‚»‚±‚Ü‚Å‰e‹¿‚È‚µ)
        m_sphereCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            if (m_goblinAttack.HandColliderFlgProperty)
            {
                Debug.Log(m_goblinAttack.HandColliderFlgProperty);
                m_sphereCollider.enabled = true; //(‚±‚ñ–_•”•ª‚Ì)“–‚½‚è”»’è‚ğ—LŒø
                //Invoke("ColliderReset", 0.5f); //0.5•bŒã‚Éw’è‚µ‚½ŠÖ”‚ğŒÄ‚Ño‚·
                m_goblinAttack.HandColliderFlgProperty = false;
            }
        }
    }

    private void Update()
    {
        if(m_goblinSliderHPBer.GoblinCurrentHPProperty <= 0) //ƒSƒuƒŠƒ“‚ÌHP‚ª–³‚¢ê‡
        {
            m_sphereCollider.enabled = false; //“–‚½‚è”»’è‚ğ‰ğœ‚·‚é
        }
    }

    //private void ColliderReset()
    //{
    //    m_sphereCollider.enabled = false; //(‚±‚ñ–_•”•ª‚Ì)“–‚½‚è”»’è‚ğ–³Œø
    //    Debug.Log("‚±‚ñ–_‚Ì“–‚½‚è”»’è‚ğ‰ğœ‚µ‚Ü‚µ‚½");
    //}
}