using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Objects.Sports;

namespace UnitTests
{
    [TestClass]
    public class BadmintonTest
    {
        [TestMethod]
        public void TestValidScore()
        {
            ISport sport = new Badminton();
            int home1 = 18;
            int away1 = 21;

            int home2 = 20;
            int away2 = 22;

            int home3 = 28;
            int away3 = 26;

            int home4 = 29;
            int away4 = 30;

            int home5 = 30;
            int away5 = 28;

            bool result1 = sport.ScoreIsValid(home1, away1);
            bool result2 = sport.ScoreIsValid(home2, away2);
            bool result3 = sport.ScoreIsValid(home3, away3);
            bool result4 = sport.ScoreIsValid(home4, away4);
            bool result5 = sport.ScoreIsValid(home5, away5);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
            Assert.IsTrue(result5);
        }

        [TestMethod]
        public void TestInvalidScore()
        {
            ISport sport = new Badminton();
            int home1 = 10;
            int away1 = 15;

            int home2 = 19;
            int away2 = 19;

            int home3 = 20;
            int away3 = 20;

            int home4 = 20;
            int away4 = 21;

            int home5 = 30;
            int away5 = 30;

            bool result1 = sport.ScoreIsValid(home1, away1);
            bool result2 = sport.ScoreIsValid(home2, away2);
            bool result3 = sport.ScoreIsValid(home3, away3);
            bool result4 = sport.ScoreIsValid(home4, away4);
            bool result5 = sport.ScoreIsValid(home5, away5);

            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
            Assert.IsFalse(result5);
        }
    }
}
