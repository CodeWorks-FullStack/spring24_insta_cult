

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

  internal Cult GetCultById(int cultId)
  {
    Cult cult = _repository.GetCultById(cultId);

    if (cult == null)
    {
      throw new Exception($"Invalid cult id: {cultId}");
    }

    return cult;
  }
}