using UnityEngine;

public class SoundPitcher : MonoBehaviour
{
    [SerializeField] private AudioSource _updateSound;
    [SerializeField] private float _step;
    [SerializeField] private float _delay;
    [SerializeField] private float _comboTime;
    [SerializeField] private float _maxPitch;

    private float _initialPitch;
    private float _elapsedTime;

    public void Play()
    {
        if (_updateSound.pitch < _maxPitch
            && _updateSound.isPlaying == false)
        {
            _updateSound.pitch += _step;
        }
        _updateSound.PlayDelayed(_delay);
    }

    private void Start()
    {
        _initialPitch = _updateSound.pitch;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_updateSound.pitch > _initialPitch
            && _elapsedTime >= _comboTime)
        {
            _elapsedTime = 0;
            _updateSound.pitch -= _step;
        }
    }
}
