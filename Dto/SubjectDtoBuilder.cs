namespace Student.Web.Api.Dto
{
    // Builder for SubjectDto
public class SubjectDtoBuilder : IDtoBuilder<SubjectDto>
{
    private SubjectDto _subjectDto = new SubjectDto();

    public SubjectDtoBuilder WithSubjectInfo(int id, string code, string title)
    {
        _subjectDto.Id = id;
        _subjectDto.Code = code;
        _subjectDto.Title = title;
        return this;
    }

    public SubjectDto Build()
    {
        return _subjectDto;
    }
}
}