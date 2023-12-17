namespace MainGame.CallingBall
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;


    public class CallingBall : MonoBehaviour
    {
        //public Image image;
        //public TextMeshProUGUI numberText;
        //public TextMeshProUGUI letterText;
        //public Animator animator;

        //RectTransform rect;
        //bool moving;
        //Vector2 nextPos;
        //float t;

        ////Phase 0: expand,  shrink, shrink, shrink, close
        //int phase;

        //public void Set(int number)
        //{
        //    rect = GetComponent<RectTransform>();
        //    this.numberText.text = number.ToString();
        //    this.letterText.text = GameUtil.GetLetter(number);
        //    image.sprite = RefManager.Instance.GetSprite(number);
        //}

        //public void Shuffle()
        //{
        //    if (phase == 0)
        //        PlayEntryAnimation();
        //    else
        //    {
        //        if (phase == 1)
        //            PlayShrinkAnimation();

        //        //Shuffle
        //        moving = true;
        //        t = 0;
        //        nextPos = Caller.Instance.GetCardShufflePosition(phase);
        //    }

        //    phase++;
        //}

        //public void PlayClearAnimation() => StartCoroutine(DoClear());

        //void Update()
        //{
        //    if (moving && t < 1)
        //    {
        //        rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, nextPos, t);
        //        t += 0.5f * Time.deltaTime;

        //        if (t > 1)
        //        {
        //            rect.anchoredPosition = nextPos;
        //            moving = false;
        //        }
        //    }
        //}

        //#region Minor methods
        //IEnumerator DoClear()
        //{
        //    animator.Play("Clear");
        //    yield return new WaitForSeconds(0.2f);
        //    Destroy(gameObject);
        //}

        //void PlayEntryAnimation() => animator.Play("Entry");

        //void PlayShrinkAnimation() => animator.Play("Shrink");

        //#endregion
    }

}