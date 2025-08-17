
using System.Collections.Generic;
using Xunit;
using MerkleRoot;

namespace TestMerkleRoot;

public class TestMerkleRoot
{
    [Fact]
    public void TestGivenArray()
    {
        byte[] hashedTag = MerkleRootClass.GetConcatenatedHashedTag("Bitcoin_Transaction"); // Calculate concatenated hash for a tag

        List<string> leaves = new List<string> { "aaa", "bbb", "ccc", "ddd", "eee" };
        string rootHash = MerkleRootClass.ComputeMerkleRoot(leaves, hashedTag);

        Assert.Equal("525118d23aa0c18f32bf19cbb5a226b15c6dbc82217c2703b34a7c8d36ea8ba1", rootHash);
    }

    [Fact]
    public void TestEmptyArray()
    {
        byte[] hashedTag = MerkleRootClass.GetConcatenatedHashedTag("Bitcoin_Transaction"); // Calculate concatenated hash for a tag

        List<string> leaves = new List<string> { };
        string rootHash = MerkleRootClass.ComputeMerkleRoot(leaves, hashedTag);

        Assert.Equal("", rootHash);
    }
}