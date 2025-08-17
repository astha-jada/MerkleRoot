# MerkleRoot

This project implements calculation of Merkle Root hash for the Coding Test in C#.

## Tag MerkleRootv1.0
- This tag includes project MerkleRoot for calculation of merkle root hash for list ["aaa","bbb","ccc","ddd","eee”] with hash tag "Bitcoin_Transaction".
- It also includes TestMerkleRoot project to test merkle root hash for above.
- Merkle root hash can be found in file TestMerkleRoot/TestArray.cs

## Tag MerkleRootv2.0
- In adition to above this tag inlcludes WebAPI to get the merkle root hash for user in memory database.
- The project MerkleRoot was updated to handle different hash tag for leaves and branches.
- The corresponding test was also updated.
- To get the merkle root hash:
    - Run project ProofOfReserveWebAPI and in web browser query: https://localhost:7121/proofofreserve/getmerkleroot


## TODO:
- As only hash was stored instead of actual nodes due to oversight, the project needs to be modified to store nodes for calculating and verifiying Merkle proof.