using UnityEngine;

namespace FiveRabbitsDemo
{
    public class AnimatorParamatersChange : MonoBehaviour
    {
        private Animator m_animator;

        private readonly string[] m_buttonNames = { "Idle", "Run", "Dead" };

        // Use this for initialization
        private void Start()
        {
            m_animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnGUI()
        {
            GUI.BeginGroup(new Rect(0, 0, 150, 1000));

            for (var i = 0; i < m_buttonNames.Length; i++)
                if (GUILayout.Button(m_buttonNames[i], GUILayout.Width(150)))
                {
                    m_animator.SetInteger("AnimIndex", i);
                    m_animator.SetTrigger("Next");
                }

            GUI.EndGroup();
        }
    }
}