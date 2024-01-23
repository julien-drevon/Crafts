using AopExemple.Aop;

namespace AopExemple;


public class MonDeuxiemeExemple : IMUseCase<DeuxiemeExempleQuery, string>
{

   [Log]
    public string Execute(DeuxiemeExempleQuery query)
    {
        return query.Value;
    }
}


public class DeuxiemeExempleQuery
{
    public string Value { get; set; }
}