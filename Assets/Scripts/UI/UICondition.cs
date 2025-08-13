using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition stamina;

    private void Start()
    {
        if (CharacterManager.Instance != null)
        {
            // Player ��ü�� ��ȿ���� Ȯ��
            if (CharacterManager.Instance.Player != null)
            {
                // condition ������Ʈ�� ��ȿ���� Ȯ��
                if (CharacterManager.Instance.Player.condition != null)
                {
                    // ��� ��ü�� ��ȿ�� �� �����ϰ� ����
                    CharacterManager.Instance.Player.condition.uiCondition = this;
                }
                else
                {
                    // Debug.LogError�� � ��ü�� null���� ��Ȯ�ϰ� ���
                    Debug.LogError("Player ��ü�� condition ������Ʈ�� �����ϴ�.");
                }
            }
            else
            {
                Debug.LogError("CharacterManager.Instance.Player�� null�Դϴ�.");
            }
        }
        else
        {
            Debug.LogError("CharacterManager.Instance�� null�Դϴ�. �̱��� ���� �ʱ�ȭ�� ������ ���� �� �ֽ��ϴ�.");
        }
    }
}