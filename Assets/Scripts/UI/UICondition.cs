using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition stamina;

    private void Start()
    {
        if (CharacterManager.Instance != null)
        {
            // Player 객체가 유효한지 확인
            if (CharacterManager.Instance.Player != null)
            {
                // condition 컴포넌트가 유효한지 확인
                if (CharacterManager.Instance.Player.condition != null)
                {
                    // 모든 객체가 유효할 때 안전하게 접근
                    CharacterManager.Instance.Player.condition.uiCondition = this;
                }
                else
                {
                    // Debug.LogError로 어떤 객체가 null인지 명확하게 출력
                    Debug.LogError("Player 객체에 condition 컴포넌트가 없습니다.");
                }
            }
            else
            {
                Debug.LogError("CharacterManager.Instance.Player가 null입니다.");
            }
        }
        else
        {
            Debug.LogError("CharacterManager.Instance가 null입니다. 싱글톤 패턴 초기화에 문제가 있을 수 있습니다.");
        }
    }
}