﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

using VotingSystemApi.Models.DTOs;
using VotingSystemApi.Models.Views;
using VotingSystemApi.Services;

namespace VotingSystemApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("check_vote")]
        public async Task<IActionResult> CheckVote([FromBody] StartVoteDto startVoteDto)
        {
            try
            {
                var svc = NethereumProvider.GetVotingSystemService(startVoteDto.Auth.AccountAddress, startVoteDto.Auth.Password);

                var res = await svc.CheckVoteQueryAsync(startVoteDto.Voter,
                                                        startVoteDto.KeyAdr);
                return Ok(new VotedView(res));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        //Check if user can vote and return candidates and election details.
        [HttpGet("start_vote")]
        public async Task<IActionResult> StartVote([FromBody] StartVoteDto startVoteDto)
        {
            try
            {
                var svc = NethereumProvider.GetVotingSystemService(startVoteDto.Auth.AccountAddress, startVoteDto.Auth.Password);

                var res = await svc.StartVoteQueryAsync(startVoteDto.Voter,
                                                        startVoteDto.KeyAdr);
                return Ok(new StartElectionView(res));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }

        [HttpPost("add_vote")]
        public async Task<IActionResult> AddVote([FromBody] AddVoteDto addVoteDto)
        {
            try
            {
                var svc = NethereumProvider.GetVotingSystemService(addVoteDto.Auth.AccountAddress, addVoteDto.Auth.Password);

                var res = await svc.AddVoteRequestAndWaitForReceiptAsync(addVoteDto.Voter,
                                                                         addVoteDto.KeyAdr,
                                                                         addVoteDto.CandidateId);
                return Ok(new MessageView("Vote added!"));
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageView(ex.Message));
            }
        }
    }
}