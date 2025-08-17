using Microsoft.AspNetCore.Mvc;
using MerkleRoot;

namespace ProofOfReserveWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProofOfReserveController : ControllerBase
{
    private static readonly string[] Users = new[]
    {
       "(1,1111)","(2,2222)","(3,3333)","(4,4444)","(5,5555)","(6,6666)","(7,7777)","(8,8888)"
    };

    [HttpGet]

    public string Info()
    {
        return "Use /getmerkleroot for merkle root and getmerkleproof/{userid} for merkle proof";
    }


    [HttpGet("getmerkleroot")]

    public string GetMerkleRoot()
    {
        byte[] leafTag = MerkleRootClass.GetConcatenatedHashedTag("ProofOfReserve_Leaf");
        byte[] branchTag = MerkleRootClass.GetConcatenatedHashedTag("ProofOfReserve_Branch");
        string rootHash = MerkleRootClass.ComputeMerkleRoot(Users, leafTag, branchTag);

        return rootHash;
    }
}
