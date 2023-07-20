namespace ElegantCode.Fundamental.Core
{
    public interface IValidateRequest<TUseCaseQuery>
    {
        public (TUseCaseQuery UseCaseQuery, Error Error) ValidateRequest();
    }
}
