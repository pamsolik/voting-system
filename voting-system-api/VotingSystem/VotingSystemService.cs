using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using VotingSystemApi.Contracts.VotingSystem.ContractDefinition;

namespace VotingSystemApi.Contracts.VotingSystem
{
    public partial class VotingSystemService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, VotingSystemDeployment votingSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<VotingSystemDeployment>().SendRequestAndWaitForReceiptAsync(votingSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, VotingSystemDeployment votingSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<VotingSystemDeployment>().SendRequestAsync(votingSystemDeployment);
        }

        public static async Task<VotingSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, VotingSystemDeployment votingSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, votingSystemDeployment, cancellationTokenSource);
            return new VotingSystemService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public VotingSystemService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddAddUserToElectionRequestAsync(AddAddUserToElectionFunction addAddUserToElectionFunction)
        {
             return ContractHandler.SendRequestAsync(addAddUserToElectionFunction);
        }

        public Task<TransactionReceipt> AddAddUserToElectionRequestAndWaitForReceiptAsync(AddAddUserToElectionFunction addAddUserToElectionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAddUserToElectionFunction, cancellationToken);
        }

        public Task<string> AddAddUserToElectionRequestAsync(BigInteger electionId, string voterAdress, string voter)
        {
            var addAddUserToElectionFunction = new AddAddUserToElectionFunction();
                addAddUserToElectionFunction.ElectionId = electionId;
                addAddUserToElectionFunction.VoterAdress = voterAdress;
                addAddUserToElectionFunction.Voter = voter;
            
             return ContractHandler.SendRequestAsync(addAddUserToElectionFunction);
        }

        public Task<TransactionReceipt> AddAddUserToElectionRequestAndWaitForReceiptAsync(BigInteger electionId, string voterAdress, string voter, CancellationTokenSource cancellationToken = null)
        {
            var addAddUserToElectionFunction = new AddAddUserToElectionFunction();
                addAddUserToElectionFunction.ElectionId = electionId;
                addAddUserToElectionFunction.VoterAdress = voterAdress;
                addAddUserToElectionFunction.Voter = voter;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAddUserToElectionFunction, cancellationToken);
        }

        public Task<string> AddAdminRequestAsync(AddAdminFunction addAdminFunction)
        {
             return ContractHandler.SendRequestAsync(addAdminFunction);
        }

        public Task<TransactionReceipt> AddAdminRequestAndWaitForReceiptAsync(AddAdminFunction addAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAdminFunction, cancellationToken);
        }

        public Task<string> AddAdminRequestAsync(string newAdmin)
        {
            var addAdminFunction = new AddAdminFunction();
                addAdminFunction.NewAdmin = newAdmin;
            
             return ContractHandler.SendRequestAsync(addAdminFunction);
        }

        public Task<TransactionReceipt> AddAdminRequestAndWaitForReceiptAsync(string newAdmin, CancellationTokenSource cancellationToken = null)
        {
            var addAdminFunction = new AddAdminFunction();
                addAdminFunction.NewAdmin = newAdmin;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAdminFunction, cancellationToken);
        }

        public Task<string> AddAdminBatchRequestAsync(AddAdminBatchFunction addAdminBatchFunction)
        {
             return ContractHandler.SendRequestAsync(addAdminBatchFunction);
        }

        public Task<TransactionReceipt> AddAdminBatchRequestAndWaitForReceiptAsync(AddAdminBatchFunction addAdminBatchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAdminBatchFunction, cancellationToken);
        }

        public Task<string> AddAdminBatchRequestAsync(List<string> newAdmins)
        {
            var addAdminBatchFunction = new AddAdminBatchFunction();
                addAdminBatchFunction.NewAdmins = newAdmins;
            
             return ContractHandler.SendRequestAsync(addAdminBatchFunction);
        }

        public Task<TransactionReceipt> AddAdminBatchRequestAndWaitForReceiptAsync(List<string> newAdmins, CancellationTokenSource cancellationToken = null)
        {
            var addAdminBatchFunction = new AddAdminBatchFunction();
                addAdminBatchFunction.NewAdmins = newAdmins;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAdminBatchFunction, cancellationToken);
        }

        public Task<string> AddElectionRequestAsync(AddElectionFunction addElectionFunction)
        {
             return ContractHandler.SendRequestAsync(addElectionFunction);
        }

        public Task<TransactionReceipt> AddElectionRequestAndWaitForReceiptAsync(AddElectionFunction addElectionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addElectionFunction, cancellationToken);
        }

        public Task<string> AddElectionRequestAsync(string title, ulong dateFrom, ulong dateTo, byte keysPerVoter, List<string> candidateList)
        {
            var addElectionFunction = new AddElectionFunction();
                addElectionFunction.Title = title;
                addElectionFunction.DateFrom = dateFrom;
                addElectionFunction.DateTo = dateTo;
                addElectionFunction.KeysPerVoter = keysPerVoter;
                addElectionFunction.CandidateList = candidateList;
            
             return ContractHandler.SendRequestAsync(addElectionFunction);
        }

        public Task<TransactionReceipt> AddElectionRequestAndWaitForReceiptAsync(string title, ulong dateFrom, ulong dateTo, byte keysPerVoter, List<string> candidateList, CancellationTokenSource cancellationToken = null)
        {
            var addElectionFunction = new AddElectionFunction();
                addElectionFunction.Title = title;
                addElectionFunction.DateFrom = dateFrom;
                addElectionFunction.DateTo = dateTo;
                addElectionFunction.KeysPerVoter = keysPerVoter;
                addElectionFunction.CandidateList = candidateList;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addElectionFunction, cancellationToken);
        }

        public Task<string> AddVoteRequestAsync(AddVoteFunction addVoteFunction)
        {
             return ContractHandler.SendRequestAsync(addVoteFunction);
        }

        public Task<TransactionReceipt> AddVoteRequestAndWaitForReceiptAsync(AddVoteFunction addVoteFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addVoteFunction, cancellationToken);
        }

        public Task<string> AddVoteRequestAsync(string voter, string keyAdr, ulong candidateId)
        {
            var addVoteFunction = new AddVoteFunction();
                addVoteFunction.Voter = voter;
                addVoteFunction.KeyAdr = keyAdr;
                addVoteFunction.CandidateId = candidateId;
            
             return ContractHandler.SendRequestAsync(addVoteFunction);
        }

        public Task<TransactionReceipt> AddVoteRequestAndWaitForReceiptAsync(string voter, string keyAdr, ulong candidateId, CancellationTokenSource cancellationToken = null)
        {
            var addVoteFunction = new AddVoteFunction();
                addVoteFunction.Voter = voter;
                addVoteFunction.KeyAdr = keyAdr;
                addVoteFunction.CandidateId = candidateId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addVoteFunction, cancellationToken);
        }

        public Task<bool> CheckVoteQueryAsync(CheckVoteFunction checkVoteFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckVoteFunction, bool>(checkVoteFunction, blockParameter);
        }

        
        public Task<bool> CheckVoteQueryAsync(string voter, string keyAdr, BlockParameter blockParameter = null)
        {
            var checkVoteFunction = new CheckVoteFunction();
                checkVoteFunction.Voter = voter;
                checkVoteFunction.KeyAdr = keyAdr;
            
            return ContractHandler.QueryAsync<CheckVoteFunction, bool>(checkVoteFunction, blockParameter);
        }

        public Task<ElectionsOutputDTO> ElectionsQueryAsync(ElectionsFunction electionsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ElectionsFunction, ElectionsOutputDTO>(electionsFunction, blockParameter);
        }

        public Task<ElectionsOutputDTO> ElectionsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var electionsFunction = new ElectionsFunction();
                electionsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ElectionsFunction, ElectionsOutputDTO>(electionsFunction, blockParameter);
        }

        public Task<GetDetailsOutputDTO> GetDetailsQueryAsync(GetDetailsFunction getDetailsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetDetailsFunction, GetDetailsOutputDTO>(getDetailsFunction, blockParameter);
        }

        public Task<GetDetailsOutputDTO> GetDetailsQueryAsync(BigInteger id, BlockParameter blockParameter = null)
        {
            var getDetailsFunction = new GetDetailsFunction();
                getDetailsFunction.Id = id;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetDetailsFunction, GetDetailsOutputDTO>(getDetailsFunction, blockParameter);
        }

        public Task<GetElectionsOutputDTO> GetElectionsQueryAsync(GetElectionsFunction getElectionsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetElectionsFunction, GetElectionsOutputDTO>(getElectionsFunction, blockParameter);
        }

        public Task<GetElectionsOutputDTO> GetElectionsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetElectionsFunction, GetElectionsOutputDTO>(null, blockParameter);
        }

        public Task<StartVoteOutputDTO> StartVoteQueryAsync(StartVoteFunction startVoteFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<StartVoteFunction, StartVoteOutputDTO>(startVoteFunction, blockParameter);
        }

        public Task<StartVoteOutputDTO> StartVoteQueryAsync(string voter, string keyAdr, BlockParameter blockParameter = null)
        {
            var startVoteFunction = new StartVoteFunction();
                startVoteFunction.Voter = voter;
                startVoteFunction.KeyAdr = keyAdr;
            
            return ContractHandler.QueryDeserializingToObjectAsync<StartVoteFunction, StartVoteOutputDTO>(startVoteFunction, blockParameter);
        }
    }
}
