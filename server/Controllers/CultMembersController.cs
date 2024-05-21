namespace insta_cult.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CultMembersController : ControllerBase
{
  private readonly CultMembersService _cultMembersService;
  private readonly Auth0Provider _auth0Provider;

  public CultMembersController(CultMembersService cultMembersService, Auth0Provider auth0Provider)
  {
    _cultMembersService = cultMembersService;
    _auth0Provider = auth0Provider;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Profile>> CreateCultMember([FromBody] CultMember cultMemberData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      cultMemberData.AccountId = userInfo.Id;
      Profile cultist = _cultMembersService.CreateCultMember(cultMemberData);
      return Ok(cultist);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}