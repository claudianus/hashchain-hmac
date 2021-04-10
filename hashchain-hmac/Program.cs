using System;
using System.Security.Cryptography;
using System.Text;

namespace hashchain_hmac {
  internal static class Program {
    private static void Main() {
      Console.WriteLine("hello world");
      const int hashchainLength = 1000_0000;
      var randomBytes = new byte[1000];
      using var rng = new RNGCryptoServiceProvider();
      rng.GetBytes(randomBytes);
      var previousHash = randomBytes;
      const string hmacKey = "hello world";
      using var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(hmacKey));
      for (int i = 0; i < hashchainLength; i++) {
        previousHash = hmac.ComputeHash(previousHash);
        // var hashString = BitConverter.ToString(previousHash).Replace("-", string.Empty).ToLowerInvariant();
        // Console.WriteLine($"{i} {hashString}");
      }
      Console.WriteLine("done");
    }
  }
}