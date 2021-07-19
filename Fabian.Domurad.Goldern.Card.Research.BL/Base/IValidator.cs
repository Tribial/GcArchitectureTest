namespace Fabian.Domurad.Golden.Card.Research.BL.Base
{
    public interface IValidator<in TParam>
    {
        void Validate(TParam param);
    }
}
