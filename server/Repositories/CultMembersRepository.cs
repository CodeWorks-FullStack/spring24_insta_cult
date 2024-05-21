



namespace insta_cult.Repositories;

public class CultMembersRepository
{
  private readonly IDbConnection _db;

  public CultMembersRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Cultist CreateCultMember(CultMember cultMemberData)
  {
    string sql = @"
    INSERT INTO
    cultMembers(cultId, accountId)
    VALUES(@CultId, @AccountId);

    SELECT 
    cultMembers.*,
    accounts.*
    FROM cultMembers
    JOIN accounts ON accounts.id = cultMembers.accountId 
    WHERE cultMembers.id = LAST_INSERT_ID();";

    Cultist cultist = _db.Query<CultMember, Cultist, Cultist>(sql, (cultMember, profile) =>
    {
      profile.CultMemberId = cultMember.Id;
      profile.CultId = cultMember.CultId;
      return profile;
    }, cultMemberData).FirstOrDefault();
    return cultist;
  }
}