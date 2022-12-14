public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private GameObject[] _template;

    private Transform[] _points;

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
        var WaitForSeconds = new WaitForSeconds(2f);

        for (int i = 0; i < _points.Length; i++)
        {
            GameObject newGameObject = Instantiate(_template[Random.Range(0, _template.Length)], _points[Random.Range(0, _points.Length)].position, Quaternion.identity);
            yield return WaitForSeconds;
        }
    }
}
