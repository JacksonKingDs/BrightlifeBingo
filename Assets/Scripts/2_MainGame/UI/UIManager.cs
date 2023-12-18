namespace MainGame.VisualFeedback
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [Header("Start")]
        public Animator countDownAnimator;

        [Header("HUD")]
        public TextMeshProUGUI InfoBallsLeft;
        public TextMeshProUGUI InfoScore;

        public TextMeshProUGUI DebugUIText;
        private List<string> messages = new List<string>();

        [Header("End screen")]
        public GameObject GameOverScreenRoot;
        public TextMeshProUGUI EndScreenScore;
        public TextMeshProUGUI EndScreenBingos;

        //[Header("Abilities")]
        //public Button DaubButton;
        //public GameObject FreeDaubText;
        //public GameObject FreeDaubIndicator;


        private void Awake()
        {
            Instance = this;

            //Starting state
            ClearDaubMeter();
            //FreeDaubIndicator.SetActive(false);
            //FreeDaubText.SetActive(false);
        }

        public void StartCountDown()
        {
            countDownAnimator.Play("CountDown");
        }

        #region Daub

        public void SetDaubMeterFillAmount(float amount)
        {
            //DaubButton.image.fillAmount = amount;
            //if (amount > 0.99f)
            //{
            //    FreeDaubText.SetActive(true);
            //    DaubButton.interactable = true;
            //}
        }

        public void ClearDaubMeter()
        {
            //DaubButton.image.fillAmount = 0f;
            //DaubButton.interactable = false;
            //FreeDaubText.SetActive(false);
            //FreeDaubIndicator.SetActive(false);
        }

        public void EnterDaubMode()
        {
            //FreeDaubIndicator.SetActive(true);
        }

        public void ExitDaubMode()
        {
            //FreeDaubText.SetActive(true);
        }

        #endregion

        #region Small text display

        public void SetScore(int amount)
        {
            InfoScore.text = amount.ToString();
            EndScreenScore.text = InfoScore.text;
        }

        public void SetBallsLeft(int amount)
        {
            InfoBallsLeft.text = amount + "/ 50";
        }

        public void ShowDebugMessage(string msg)
        {
            messages.Add(msg);
            if (messages.Count > 3)
                messages.RemoveAt(0);

            string m = "";
            foreach (var i in messages)
            {
                m += msg + "\n";
            }

            DebugUIText.text = m;
        }
        #endregion

        #region GameOver
        private void GameOver()
        {
            GameOverScreenRoot.SetActive(true);
            EndScreenBingos.text = GameManager.Instance.BingoCounts.ToString();
            countDownAnimator.Play("GameOver");
        }
        #endregion
    }
}
