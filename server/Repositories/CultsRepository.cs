
namespace insta_cult.Repositories;

public class CultsRepository
{
  private readonly IDbConnection _db;

  public CultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Cult> GetAllCults()
  {
    string sql = @"
    SELECT
    cults.*,
    accounts.*
    FROM cults
    JOIN accounts ON accounts.id = cults.leaderId;";

    List<Cult> cults = _db.Query<Cult, Profile, Cult>(sql, (cult, profile) =>
    {
      cult.Leader = profile;
      return cult;
    }).ToList();

    return cults;
  }

}