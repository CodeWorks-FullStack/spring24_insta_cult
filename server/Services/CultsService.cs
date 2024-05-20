
namespace insta_cult.Services;

public class CultsService
{
  private readonly CultsRepository _repository;

  public CultsService(CultsRepository repository)
  {
    _repository = repository;
  }

  internal List<Cult> GetAllCults()
  {
    List<Cult> cults = _repository.GetAllCults();
    return cults;
  }
}