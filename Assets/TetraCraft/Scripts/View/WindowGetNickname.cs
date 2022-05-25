using System;
using UnityEngine;

public class WindowGetNickname : MonoBehaviour, INicknameGetter
{
    [SerializeField] private TMPro.TMP_InputField _inputField;

    private string _nickname;

    public string Nickname 
    { 
        get => _nickname
            ?? throw new Exception("Nick is not Getted yet"); 
        private set => _nickname = value; 
    }

    public event Action NickGetted;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Confirm()
    {
        string nickname = _inputField.text;

        if (nickname == string.Empty
            || nickname.Length > Constants.NicknameMaxLength)
        {
            return;
        }

        _nickname = nickname;

        gameObject.SetActive(false);
        NickGetted?.Invoke();
    }
}
