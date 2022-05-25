using System;

public interface INicknameGetter
{
    void Show();
    string Nickname { get; }

    event Action NickGetted;
}
