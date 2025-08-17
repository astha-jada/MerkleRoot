using System.Text;
using System.Security.Cryptography;

namespace MerkleRoot;

public class MerkleRootClass
{
    // Function to calculate concatenated hashed for a tag
    public static byte[] GetConcatenatedHashedTag(string tag)
    {
        SHA256 hash = SHA256.Create();
        byte[] hashedTag = hash.ComputeHash(Encoding.UTF8.GetBytes(tag));
        byte[] concatenatedHashedTag = hashedTag.Concat(hashedTag).ToArray();
        return concatenatedHashedTag;
    }

    // Function to calculate final hash of hashed tag and a string
    public static string GetCompleteTaggedHash(string str, byte[] hashedTag)
    {
        return GetSHA256Hash(hashedTag.Concat(Encoding.UTF8.GetBytes(str)).ToArray());
    }

    // Function to get SHA256 Hash for a byte Array
    public static string GetSHA256Hash(byte[] strBytes)
    {
        using (SHA256 hash = SHA256.Create())
        {
            byte[] bytes = hash.ComputeHash(strBytes);

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }

    public static string ComputeMerkleRoot(IList<string> leaves, byte[] hashedTag)
    {
        if (!leaves.Any())
        {
            return string.Empty;
        }
        if (leaves.Count() == 1)
        {
            return leaves.First();
        }

        if (leaves.Count() % 2 != 0)
        {
            leaves.Add(leaves.Last()); // Duplicate last entry when the length of leaves is odd
        }

        var branches = new List<string>();

        for (int i = 0; i < leaves.Count(); i += 2)
        {
            var leavesPair = string.Concat(leaves[i], leaves[i + 1]);
            branches.Add(GetCompleteTaggedHash(leavesPair, hashedTag));
        }

        return ComputeMerkleRoot(branches, hashedTag);
    }
}
