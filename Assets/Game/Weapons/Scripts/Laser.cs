using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;

    [SerializeField] private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);

        _lineRenderer.SetPosition(1, _player.transform.forward * 1000);
    }
}
