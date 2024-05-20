

namespace insta_cult.Repositories;

public class CultsRepository
{
  private readonly IDbConnection _db;

  public CultsRepository(IDbConnection db)
  {
    _db = db;
  }

  private Cult PopulateLeader(Cult cult, Profile leader)
  {
    cult.Leader = leader;
    return cult;
  }

  internal List<Cult> GetAllCults()
  {
    string sql = @"
    SELECT
    cults.*,
    accounts.*
    FROM cults
    JOIN accounts ON accounts.id = cults.leaderId;";

    List<Cult> cults = _db.Query<Cult, Profile, Cult>(sql, PopulateLeader).ToList();

    return cults;
  }

  internal Cult GetCultById(int cultId)
  {
    string sql = @"
    SELECT
    cults.*,
    accounts.*
    FROM cults
    JOIN accounts ON accounts.id = cults.leaderId
    WHERE cults.id = @cultId;";
    //                                                                  {cultId: 7}
    Cult cult = _db.Query<Cult, Profile, Cult>(sql, PopulateLeader, new { cultId }).FirstOrDefault();

    return cult;
  }
}