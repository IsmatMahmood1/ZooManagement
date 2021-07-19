//using System.Collections.Generic;
//using System.Linq;
//using ZooManagement.Models.Database;

//namespace ZooManagement.Data
//{
//    public static class SampleData
//    {
//        public static int NumberOfUsers = 100;

//        private static IList<IList<string>> _data = new List<IList<string>>
//        {
//            new List<string> { "Kania", "Placido", "kplacido0", "kplacido0@qq.com" },
//            new List<string> { "Scotty", "Gariff", "sgariff1", "sgariff1@biblegateway.com" },
//            new List<string> { "Colly", "Burgiss", "cburgiss2", "cburgiss2@amazon.co.uk" },
//            new List<string> { "Barnie", "Percival", "bpercival3", "bpercival3@cmu.edu" },
//            new List<string> { "Brandon", "Narraway", "bnarraway4", "bnarraway4@trellian.com" },
//        };

//        public static IEnumerable<User> GetUsers()
//        {
//            return Enumerable.Range(0, NumberOfUsers).Select(CreateRandomUser);
//        }

//        private static User CreateRandomUser(int index)
//        {
//            return new User
//            {
//                FirstName = _data[index][0],
//                LastName = _data[index][1],
//                Username = _data[index][2],
//                Email = _data[index][3],
//                ProfileImageUrl = ImageGenerator.GetProfileImage(_data[index][2]),
//                CoverImageUrl = ImageGenerator.GetCoverImage(index),
//                Salt = salt,
//                HashedPassword = UsersRepo.CreateHash(salt, "Password1")
//            };
//        }
//    }
//}