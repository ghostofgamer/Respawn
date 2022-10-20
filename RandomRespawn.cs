public class RandomInstantiate : MonoBehaviour
{
    [SerializeField] private Transform _path;

    public GameObject[] Template;
    private Transform[] _points;
    private float _timeRespawn = 2f;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            GameObject newGameObject = Instantiate(Template[Random.Range(0, Template.Length)], _points[Random.Range(0, _points.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(_timeRespawn);
        }
    }
}
