// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.9.0;
pragma experimental ABIEncoderV2;

contract VotingSystem {
    
    struct election {
        uint ElectionId;
        string Title;
        uint64 DateFrom;
        uint64 DateTo;
        uint8 KeysPerVoter;
        string[] Candidates;
    }

    struct electionDetails {
        uint ElectionId;
        string Title;
        uint64 DateFrom;
        uint64 DateTo;
        uint8 KeysPerVoter;
        result[] Results;
    }

    struct key {
        address KeyValue;
        uint ElectionId;
        string Voter;
        address VoterAddress;
        bool ValidKey;
    }

    struct vote {
        address KeyValue;
        uint64 CandidateId;
        uint64 VotedDate;
        address VoterAddress;
        bool Latest;
    }

    struct result {
        string Candidate;
        uint64 Votes;
    }

    struct generated {
        address VoterAddress;
        uint ElectionId;
    }

    mapping (address => string) voters;
    mapping (address => key) keys;
    mapping (address => mapping (uint => bool)) generatedKeys;
    mapping (uint => vote[]) votes; //mapping vote array for every election

    mapping (address => bool) admins; 
    bool adminsAdded = false; 

    election[] public elections;


    function getElections() public view 
    adminOnly()
    returns(election[] memory electionList) 
    {
        electionList = elections;
    }


    function getDetails(uint id) public view 
    adminOnly()
    //onlyAfterElection(id)
    returns(electionDetails memory Value) 
    {
        for(uint i=0; i < elections.length; i++){
            if (elections[i].ElectionId == id){
                election memory el = elections[i];
                result[] memory results = new result[](el.Candidates.length);
                for(uint j=0; j < el.Candidates.length; j++){
                    results[j].Candidate = el.Candidates[j];
                }

                vote[] memory electionVotes = votes[el.ElectionId];
                for(uint j=0; j < electionVotes.length; j++){
                    if (electionVotes[j].Latest){
                        results[electionVotes[j].CandidateId].Votes += 1;
                    }
                }

                return electionDetails(el.ElectionId, el.Title, el.DateFrom, el.DateTo, el.KeysPerVoter, results);
            }
        }
        revert("Election not found.");
    }


    function addElection(string memory title, uint64 dateFrom, uint64 dateTo, uint8 keysPerVoter, string[] memory candidateList) public 
        onlyUniqueCandidates(candidateList)
        adminOnly()
    {
        uint id = uint(keccak256(abi.encodePacked(block.timestamp, msg.sender)));

        elections.push(election(id, title, dateFrom, dateTo, keysPerVoter, candidateList));
    }


    event UserAddedToElection(key[] newKeys);


    function addAddUserToElection(uint electionId, address voterAdress, string memory voter) public payable 
    adminOnly()
    returns(key[] memory newKeys)
    {
        require(generatedKeys[voterAdress][electionId] == false, "Keys for this user have been generated.");
        for(uint i=0; i < elections.length; i++){
            if (elections[i].ElectionId == electionId){
                require(elections[i].DateFrom > block.timestamp);

                if (bytes(voters[voterAdress]).length==0){
                    voters[voterAdress] = voter;
                }
                require(equal(voters[voterAdress], voter));

                uint keysCount = elections[i].KeysPerVoter;
                newKeys = new key[](keysCount);
                for(uint j=0; j < keysCount; j++){
                    address addr = address(uint160(uint(keccak256(abi.encodePacked(block.timestamp + j, blockhash(block.number))))));
                    key memory k = key(addr, electionId, voter, voterAdress, true);
                    keys[addr] = k;
                    newKeys[j] = k;
                }
                break;
            }
        }
        generatedKeys[voterAdress][electionId] = true;
        emit UserAddedToElection(newKeys);
    }


    function addVote(string memory voter, address keyAdr, uint64 candidateId ) public 
        //onlyDuringElection(keyAdr)
        {
        require(keys[keyAdr].ValidKey, "Key not valid.");
        require(equal(voters[msg.sender], voter), "Sender and voter don't match.");

        vote[] storage votesb = votes[keys[keyAdr].ElectionId];
        for(uint i=0; i < votesb.length; i++){
            if (votesb[i].VoterAddress == msg.sender){
                votesb[i].Latest = false;
            }
        }
        votesb.push(vote(keyAdr, candidateId, uint64(block.timestamp), msg.sender, true));
        keys[keyAdr].ValidKey = false;
    }        


    function checkVote(string memory voter, address keyAdr) public view
    returns(bool voted) 
    {
        require(bytes(voters[msg.sender]).length > 0, "Voter doesn't exist.");
        require(equal(voters[msg.sender], voter), "Sender and voter don't match.");
        
        voted = false;
        vote[] storage votesb = votes[keys[keyAdr].ElectionId];
        for(uint i=0; i < votesb.length; i++){
            if (votesb[i].VoterAddress == msg.sender && votesb[i].Latest) voted = true;
        }
    }  


    function startVote(string memory voter, address keyAdr) public view
    //onlyDuringElection(keyAdr)
    returns(election memory el) {
        require(keys[keyAdr].ValidKey, "Key not valid.");
        require(equal(voters[msg.sender], voter), "Sender and voter don't match.");
        
        key memory k = keys[keyAdr];

        for(uint i=0; i < elections.length; i++){
            if (elections[i].ElectionId == k.ElectionId){
                el = elections[i];
                break;
            }
        }
    }  


    function equal(string memory a, string memory b) pure private returns(bool) {
        return keccak256(abi.encodePacked(a)) == keccak256(abi.encodePacked(b));
    }

    function isAdmin() public view returns(bool) {
        return admins[msg.sender];
    }

    function addAdminBatch(address[] memory newAdmins) public 
    senderExistsInBatch(newAdmins)
    {
        require(!adminsAdded, "Admin batch is only avaible once while there is no administrator.");
        require(newAdmins.length>0, "List is empty");

        for(uint i=0; i < newAdmins.length; i++){
           admins[newAdmins[i]] = true;
        }
        adminsAdded = true;
    } 


    function addAdmin(address newAdmin) public 
    adminOnly()
    {
        require(adminsAdded, "No admin batch added.");
        admins[newAdmin] = true;
    } 

    function removeAdmin(address admin) public 
    adminOnly()
    {
        require(adminsAdded, "No admin batch added.");
        require(admin != msg.sender, "Admin can't take his own privileges.");
        admins[admin] = false;
    } 

    modifier onlyUniqueCandidates(string[] memory candidateList) {
        for(uint i=0; i < candidateList.length; i++){
            for(uint j=0; j < candidateList.length; j++){
                if (i != j){
                    if (equal(candidateList[i], candidateList[j])){
                        revert("Candidate is not unique");
                    }
                }
            }
        }
        _;
    }


    modifier adminOnly() {
        if (!admins[msg.sender]) revert("No permission.");
        _;
    }


    modifier onlyDuringElection(address keyAdr) {
        key memory k = keys[keyAdr];
        election memory el;
        for(uint i=0; i < elections.length; i++){
            if (elections[i].ElectionId == k.ElectionId){
                el = elections[i];
                break;
            }
        }
        if(el.DateFrom > block.timestamp || el.DateTo < block.timestamp) revert("Voting only allowed during the election.");
        _;
    }

    modifier onlyAfterElection(uint id) {
        election memory el;
        for(uint i=0; i < elections.length; i++){
            if (elections[i].ElectionId == id){
                el = elections[i];
                break;
            }
        }
        if(el.DateTo > block.timestamp) revert("Checking the results is only allowed after the eleciton.");
        _;
    }

    modifier senderExistsInBatch(address[] memory newAdmins) {
        bool exists = false;
        for(uint i=0; i < newAdmins.length; i++){
            if (msg.sender == newAdmins[i]) exists = true;
        }
        if (!exists) revert("Sender has to be one of the admins.");
        _;
    }
}
