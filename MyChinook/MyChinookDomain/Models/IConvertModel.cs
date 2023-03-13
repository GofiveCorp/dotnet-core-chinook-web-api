namespace MyChinook.Models
{
    public interface IConvertModel<TSource, TTarget>
    {
        TTarget Convert();
    }
}
