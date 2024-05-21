



namespace insta_cult.Repositories;

public class CultMembersRepository
{
  private readonly IDbConnection _db;

  public CultMembersRepository(IDbConnection db)
  {
    _db = db;
  }

  internal CultMember CreateCultMember(CultMember cultMemberData)
  {
    string sql = @"
    INSERT INTO
    cultMembers(cultId, accountId)
    VALUES(@CultId, @AccountId);

    SELECT * FROM cultMembers WHERE id = LAST_INSERT_ID();";

    CultMember cultMember = _db.Query<CultMember>(sql, cultMemberData).FirstOrDefault();
    return cultMember;
  }
}