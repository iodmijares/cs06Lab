namespace Student.Web.Api.Dto
{
    public interface IDtoBuilder<TDto>
    {
        TDto Build();
    }
}