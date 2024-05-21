


namespace insta_cult.Services;

public class CultMembersService
{
  private readonly CultMembersRepository _repository;

  public CultMembersService(CultMembersRepository repository)
  {
    _repository = repository;
  }

  internal Profile CreateCultMember(CultMember cultMemberData)
  {
    Profile cultist = _repository.CreateCultMember(cultMemberData);
    return cultist;
  }
}