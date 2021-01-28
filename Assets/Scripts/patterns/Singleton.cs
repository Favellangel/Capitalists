public class Singleton<T> where T : new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
    }

    public void Destroy()
    {
        instance = default; // правильно ли делать так
    }
}
