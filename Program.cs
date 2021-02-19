using System;
using System.Security.Cryptography;
using System.Text;


namespace Merkle_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            string tx1Hash = "aad28e85f31ae79339b49d114d7c1811d2c667681a1904ebbc326842a0a81985";
            string tx2Hash = "b963d3426088217357b146d5600817c54f93c2ea1a23126988e36460015ffc0e";
            string tx3Hash = "82498f4da1e1b662b02e95150dc9fd64307ee96b35657f75c7abd82530168ce3";
            string tx4Hash = "ceecfd37686a3ed1759d3cef25e412a800fc8e8846154dbe2a2d72b2af3e3b64";


            // 1. Concatenate the formatted TX1 and TX2 hashes (the TX1 hash should be before the TX2 hash)
            string tx1_2Hash = tx1Hash + tx2Hash;

            // 2. Hash the TX1 + TX2 concatenation TWICE using SHA-256. You need to use the lowercase hexadecimal representation(without
            // dashes/ hyphens) output by the SHA-256 hashing algorithm as the input for hashing a second time.

                //first hash run
            byte[] tx1_2Bytes = Encoding.ASCII.GetBytes(tx1_2Hash);
            string tx1_2Hash_first = BitConverter.ToString(SHA256.Create().ComputeHash(tx1_2Bytes)).Replace("-", "").ToLower();
                //second hash run
            string tx12Hash = BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(tx1_2Hash_first))).Replace("-", "").ToLower();

            Console.WriteLine("Tx12 Hash: " + tx12Hash);

            // 3. Now that you have the TX12 hash, do the same process for the TX34 hash by concatenating the TX3 and TX4 hashes and hashing them
            // twice using SHA-256.

            string tx3_4Hash = tx3Hash + tx4Hash;

            byte[] tx3_4Bytes = Encoding.ASCII.GetBytes(tx3_4Hash);
            string tx3_4Hash_first = BitConverter.ToString(SHA256.Create().ComputeHash(tx3_4Bytes)).Replace("-", "").ToLower();
            string tx34Hash = BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(tx3_4Hash_first))).Replace("-", "").ToLower();
            Console.WriteLine("Tx34 Hash: " + tx34Hash);

            // 4. With the TX12 and TX34 hashes you are ready to calculate the Merkle Root(in this case the TX1234 hashes). Concatenate TX12 with
            // TX34 and hash this data twice using SHA-256.

            string tx12_34Hash = tx12Hash + tx34Hash;

            byte[] tx12_34bytes = Encoding.ASCII.GetBytes(tx12_34Hash);
            string tx12_34Hash_first = BitConverter.ToString(SHA256.Create().ComputeHash(tx12_34bytes)).Replace("-", "").ToLower();
            string tx1234Hash = BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(tx12_34Hash_first))).Replace("-", "").ToLower();
            Console.WriteLine("Merkle Root: " + tx1234Hash);

        }
    }
}
