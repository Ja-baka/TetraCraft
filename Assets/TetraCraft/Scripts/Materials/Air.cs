public class Air : BlockMaterial
{
    private static Air _instance;

    public static Air Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Air();
            }
            return _instance;
        }
    }

    public override void HandlePhysics()
    {
    }
}
