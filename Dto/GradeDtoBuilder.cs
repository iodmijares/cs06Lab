namespace Student.Web.Api.Dto.Builders
{
    // Builder for GradeDto
public class GradeDtoBuilder : IDtoBuilder<GradeDto>
{
    private GradeDto _gradeDto = new GradeDto();

    public GradeDtoBuilder WithGradeInfo(string pupilId, int subjectId, string midTerm, string finalTerm, string finalGrade, string remarks)
    {
        _gradeDto.PupilId = pupilId;
        _gradeDto.SubjectId = subjectId;
        _gradeDto.MidTerm = midTerm;
        _gradeDto.FinalTerm = finalTerm;
        _gradeDto.FinalGrade = finalGrade;
        _gradeDto.Remarks = remarks;
        return this;
    }

    public GradeDto Build()
    {
        return _gradeDto;
    }
}
}