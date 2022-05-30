using UnityEngine;

public class Constants
{
    // 10 x 20 - клясічны памер гульнявога поля Tetris
    // +4 радкі зьверху, каб фігуры маглі паварочвацца
    // ў верхняй кропцы
    public const int FieldWidth = 10;
    public const int FieldHeigth = 24;

    public readonly static Vector2Int spawnAreaStart = new Vector2Int(3, 17);
    public readonly static Vector2Int spawnAreaEnd = new Vector2Int(6, 19);

    public const int NicknameMaxLength = 12;

    public class SceneNames
    {
        public const string GameField = nameof(GameField);
        public const string Settings = nameof(Settings);
        public const string MainMenu = nameof(MainMenu);
        public const string LeaderBoard = nameof(LeaderBoard);
    }
}
