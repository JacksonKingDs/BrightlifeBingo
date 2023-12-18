namespace MainGame
{
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;

    public class Card : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Animator animator;
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private Image starImage;
        [SerializeField] private Button button;
        [SerializeField] private CardLetters letter;

        private Board board;
        private GameManager gm;

        private int x;
        private int y;
        private int number;

        private bool marked;

        public bool Marked => marked;
        
        public CardLetters Letter => letter;
        public int X => x;
        public int Y => y;

        //Setter
        #endregion

        public void Init(Board board, int x, int y, int number)
        {
            this.board = board;
            this.x = x;
            this.y = y;
            this.number = number;

            textMesh.text = number.ToString();

            gm = GameManager.Instance;

            //TODO: play animation
        }

        public void MarkCard(bool value = true)
        {
            marked = value;
            animator.Play("Mark");
        }

        public void Clicked()
        {
            //if (!GameManager.Instance.InPlayingMode)
            //    return;

            board.ClickedOnCard(this);
        }
    }
}