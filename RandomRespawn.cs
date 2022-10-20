public class RandomInstantiate : MonoBehaviour
{
    [SerializeField] private Transform _path;

    public GameObject Template;
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
        for (int i = 0; i < _points.Length; i++)
        {
            GameObject newGameObject = Instantiate(Template, _points[i].position, Quaternion.identity);
        }
        yield return new WaitForSeconds(2f);
    }
}
