namespace MainGame.VisualFeedback
{
    using UnityEngine;
    using Audio;

    public class PfxManager : MonoBehaviour
    {

        [Header("Prefabs")]
        public ParticleSystem PfxMouseClickGlow;
        public ParticleSystem pf_clickRing;
        public ParticleSystem PfxConfetti;
        public ParticleSystem pf_ringTips;

        [Header("Scene objects")]
        public Camera overlayCamera;
        public Transform overlayCanvas;


        #region MonoBehaviour
        void Start()
        {
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnMousePfx_DustPuff();
            }
        }
        #endregion

        #region MousePuff
        public void SpawnMousePfx_DustPuff() => Play(PfxMouseClickGlow);
        public void SpawnMousePfx_Confetti() => Play(PfxConfetti);
        public void SpawnTopBotConfetti_atPosition() => Play(PfxMouseClickGlow);

        private void Play(ParticleSystem ps, float zPosition = 0f)
        {
            Vector3 pos = overlayCamera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = zPosition;
            ps.transform.position = pos;
            ps.Play();
        }
        #endregion
    }
}