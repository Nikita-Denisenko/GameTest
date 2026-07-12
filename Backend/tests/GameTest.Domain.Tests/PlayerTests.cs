using GameTest.Domain.Entities;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Tests
{
    public class PlayerTests
    {
        private Player CreatePlayer()
        {
            return new Player(
                "Igor28",
                "test@test.com",
                "some_hash"
            );
        }

        [Fact]
        public void Constructor_ShouldCreatePlayer_WhenDataIsValid()
        {
            var player = CreatePlayer();

            Assert.Equal("Igor28", player.Nickname);
            Assert.Equal("test@test.com", player.Email);
            Assert.Equal("some_hash", player.PasswordHash);
            Assert.Equal(0, player.Gold);
            Assert.Equal(0, player.TotalKills);
        }

        [Fact]
        public void Constructor_ShouldThrowDomainException_WhenNicknameIsEmpty()
        {
            Assert.Throws<DomainException>(() =>
                new Player("", "test@test.com", "some_hash"));
        }

        [Fact]
        public void Constructor_ShouldThrowDomainException_WhenNicknameIsWhitespace()
        {
            Assert.Throws<DomainException>(() =>
                new Player("   ", "test@test.com", "some_hash"));
        }

        [Fact]
        public void Constructor_ShouldThrowDomainException_WhenEmailIsEmpty()
        {
            Assert.Throws<DomainException>(() =>
                new Player("Igor28", "", "some_hash"));
        }

        [Fact]
        public void Constructor_ShouldThrowDomainException_WhenEmailIsInvalid()
        {
            Assert.Throws<DomainException>(() =>
                new Player("Igor28", "@#test@test.com", "some_hash"));
        }

        [Fact]
        public void Constructor_ShouldThrowDomainException_WhenPasswordHashIsEmpty()
        {
            Assert.Throws<DomainException>(() =>
                new Player("Igor28", "test@test.com", ""));
        }

        [Fact]
        public void AddGold_ShouldIncreaseGold_WhenAmountIsPositive()
        {
            var player = CreatePlayer();

            player.AddGold(100);

            Assert.Equal(100, player.Gold);
        }

        [Fact]
        public void AddGold_ShouldThrowDomainException_WhenAmountIsNegative()
        {
            var player = CreatePlayer();

            Assert.Throws<DomainException>(() =>
                player.AddGold(-10));
        }

        [Fact]
        public void SpendGold_ShouldDecreaseGold_WhenEnoughGold()
        {
            var player = CreatePlayer();

            player.AddGold(200);
            player.SpendGold(50);

            Assert.Equal(150, player.Gold);
        }

        [Fact]
        public void SpendGold_ShouldAllowSpendingAllGold()
        {
            var player = CreatePlayer();

            player.AddGold(100);
            player.SpendGold(100);

            Assert.Equal(0, player.Gold);
        }

        [Fact]
        public void SpendGold_ShouldThrowDomainException_WhenNotEnoughGold()
        {
            var player = CreatePlayer();

            Assert.Throws<DomainException>(() =>
                player.SpendGold(50));
        }

        [Fact]
        public void SpendGold_ShouldThrowDomainException_WhenAmountIsNegative()
        {
            var player = CreatePlayer();

            Assert.Throws<DomainException>(() =>
                player.SpendGold(-10));
        }

        [Fact]
        public void AddKills_ShouldIncreaseKills_WhenAmountIsPositive()
        {
            var player = CreatePlayer();

            player.AddKills(25);

            Assert.Equal(25, player.TotalKills);
        }

        [Fact]
        public void AddKills_ShouldThrowDomainException_WhenAmountIsNegative()
        {
            var player = CreatePlayer();

            Assert.Throws<DomainException>(() =>
                player.AddKills(-15));
        }

        [Fact]
        public void ChangeNickname_ShouldChangeNickname_WhenNicknameIsValid()
        {
            var player = CreatePlayer();

            player.ChangeNickname("TestNickname");

            Assert.Equal("TestNickname", player.Nickname);
        }

        [Fact]
        public void ChangeNickname_ShouldThrowDomainException_WhenNicknameIsEmpty()
        {
            var player = CreatePlayer();

            Assert.Throws<DomainException>(() =>
                player.ChangeNickname(""));
        }

        [Fact]
        public void ChangeNickname_ShouldThrowDomainException_WhenNicknameIsWhitespace()
        {
            var player = CreatePlayer();

            Assert.Throws<DomainException>(() =>
                player.ChangeNickname("   "));
        }

        [Fact]
        public void ChangeEmail_ShouldChangeEmail_WhenEmailIsValid()
        {
            var player = CreatePlayer();

            player.ChangeEmail("test@new.com");

            Assert.Equal("test@new.com", player.Email);
        }

        [Fact]
        public void ChangeEmail_ShouldThrowDomainException_WhenEmailIsEmpty()
        {
            var player = CreatePlayer();

            Assert.Throws<DomainException>(() =>
                player.ChangeEmail(""));
        }

        [Fact]
        public void ChangeEmail_ShouldThrowDomainException_WhenEmailIsInvalid()
        {
            var player = CreatePlayer();

            Assert.Throws<DomainException>(() =>
                player.ChangeEmail("@@invalid%email"));
        }

        [Fact]
        public void ChangePassword_ShouldChangePasswordHash_WhenHashIsValid()
        {
            var player = CreatePlayer();

            player.ChangePassword("new_hash");

            Assert.Equal("new_hash", player.PasswordHash);
        }

        [Fact]
        public void ChangePassword_ShouldThrowDomainException_WhenPasswordHashIsEmpty()
        {
            var player = CreatePlayer();

            Assert.Throws<DomainException>(() =>
                player.ChangePassword(""));
        }

        [Fact]
        public void ChangePassword_ShouldThrowDomainException_WhenPasswordHashIsWhitespace()
        {
            var player = CreatePlayer();

            Assert.Throws<DomainException>(() =>
                player.ChangePassword("   "));
        }
    }
}