using System.Collections;
using UnityEngine;

public class WindowGetNickname : MonoBehaviour, INicknameGetter
{
    [SerializeField] private TMPro.TMP_InputField _inputField;

    public IEnumerator ShowMessage()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitWhile(() => enabled);
    }

    public string GetNickname()
    {
        return _inputField.text;
    }

    public void Confirm()
    {
        string nickname = _inputField.text;

        if (nickname == string.Empty
            || nickname.Length > Constants.NicknameMaxLength)
        {
            return;
        }

        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
