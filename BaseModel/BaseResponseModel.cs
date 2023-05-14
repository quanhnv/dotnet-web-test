public class BaseResponseModel<T>
{
    public int Total {get;set;}
    public IEnumerable<T> Data {get;set;}
}