var votingSystem = artifacts.require("VotingSystem");
module.exports = function(deployer) {
    deployer.deploy(votingSystem);
};