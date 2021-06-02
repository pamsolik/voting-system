using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using VotingSystemApi.Contracts.VotingSystem.ContractDefinition;
using VotingSystemApi.Models;
using VotingSystemApi.Models.DTOs;
using VotingSystemApi.Models.Views;
using VotingSystemApi.Services;

namespace VotingSystemApi.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AdminController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthDto authDto)
        {
            try
            {
                var session = new NethereumSession(authDto);
                var svc = session.UtilizeSession();
                var isAdmin = await svc.IsAdminQueryAsync();

                if (isAdmin)
                {
                    HttpContext.Session.Set(session.Token, _authService.ConvertSession(session));
                    return Ok(new TokenView("Logged in.", session.Token));
                }
                return Unauthorized(new MessageView("Incorect login/password/no administrator privileges."));
            }
            catch (Exception ex)
            {
                return Unauthorized(new MessageView(ex.Message));
            }
        }

        [HttpGet("get_elections")]
        public async Task<IActionResult> GetElections([FromHeader] string authToken)
        {
            try
            {
                if (!_authService.ValidateCurrentToken(authToken)) return BadRequest(new MessageView("Token not Valid"));
                var svc = _authService.GetSession(HttpContext.Session.Get(authToken));

                var elections = await svc.GetElectionsQueryAsync();
                return Ok(new ElectionsView(elections));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new MessageView(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        [HttpGet("get_election_details")]
        public async Task<IActionResult> GetElection(string id, [FromHeader] string authToken)
        {
            try
            {
                if (!_authService.ValidateCurrentToken(authToken)) return BadRequest(new MessageView("Token not Valid"));
                var svc = _authService.GetSession(HttpContext.Session.Get(authToken));

                BigInteger a = BigInteger.Parse(id);
                var election = await svc.GetDetailsQueryAsync(a);
                return Ok(new ElectionDetailsView(election));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new MessageView(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        [HttpPost("create_election")]
        public async Task<IActionResult> CreateElection([FromBody] CreateElectionDto createElectionDto, [FromHeader] string authToken)
        {
            try
            {
                if (!_authService.ValidateCurrentToken(authToken)) return BadRequest(new MessageView("Token not Valid"));
                //if (createElectionDto.DateFrom < DateTime.Now) 
                //return BadRequest(new MessageView("DateFrom has to be a future date."));
                //if (createElectionDto.DateFrom >= createElectionDto.DateTo) 
                //return BadRequest(new MessageView("DateFrom has earlier than DateTo."));
                if (createElectionDto.Candidates.Count < 2) 
                    return BadRequest(new MessageView("There has to be more than one candidate."));
                if (createElectionDto.KeysPerVoter < 0) 
                    return BadRequest(new MessageView("KeysPerVoter has to be greater than 0."));
                if (createElectionDto.Title.Length < 3) 
                    return BadRequest(new MessageView("Title has to be at least 3 characters long."));
                if (createElectionDto.Candidates.Any(can => can.Length < 3)) 
                    return BadRequest(new MessageView("All candidate/party names have to be at least 3 characters long."));
                if (createElectionDto.Candidates.Distinct().Count() < createElectionDto.Candidates.Count) 
                    return BadRequest(new MessageView("All candidate/party names have to be distinct."));
                
                var svc = _authService.GetSession(HttpContext.Session.Get(authToken));
                var result = await svc.AddElectionRequestAsync(createElectionDto.Title,
                                                                (ulong)createElectionDto.DateFrom.Ticks,
                                                                (ulong)createElectionDto.DateTo.Ticks,
                                                                createElectionDto.KeysPerVoter,
                                                                createElectionDto.Candidates);
                return Ok(new MessageView("Created"));
               
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new MessageView(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        [HttpPost("generate_codes")]
        public async Task<IActionResult> GenerateCodes([FromBody] GenerateCodesDto generateCodesDto, [FromHeader] string authToken)
        {
            try
            {
                if (!_authService.ValidateCurrentToken(authToken)) return BadRequest(new MessageView("Token not Valid"));
                var svc = _authService.GetSession(HttpContext.Session.Get(authToken));

                var resp = await svc.AddAddUserToElectionRequestAndWaitForReceiptAsync(BigInteger.Parse(generateCodesDto.ElectionId),
                                                                                    generateCodesDto.VoterAdress,
                                                                                    generateCodesDto.Voter);

                var transferEventOutput = resp.DecodeAllEvents<UserAddedToElectionEventDTOBase>();
                return Ok(transferEventOutput.FirstOrDefault().Event);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new MessageView(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        [HttpPost("add_admin_batch")]
        public async Task<IActionResult> AddAdminBatch([FromBody] AddAdminBatchDto addAdminBatchDto)
        {
            try
            {
                var svc = NethereumProvider.GetVotingSystemService(addAdminBatchDto.Auth.AccountAddress, addAdminBatchDto.Auth.Password);

                var resp = await svc.AddAdminBatchRequestAndWaitForReceiptAsync(addAdminBatchDto.Admins);

                return Ok(new MessageView("Administrators added"));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        [HttpPost("add_admin")]
        public async Task<IActionResult> AddAdmin([FromBody] AddAdminDto addAdminDto, [FromHeader] string authToken)
        {
            try
            {
                if (!_authService.ValidateCurrentToken(authToken)) return BadRequest(new MessageView("Token not Valid"));
                var svc = _authService.GetSession(HttpContext.Session.Get(authToken));

                var resp = await svc.AddAdminRequestAndWaitForReceiptAsync(addAdminDto.Admin);

                return Ok(new MessageView("Administrator added"));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new MessageView(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        [HttpPost("remove_admin")]
        public async Task<IActionResult> RemoveAdmin([FromBody] AddAdminDto addAdminDto, [FromHeader] string authToken)
        {
            try
            {
                if (!_authService.ValidateCurrentToken(authToken)) return BadRequest(new MessageView("Token not Valid"));
                var svc = _authService.GetSession(HttpContext.Session.Get(authToken));

                var resp = await svc.RemoveAdminRequestAndWaitForReceiptAsync(addAdminDto.Admin);

                return Ok(new MessageView("Administrator removed"));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new MessageView(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }
    }
}