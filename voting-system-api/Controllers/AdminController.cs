using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using VotingSystemApi.Contracts.VotingSystem.ContractDefinition;
using VotingSystemApi.Models.DTOs;
using VotingSystemApi.Models.Views;
using VotingSystemApi.Services;

namespace VotingSystemApi.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        //private readonly IAuthService _authService;
        //public AdminController(IAuthService authService) {
        //    _authService = authService;
        //}

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthDto authDto)
        {
            return Ok("Not implemented yet");
            //var token = _authService.Authenticate(authDto);
            //return Ok(token);
        }

        [HttpPost("get_elections")]
        public async Task<IActionResult> GetElections([FromBody] AuthDto authDto)
        {
            try
            {
                var svc = NethereumProvider.GetVotingSystemService(authDto.AccountAddress, authDto.Password);

                var elections = await svc.GetElectionsQueryAsync();
                return Ok(new ElectionsView(elections));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        [HttpPost("get_election_details")]
        public async Task<IActionResult> GetElection(string id, [FromBody] AuthDto authDto)
        {
            try
            {
                var svc = NethereumProvider.GetVotingSystemService(authDto.AccountAddress, authDto.Password);
                BigInteger a = BigInteger.Parse(id);
                var election = await svc.GetDetailsQueryAsync(a);
                return Ok(new ElectionDetailsView(election));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        [HttpPost("create_election")]
        public async Task<IActionResult> CreateElection([FromBody] CreateElectionDto createElectionDto)
        {
            try
            {
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
                
                var svc = NethereumProvider.GetVotingSystemService(createElectionDto.Auth.AccountAddress, createElectionDto.Auth.Password);

                var result = await svc.AddElectionRequestAsync(createElectionDto.Title,
                                                               (ulong)createElectionDto.DateFrom.Ticks,
                                                               (ulong)createElectionDto.DateTo.Ticks,
                                                               createElectionDto.KeysPerVoter,
                                                               createElectionDto.Candidates);
                return Ok(new MessageView("Created"));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        [HttpPost("generate_codes")]
        public async Task<IActionResult> GenerateCodes([FromBody] GenerateCodesDto generateCodesDto)
        {
            try
            {
                var svc = NethereumProvider.GetVotingSystemService(generateCodesDto.Auth.AccountAddress, generateCodesDto.Auth.Password);

                var resp = await svc.AddAddUserToElectionRequestAndWaitForReceiptAsync(BigInteger.Parse(generateCodesDto.ElectionId),
                                                                                       generateCodesDto.VoterAdress,
                                                                                       generateCodesDto.Voter);

                var transferEventOutput = resp.DecodeAllEvents<UserAddedToElectionEventDTOBase>();
                return Ok(transferEventOutput.FirstOrDefault().Event);
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
        public async Task<IActionResult> AddAdmin([FromBody] AddAdminDto addAdminDto)
        {
            try
            {
                var svc = NethereumProvider.GetVotingSystemService(addAdminDto.Auth.AccountAddress, addAdminDto.Auth.Password);

                var resp = await svc.AddAdminRequestAndWaitForReceiptAsync(addAdminDto.Admin);

                return Ok(new MessageView("Administrator added"));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }
    }
}