namespace AopExemple.Aop
{
    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = true)]
    public class LogAttribute : Attribute
    {
    }
}