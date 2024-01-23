namespace AopExemple;

public class MonTroisiemeExemple : IMUseCase<TroisiemeExempleQuery, string>
{
    public string Execute(TroisiemeExempleQuery query)
    {
        return query.Value;
    }
}

public class TroisiemeExempleQuery
{
    public string Value { get; set; }
}