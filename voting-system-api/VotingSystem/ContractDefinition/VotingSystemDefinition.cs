using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace VotingSystemApi.Contracts.VotingSystem.ContractDefinition
{


    public partial class VotingSystemDeployment : VotingSystemDeploymentBase
    {
        public VotingSystemDeployment() : base(BYTECODE) { }
        public VotingSystemDeployment(string byteCode) : base(byteCode) { }
    }

    public class VotingSystemDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040526005805460ff1916905534801561001a57600080fd5b50612fc38061002a6000396000f3fe6080604052600436106100915760003560e01c8063987641cb11610059578063987641cb1461015f5780639916cc351461018f5780639f3a7f52146101af578063aba47579146101d1578063b93a89f7146101f157600080fd5b80635e6fef01146100965780636fcf362e146100d057806370480275146100f2578063834e90cf146101125780638de34e9514610132575b600080fd5b3480156100a257600080fd5b506100b66100b1366004612a00565b61021e565b6040516100c7959493929190612e00565b60405180910390f35b3480156100dc57600080fd5b506100f06100eb3660046128f6565b6102fe565b005b3480156100fe57600080fd5b506100f061010d366004612791565b61059c565b610125610120366004612a18565b6105fe565b6040516100c79190612bc8565b34801561013e57600080fd5b5061015261014d366004612850565b610ad5565b6040516100c79190612ded565b34801561016b57600080fd5b5061017f61017a366004612850565b6112df565b60405190151581526020016100c7565b34801561019b57600080fd5b506100f06101aa36600461289b565b61146a565b3480156101bb57600080fd5b506101c4611b16565b6040516100c79190612b67565b3480156101dd57600080fd5b506100f06101ec3660046127b2565b611d53565b3480156101fd57600080fd5b5061021161020c366004612a00565b611f60565b6040516100c79190612d19565b6006818154811061022e57600080fd5b6000918252602090912060049091020180546001820180549193509061025390612f0b565b80601f016020809104026020016040519081016040528092919081815260200182805461027f90612f0b565b80156102cc5780601f106102a1576101008083540402835291602001916102cc565b820191906000526020600020905b8154815290600101906020018083116102af57829003601f168201915b505050600290930154919250506001600160401b0380821691600160401b81049091169060ff600160801b9091041685565b8060005b81518110156103ed5760005b82518110156103da578082146103c85761037683838151811061034157634e487b7160e01b600052603260045260246000fd5b602002602001015184838151811061036957634e487b7160e01b600052603260045260246000fd5b6020026020010151612520565b156103c85760405162461bcd60e51b815260206004820152601760248201527f43616e646964617465206973206e6f7420756e6971756500000000000000000060448201526064015b60405180910390fd5b806103d281612f46565b91505061030e565b50806103e581612f46565b915050610302565b503360009081526004602052604090205460ff1661041d5760405162461bcd60e51b81526004016103bf90612cf1565b6000423360405160200161044d92919091825260601b6bffffffffffffffffffffffff1916602082015260340190565b60408051808303601f19018152828252805160209182012060c0840183528084528184018b81526001600160401b038b811694860194909452928916606085015260ff8816608085015260a084018790526006805460018101825560009190915284517ff652222313e28459528d920b65115c16c04f3efc82aaedc97be59f3f377c0d3f600490920291820190815593518051929650610514937ff652222313e28459528d920b65115c16c04f3efc82aaedc97be59f3f377c0d4090920192910190612579565b5060408201516002820180546060850151608086015160ff16600160801b0260ff60801b196001600160401b03928316600160401b026fffffffffffffffffffffffffffffffff199094169290951691909117919091179290921691909117905560a082015180516105909160038401916020909101906125fd565b50505050505050505050565b3360009081526004602052604090205460ff166105cb5760405162461bcd60e51b81526004016103bf90612cf1565b60055460ff166105da57600080fd5b6001600160a01b03166000908152600460205260409020805460ff19166001179055565b3360009081526004602052604090205460609060ff166106305760405162461bcd60e51b81526004016103bf90612cf1565b6001600160a01b038316600090815260026020908152604080832087845290915290205460ff16156106b45760405162461bcd60e51b815260206004820152602760248201527f4b65797320666f72207468697320757365722068617665206265656e2067656e60448201526632b930ba32b21760c91b60648201526084016103bf565b60005b600654811015610a675784600682815481106106e357634e487b7160e01b600052603260045260246000fd5b9060005260206000209060040201600001541415610a5557426006828154811061071d57634e487b7160e01b600052603260045260246000fd5b60009182526020909120600260049092020101546001600160401b03161161074457600080fd5b6001600160a01b0384166000908152602081905260409020805461076790612f0b565b15159050610798576001600160a01b038416600090815260208181526040909120845161079692860190612579565b505b6001600160a01b0384166000908152602081905260409020805461084491906107c090612f0b565b80601f01602080910402602001604051908101604052809291908181526020018280546107ec90612f0b565b80156108395780601f1061080e57610100808354040283529160200191610839565b820191906000526020600020905b81548152906001019060200180831161081c57829003601f168201915b505050505084612520565b61084d57600080fd5b60006006828154811061087057634e487b7160e01b600052603260045260246000fd5b6000918252602090912060049091020160020154600160801b900460ff169050806001600160401b038111156108b657634e487b7160e01b600052604160045260246000fd5b60405190808252806020026020018201604052801561091057816020015b6040805160a081018252600080825260208083018290526060938301849052928201819052608082015282526000199092019101816108d45790505b50925060005b81811015610a4e57600061092a8242612e98565b60408051602081019290925243409082015260600160408051808303601f19018152828252805160209182012060a0840183526001600160a01b038082168086528386018e81528686018d81528e84166060890152600160808901819052600093845280875296909220875181546001600160a01b03191694169390931783555194820194909455925180519195508493926109ce92600285019290910190612579565b506060820151600390910180546080909301511515600160a01b026001600160a81b03199093166001600160a01b039092169190911791909117905585518190879085908110610a2e57634e487b7160e01b600052603260045260246000fd5b602002602001018190525050508080610a4690612f46565b915050610916565b5050610a67565b80610a5f81612f46565b9150506106b7565b506001600160a01b038316600090815260026020908152604080832087845290915290819020805460ff19166001179055517fb6db8bc678559103f3606a91c7397a96696ac489c86b9726831e695b8484291d90610ac6908390612bc8565b60405180910390a19392505050565b610add612656565b6001600160a01b038083166000908152600160208181526040808420815160a0810183528154909616865292830154918501919091526002820180548795939284019190610b2a90612f0b565b80601f0160208091040260200160405190810160405280929190818152602001828054610b5690612f0b565b8015610ba35780601f10610b7857610100808354040283529160200191610ba3565b820191906000526020600020905b815481529060010190602001808311610b8657829003601f168201915b5050509183525050600391909101546001600160a01b0381166020830152600160a01b900460ff1615156040909101529050610bdd612656565b60005b600654811015610e2957826020015160068281548110610c1057634e487b7160e01b600052603260045260246000fd5b9060005260206000209060040201600001541415610e175760068181548110610c4957634e487b7160e01b600052603260045260246000fd5b90600052602060002090600402016040518060c001604052908160008201548152602001600182018054610c7c90612f0b565b80601f0160208091040260200160405190810160405280929190818152602001828054610ca890612f0b565b8015610cf55780601f10610cca57610100808354040283529160200191610cf5565b820191906000526020600020905b815481529060010190602001808311610cd857829003601f168201915b505050918352505060028201546001600160401b03808216602080850191909152600160401b8304909116604080850191909152600160801b90920460ff166060840152600384018054835181840281018401909452808452608090940193909160009084015b82821015610e08578382906000526020600020018054610d7b90612f0b565b80601f0160208091040260200160405190810160405280929190818152602001828054610da790612f0b565b8015610df45780601f10610dc957610100808354040283529160200191610df4565b820191906000526020600020905b815481529060010190602001808311610dd757829003601f168201915b505050505081526020019060010190610d5c565b50505050815250509150610e29565b80610e2181612f46565b915050610be0565b504281604001516001600160401b0316118015610e5257504281606001516001600160401b0316105b15610e6f5760405162461bcd60e51b81526004016103bf90612c72565b6001600160a01b038516600090815260016020526040902060030154600160a01b900460ff16610ed25760405162461bcd60e51b815260206004820152600e60248201526d25b2bc903737ba103b30b634b21760911b60448201526064016103bf565b3360009081526020819052604090208054610f759190610ef190612f0b565b80601f0160208091040260200160405190810160405280929190818152602001828054610f1d90612f0b565b8015610f6a5780601f10610f3f57610100808354040283529160200191610f6a565b820191906000526020600020905b815481529060010190602001808311610f4d57829003601f168201915b505050505087612520565b610f915760405162461bcd60e51b81526004016103bf90612cba565b6001600160a01b038086166000908152600160208181526040808420815160a08101835281549096168652928301549185019190915260028201805493949391840191610fdd90612f0b565b80601f016020809104026020016040519081016040528092919081815260200182805461100990612f0b565b80156110565780601f1061102b57610100808354040283529160200191611056565b820191906000526020600020905b81548152906001019060200180831161103957829003601f168201915b5050509183525050600391909101546001600160a01b0381166020830152600160a01b900460ff161515604090910152905060005b6006548110156112d4578160200151600682815481106110bb57634e487b7160e01b600052603260045260246000fd5b90600052602060002090600402016000015414156112c257600681815481106110f457634e487b7160e01b600052603260045260246000fd5b90600052602060002090600402016040518060c00160405290816000820154815260200160018201805461112790612f0b565b80601f016020809104026020016040519081016040528092919081815260200182805461115390612f0b565b80156111a05780601f10611175576101008083540402835291602001916111a0565b820191906000526020600020905b81548152906001019060200180831161118357829003601f168201915b505050918352505060028201546001600160401b03808216602080850191909152600160401b8304909116604080850191909152600160801b90920460ff166060840152600384018054835181840281018401909452808452608090940193909160009084015b828210156112b357838290600052602060002001805461122690612f0b565b80601f016020809104026020016040519081016040528092919081815260200182805461125290612f0b565b801561129f5780601f106112745761010080835404028352916020019161129f565b820191906000526020600020905b81548152906001019060200180831161128257829003601f168201915b505050505081526020019060010190611207565b505050508152505095506112d4565b806112cc81612f46565b91505061108b565b505050505092915050565b33600090815260208190526040812080548291906112fc90612f0b565b9050116113425760405162461bcd60e51b81526020600482015260146024820152732b37ba32b9103237b2b9b713ba1032bc34b9ba1760611b60448201526064016103bf565b336000908152602081905260409020805461136191906107c090612f0b565b61137d5760405162461bcd60e51b81526004016103bf90612cba565b506001600160a01b0381166000908152600160208181526040808420909201548352600390528120815b815481101561146257336001600160a01b03168282815481106113da57634e487b7160e01b600052603260045260246000fd5b6000918252602090912060029091020160010154600160401b90046001600160a01b0316148015611446575081818154811061142657634e487b7160e01b600052603260045260246000fd5b9060005260206000209060020201600101601c9054906101000a900460ff165b1561145057600192505b8061145a81612f46565b9150506113a7565b505092915050565b6001600160a01b038083166000908152600160208181526040808420815160a08101835281549096168652928301549185019190915260028201805487959392840191906114b790612f0b565b80601f01602080910402602001604051908101604052809291908181526020018280546114e390612f0b565b80156115305780601f1061150557610100808354040283529160200191611530565b820191906000526020600020905b81548152906001019060200180831161151357829003601f168201915b5050509183525050600391909101546001600160a01b0381166020830152600160a01b900460ff161515604090910152905061156a612656565b60005b6006548110156117b65782602001516006828154811061159d57634e487b7160e01b600052603260045260246000fd5b90600052602060002090600402016000015414156117a457600681815481106115d657634e487b7160e01b600052603260045260246000fd5b90600052602060002090600402016040518060c00160405290816000820154815260200160018201805461160990612f0b565b80601f016020809104026020016040519081016040528092919081815260200182805461163590612f0b565b80156116825780601f1061165757610100808354040283529160200191611682565b820191906000526020600020905b81548152906001019060200180831161166557829003601f168201915b505050918352505060028201546001600160401b03808216602080850191909152600160401b8304909116604080850191909152600160801b90920460ff166060840152600384018054835181840281018401909452808452608090940193909160009084015b8282101561179557838290600052602060002001805461170890612f0b565b80601f016020809104026020016040519081016040528092919081815260200182805461173490612f0b565b80156117815780601f1061175657610100808354040283529160200191611781565b820191906000526020600020905b81548152906001019060200180831161176457829003601f168201915b5050505050815260200190600101906116e9565b505050508152505091506117b6565b806117ae81612f46565b91505061156d565b504281604001516001600160401b03161180156117df57504281606001516001600160401b0316105b156117fc5760405162461bcd60e51b81526004016103bf90612c72565b6001600160a01b038516600090815260016020526040902060030154600160a01b900460ff1661185f5760405162461bcd60e51b815260206004820152600e60248201526d25b2bc903737ba103b30b634b21760911b60448201526064016103bf565b336000908152602081905260409020805461187e9190610ef190612f0b565b61189a5760405162461bcd60e51b81526004016103bf90612cba565b6001600160a01b0385166000908152600160208181526040808420909201548352600390528120905b815481101561197d57336001600160a01b03168282815481106118f657634e487b7160e01b600052603260045260246000fd5b6000918252602090912060029091020160010154600160401b90046001600160a01b0316141561196b57600082828154811061194257634e487b7160e01b600052603260045260246000fd5b9060005260206000209060020201600101601c6101000a81548160ff0219169083151502179055505b8061197581612f46565b9150506118c3565b50806040518060a00160405280886001600160a01b03168152602001876001600160401b03168152602001426001600160401b03168152602001336001600160a01b0316815260200160011515815250908060018154018082558091505060019003906000526020600020906002020160009091909190915060008201518160000160006101000a8154816001600160a01b0302191690836001600160a01b0316021790555060208201518160000160146101000a8154816001600160401b0302191690836001600160401b0316021790555060408201518160010160006101000a8154816001600160401b0302191690836001600160401b0316021790555060608201518160010160086101000a8154816001600160a01b0302191690836001600160a01b03160217905550608082015181600101601c6101000a81548160ff0219169083151502179055505050600060016000886001600160a01b03166001600160a01b0316815260200190815260200160002060030160146101000a81548160ff02191690831515021790555050505050505050565b3360009081526004602052604090205460609060ff16611b485760405162461bcd60e51b81526004016103bf90612cf1565b6006805480602002602001604051908101604052809291908181526020016000905b82821015611d4a57838290600052602060002090600402016040518060c001604052908160008201548152602001600182018054611ba790612f0b565b80601f0160208091040260200160405190810160405280929190818152602001828054611bd390612f0b565b8015611c205780601f10611bf557610100808354040283529160200191611c20565b820191906000526020600020905b815481529060010190602001808311611c0357829003601f168201915b505050918352505060028201546001600160401b03808216602080850191909152600160401b8304909116604080850191909152600160801b90920460ff166060840152600384018054835181840281018401909452808452608090940193909160009084015b82821015611d33578382906000526020600020018054611ca690612f0b565b80601f0160208091040260200160405190810160405280929190818152602001828054611cd290612f0b565b8015611d1f5780601f10611cf457610100808354040283529160200191611d1f565b820191906000526020600020905b815481529060010190602001808311611d0257829003601f168201915b505050505081526020019060010190611c87565b505050508152505081526020019060010190611b6a565b50505050905090565b806000805b8251811015611db957828181518110611d8157634e487b7160e01b600052603260045260246000fd5b60200260200101516001600160a01b0316336001600160a01b03161415611da757600191505b80611db181612f46565b915050611d58565b5080611e135760405162461bcd60e51b815260206004820152602360248201527f53656e6465722068617320746f206265206f6e65206f66207468652061646d6960448201526237399760e91b60648201526084016103bf565b60055460ff1615611e965760405162461bcd60e51b815260206004820152604160248201527f41646d696e206261746368206973206f6e6c792061766169626c65206f6e636560448201527f207768696c65207468657265206973206e6f2061646d696e6973747261746f726064820152601760f91b608482015260a4016103bf565b6000835111611ed75760405162461bcd60e51b815260206004820152600d60248201526c4c69737420697320656d70747960981b60448201526064016103bf565b60005b8351811015611f4d57600160046000868481518110611f0957634e487b7160e01b600052603260045260246000fd5b6020908102919091018101516001600160a01b03168252810191909152604001600020805460ff191691151591909117905580611f4581612f46565b915050611eda565b50506005805460ff191660011790555050565b6040805160c0810182526000808252606060208301819052928201819052828201819052608082015260a08101919091523360009081526004602052604090205460ff16611fc05760405162461bcd60e51b81526004016103bf90612cf1565b60005b6006548110156124dc578260068281548110611fef57634e487b7160e01b600052603260045260246000fd5b90600052602060002090600402016000015414156124ca5760006006828154811061202a57634e487b7160e01b600052603260045260246000fd5b90600052602060002090600402016040518060c00160405290816000820154815260200160018201805461205d90612f0b565b80601f016020809104026020016040519081016040528092919081815260200182805461208990612f0b565b80156120d65780601f106120ab576101008083540402835291602001916120d6565b820191906000526020600020905b8154815290600101906020018083116120b957829003601f168201915b505050918352505060028201546001600160401b03808216602080850191909152600160401b8304909116604080850191909152600160801b90920460ff166060840152600384018054835181840281018401909452808452608090940193909160009084015b828210156121e957838290600052602060002001805461215c90612f0b565b80601f016020809104026020016040519081016040528092919081815260200182805461218890612f0b565b80156121d55780601f106121aa576101008083540402835291602001916121d5565b820191906000526020600020905b8154815290600101906020018083116121b857829003601f168201915b50505050508152602001906001019061213d565b5050505081525050905060008160a00151516001600160401b0381111561222057634e487b7160e01b600052604160045260246000fd5b60405190808252806020026020018201604052801561226657816020015b60408051808201909152606081526000602082015281526020019060019003908161223e5790505b50905060005b8260a00151518110156122e3578260a00151818151811061229d57634e487b7160e01b600052603260045260246000fd5b60200260200101518282815181106122c557634e487b7160e01b600052603260045260246000fd5b602090810291909101015152806122db81612f46565b91505061226c565b508151600090815260036020908152604080832080548251818502810185019093528083529192909190849084015b828210156123985760008481526020908190206040805160a0810182526002860290920180546001600160a01b038082168552600160a01b9091046001600160401b039081168587015260019283015490811693850193909352600160401b8304166060840152600160e01b90910460ff16151560808301529083529092019101612312565b50505050905060005b8151811015612468578181815181106123ca57634e487b7160e01b600052603260045260246000fd5b60200260200101516080015115612456576001838383815181106123fe57634e487b7160e01b600052603260045260246000fd5b6020026020010151602001516001600160401b03168151811061243157634e487b7160e01b600052603260045260246000fd5b60200260200101516020018181516124499190612eb0565b6001600160401b03169052505b8061246081612f46565b9150506123a1565b506040518060c00160405280846000015181526020018460200151815260200184604001516001600160401b0316815260200184606001516001600160401b03168152602001846080015160ff16815260200183815250945050505050919050565b806124d481612f46565b915050611fc3565b5060405162461bcd60e51b815260206004820152601360248201527222b632b1ba34b7b7103737ba103337bab7321760691b60448201526064016103bf565b919050565b6000816040516020016125339190612b4b565b604051602081830303815290604052805190602001208360405160200161255a9190612b4b565b6040516020818303038152906040528051906020012014905092915050565b82805461258590612f0b565b90600052602060002090601f0160209004810192826125a757600085556125ed565b82601f106125c057805160ff19168380011785556125ed565b828001600101855582156125ed579182015b828111156125ed5782518255916020019190600101906125d2565b506125f992915061268a565b5090565b82805482825590600052602060002090810192821561264a579160200282015b8281111561264a578251805161263a918491602090910190612579565b509160200191906001019061261d565b506125f992915061269f565b6040805160c0810182526000808252606060208301819052928201819052828201819052608082015260a081019190915290565b5b808211156125f9576000815560010161268b565b808211156125f95760006126b382826126bc565b5060010161269f565b5080546126c890612f0b565b6000825580601f106126d8575050565b601f0160209004906000526020600020908101906126f6919061268a565b50565b80356001600160a01b038116811461251b57600080fd5b600082601f830112612720578081fd5b81356001600160401b0381111561273957612739612f77565b61274c601f8201601f1916602001612e45565b818152846020838601011115612760578283fd5b816020850160208301379081016020019190915292915050565b80356001600160401b038116811461251b57600080fd5b6000602082840312156127a2578081fd5b6127ab826126f9565b9392505050565b600060208083850312156127c4578182fd5b82356001600160401b038111156127d9578283fd5b8301601f810185136127e9578283fd5b80356127fc6127f782612e75565b612e45565b80828252848201915084840188868560051b870101111561281b578687fd5b8694505b8385101561284457612830816126f9565b83526001949094019391850191850161281f565b50979650505050505050565b60008060408385031215612862578081fd5b82356001600160401b03811115612877578182fd5b61288385828601612710565b925050612892602084016126f9565b90509250929050565b6000806000606084860312156128af578081fd5b83356001600160401b038111156128c4578182fd5b6128d086828701612710565b9350506128df602085016126f9565b91506128ed6040850161277a565b90509250925092565b600080600080600060a0868803121561290d578081fd5b85356001600160401b0380821115612923578283fd5b61292f89838a01612710565b96506020915061294082890161277a565b955061294e6040890161277a565b9450606088013560ff81168114612963578384fd5b9350608088013581811115612976578384fd5b8801601f81018a13612986578384fd5b80356129946127f782612e75565b8082825285820191508584018d878560051b87010111156129b3578788fd5b875b848110156129eb5786823511156129ca578889fd5b6129d98f898435890101612710565b845292870192908701906001016129b5565b50508096505050505050509295509295909350565b600060208284031215612a11578081fd5b5035919050565b600080600060608486031215612a2c578283fd5b83359250612a3c602085016126f9565b915060408401356001600160401b03811115612a56578182fd5b612a6286828701612710565b9150509250925092565b60008151808452612a84816020860160208601612edb565b601f01601f19169290920160200192915050565b80518252600060208083015160c082860152612ab760c0860182612a6c565b905060408401516001600160401b038082166040880152806060870151166060880152505060ff608085015116608086015260a084015185820360a08701528181518084528484019150848160051b8501018584019350865b82811015612b3e57601f19868303018452612b2c828651612a6c565b94870194938701939150600101612b10565b5098975050505050505050565b60008251612b5d818460208701612edb565b9190910192915050565b6000602080830181845280855180835260408601915060408160051b8701019250838701855b82811015612bbb57603f19888603018452612ba9858351612a98565b94509285019290850190600101612b8d565b5092979650505050505050565b60006020808301818452808551808352604092508286019150828160051b870101848801865b83811015612c6457888303603f19018552815180516001600160a01b03908116855288820151898601528782015160a08987018190529190612c3283880182612a6c565b606085810151909316928801929092525060809283015115159290950191909152509386019390860190600101612bee565b509098975050505050505050565b60208082526028908201527f566f74696e67206f6e6c7920616c6c6f77656420647572696e672074686520656040820152673632b1ba34b7b71760c11b606082015260800190565b6020808252601d908201527f53656e64657220616e6420766f74657220646f6e2774206d617463682e000000604082015260600190565b6020808252600e908201526d2737903832b936b4b9b9b4b7b71760911b604082015260600190565b6000602080835283518184015280840151604060c081860152612d3f60e0860183612a6c565b9150808601516001600160401b03808216606088015280606089015116608088015260ff60808901511660a088015260a08801519150601f19808886030160c08901528483518087528787019150878160051b8801018886019550895b82811015612ddd578489830301845286518051898452612dbe8a850182612a6c565b918c01518816938c0193909352968a0196938a01939150600101612d9c565b509b9a5050505050505050505050565b6020815260006127ab6020830184612a98565b85815260a060208201526000612e1960a0830187612a6c565b6001600160401b03958616604084015293909416606082015260ff919091166080909101529392505050565b604051601f8201601f191681016001600160401b0381118282101715612e6d57612e6d612f77565b604052919050565b60006001600160401b03821115612e8e57612e8e612f77565b5060051b60200190565b60008219821115612eab57612eab612f61565b500190565b60006001600160401b03808316818516808303821115612ed257612ed2612f61565b01949350505050565b60005b83811015612ef6578181015183820152602001612ede565b83811115612f05576000848401525b50505050565b600181811c90821680612f1f57607f821691505b60208210811415612f4057634e487b7160e01b600052602260045260246000fd5b50919050565b6000600019821415612f5a57612f5a612f61565b5060010190565b634e487b7160e01b600052601160045260246000fd5b634e487b7160e01b600052604160045260246000fdfea2646970667358221220fed690dc4dc23d37c22bba74ad3518da7794bb0531fb522670e9808940b2369f64736f6c63430008040033";
        public VotingSystemDeploymentBase() : base(BYTECODE) { }
        public VotingSystemDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class AddAddUserToElectionFunction : AddAddUserToElectionFunctionBase { }

    [Function("addAddUserToElection", typeof(AddAddUserToElectionOutputDTO))]
    public class AddAddUserToElectionFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "electionId", 1)]
        public virtual BigInteger ElectionId { get; set; }
        [Parameter("address", "voterAdress", 2)]
        public virtual string VoterAdress { get; set; }
        [Parameter("string", "voter", 3)]
        public virtual string Voter { get; set; }
    }

    public partial class AddAdminFunction : AddAdminFunctionBase { }

    [Function("addAdmin")]
    public class AddAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "newAdmin", 1)]
        public virtual string NewAdmin { get; set; }
    }

    public partial class AddAdminBatchFunction : AddAdminBatchFunctionBase { }

    [Function("addAdminBatch")]
    public class AddAdminBatchFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "newAdmins", 1)]
        public virtual List<string> NewAdmins { get; set; }
    }

    public partial class AddElectionFunction : AddElectionFunctionBase { }

    [Function("addElection")]
    public class AddElectionFunctionBase : FunctionMessage
    {
        [Parameter("string", "title", 1)]
        public virtual string Title { get; set; }
        [Parameter("uint64", "dateFrom", 2)]
        public virtual ulong DateFrom { get; set; }
        [Parameter("uint64", "dateTo", 3)]
        public virtual ulong DateTo { get; set; }
        [Parameter("uint8", "keysPerVoter", 4)]
        public virtual byte KeysPerVoter { get; set; }
        [Parameter("string[]", "candidateList", 5)]
        public virtual List<string> CandidateList { get; set; }
    }

    public partial class AddVoteFunction : AddVoteFunctionBase { }

    [Function("addVote")]
    public class AddVoteFunctionBase : FunctionMessage
    {
        [Parameter("string", "voter", 1)]
        public virtual string Voter { get; set; }
        [Parameter("address", "keyAdr", 2)]
        public virtual string KeyAdr { get; set; }
        [Parameter("uint64", "candidateId", 3)]
        public virtual ulong CandidateId { get; set; }
    }

    public partial class CheckVoteFunction : CheckVoteFunctionBase { }

    [Function("checkVote", "bool")]
    public class CheckVoteFunctionBase : FunctionMessage
    {
        [Parameter("string", "voter", 1)]
        public virtual string Voter { get; set; }
        [Parameter("address", "keyAdr", 2)]
        public virtual string KeyAdr { get; set; }
    }

    public partial class ElectionsFunction : ElectionsFunctionBase { }

    [Function("elections", typeof(ElectionsOutputDTO))]
    public class ElectionsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetDetailsFunction : GetDetailsFunctionBase { }

    [Function("getDetails", typeof(GetDetailsOutputDTO))]
    public class GetDetailsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class GetElectionsFunction : GetElectionsFunctionBase { }

    [Function("getElections", typeof(GetElectionsOutputDTO))]
    public class GetElectionsFunctionBase : FunctionMessage
    {

    }

    public partial class StartVoteFunction : StartVoteFunctionBase { }

    [Function("startVote", typeof(StartVoteOutputDTO))]
    public class StartVoteFunctionBase : FunctionMessage
    {
        [Parameter("string", "voter", 1)]
        public virtual string Voter { get; set; }
        [Parameter("address", "keyAdr", 2)]
        public virtual string KeyAdr { get; set; }
    }

    public partial class UserAddedToElectionEventDTO : UserAddedToElectionEventDTOBase { }

    [Event("UserAddedToElection")]
    public class UserAddedToElectionEventDTOBase : IEventDTO
    {
        [Parameter("tuple[]", "newKeys", 1, false )]
        public virtual List<Key> NewKeys { get; set; }
    }

    public partial class AddAddUserToElectionOutputDTO : AddAddUserToElectionOutputDTOBase { }

    [FunctionOutput]
    public class AddAddUserToElectionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "newKeys", 1)]
        public virtual List<Key> NewKeys { get; set; }
    }









    public partial class CheckVoteOutputDTO : CheckVoteOutputDTOBase { }

    [FunctionOutput]
    public class CheckVoteOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "voted", 1)]
        public virtual bool Voted { get; set; }
    }

    public partial class ElectionsOutputDTO : ElectionsOutputDTOBase { }

    [FunctionOutput]
    public class ElectionsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "ElectionId", 1)]
        public virtual BigInteger ElectionId { get; set; }
        [Parameter("string", "Title", 2)]
        public virtual string Title { get; set; }
        [Parameter("uint64", "DateFrom", 3)]
        public virtual ulong DateFrom { get; set; }
        [Parameter("uint64", "DateTo", 4)]
        public virtual ulong DateTo { get; set; }
        [Parameter("uint8", "KeysPerVoter", 5)]
        public virtual byte KeysPerVoter { get; set; }
    }

    public partial class GetDetailsOutputDTO : GetDetailsOutputDTOBase { }

    [FunctionOutput]
    public class GetDetailsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "Value", 1)]
        public virtual ElectionDetails Value { get; set; }
    }

    public partial class GetElectionsOutputDTO : GetElectionsOutputDTOBase { }

    [FunctionOutput]
    public class GetElectionsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "electionList", 1)]
        public virtual List<Election> ElectionList { get; set; }
    }

    public partial class StartVoteOutputDTO : StartVoteOutputDTOBase { }

    [FunctionOutput]
    public class StartVoteOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "el", 1)]
        public virtual Election El { get; set; }
    }
}