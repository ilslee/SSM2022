using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ssm.game.appearance
{
    public class StatusIcon : MonoBehaviour
    {

        public Image icon;
        public GameTerms.TokenType type;
        public int number;
        public TMP_Text numberText;

        private Animator anim;

        public bool isTrigged;

        public StatusIcon(GameTerms.TokenType t, int v, bool trig = false)
        {
            type = t;
            number = v;
            isTrigged = trig;

        }
        public void OnEnable()
        {
            anim = gameObject.GetComponent<Animator>();
            // Debug.Log("StatusIcon.Start : Check Anim -" + anim);
        }

        public void InitIcon(GameTerms.TokenType t, Sprite s, int i)
        {
            type = t;
            icon.sprite = s;
            UpdateNumber(i);
            if (i < 0) numberText.enabled = false;
        }

        public void Create()
        {
            anim.SetTrigger("Create");
        }
        public void Countdown(int i)
        {
            UpdateNumber(i);
            anim.SetTrigger("NumberUpdate");
        }
        public void Activate(int i )
        {
            UpdateNumber(i);
            anim.SetTrigger("Activate");
        }
        public void Remove()
        {
            Destroy(this);
        }
        private void UpdateNumber(int i)
        {
            number = i;
            numberText.text = i.ToString();
        }

    }
    
    public class StatusIconCompare : IEqualityComparer<StatusIcon>
    {
        public bool Equals(StatusIcon x, StatusIcon y)
        {
            return x.type == y.type;
        }

        public int GetHashCode(StatusIcon obj)
        {
            return obj.type.GetHashCode();
        }
    }
}