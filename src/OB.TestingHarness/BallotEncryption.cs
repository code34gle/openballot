using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OB.Data.Entities;
using OB.Data.Models;
using OB.Data.Services;
using System;
using System.Linq;

namespace OB.TestingHarness
{
    [TestClass]
    public class BallotEncryption
    {
        //-----------------------------------------
        Ballot ballot { get; set; }
        AesCrypto crypto { get; set; }
        string encrypted { get; set; }
        string decrypted { get; set; }

        //-----------------------------------------
        //------------------------------------------------------------------------------------------------
        public BallotEncryption()
        {
            //-----------------------------------------
            AesOptions aesOptions = new AesOptions();
            aesOptions.AesPassword = "AN3wD4yB3g!nsW!th4N3wD4wn";

            IOptions<AesOptions> options = Options.Create(aesOptions);
            crypto = new AesCrypto(options);
            //-----------------------------------------

            ballot = createTestBallot();

            decrypted = JsonConvert.SerializeObject(ballot);

        }

        //------------------------------------------------------------------------------------------------
        [TestMethod]
        public void BallotExists()
        {
            Assert.IsNotNull(ballot);
        }

        //------------------------------------------------------------------------------------------------
        [TestMethod]
        public void CandidateA_Selected()
        {
            Office office = ballot.Offices.FirstOrDefault(o => o.Id == 1);
            Candidate candidate = office.Candidates.FirstOrDefault(c => c.Id == 1);
            Assert.IsTrue(candidate.IsSelected);
        }

        //------------------------------------------------------------------------------------------------
        [TestMethod]
        public void Encrypt_Decrypt_Ballot()
        {
            string registrantKey = "a-dash-of-salt";
            string json = JsonConvert.SerializeObject(ballot);

            encrypted = crypto.Encrypt(json, registrantKey);

            Assert.IsNotNull(encrypted);
            Assert.IsTrue(json == decrypted);
            Assert.IsTrue(encrypted != decrypted);
     
            json = crypto.Decrypt(encrypted, registrantKey);

            Ballot localBallot = JsonConvert.DeserializeObject<Ballot>(json);

            Assert.IsNotNull(json);
            Assert.IsNotNull(localBallot);
            Assert.IsTrue(json == decrypted);
            Assert.IsInstanceOfType(localBallot, typeof(Ballot));
        }


        //------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------
        private Ballot createTestBallot()
        {
            ballot = new Ballot();

            Office office = new Office()
            {
                Id = 1,
                Name = "Dog Catcher",
                Description = "Making your life less aggravating.",
                DateCreated = DateTime.UtcNow
            };

            Candidate candidateA = new Candidate()
            {
                Id = 1,
                OfficeId = 1,
                FirstName = "Bob",
                LastName = "Kratchet",
                Party = "Republican",
                IsIncumbant = false,
                IsSelected = true,
                Statement = "My bark is worse than my bite.",
                DateCreated = DateTime.UtcNow
            };

            Candidate candidateB = new Candidate()
            {
                Id = 2,
                OfficeId = 1,
                FirstName = "Mark",
                LastName = "Milktoast",
                Party = "Democrat",
                IsIncumbant = true,
                Statement = "It's a Dog eat Dog world.",
                DateCreated = DateTime.UtcNow
            };

            office.Candidates.Add(candidateA);
            office.Candidates.Add(candidateB);
            ballot.Offices.Add(office);

            return ballot;
        }


    }
}
