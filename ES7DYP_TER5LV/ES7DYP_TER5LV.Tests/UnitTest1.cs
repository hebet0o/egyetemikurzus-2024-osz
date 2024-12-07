using NUnit.Framework;
using ES7DYP_TER5LV;
using System.Linq;

namespace ES7DYP_TER5LV.Tests
{
    [TestFixture]
    public class FieldTests
    {
        [Test]
        public void Constructor_SetsInitialValues()
        {
            int x = 1;
            int y = 2;

            Field field = new Field(x, y);

            Assert.AreEqual(x, field.Position.X);
            Assert.AreEqual(y, field.Position.Y);
            Assert.IsFalse(field.IsMine);
            Assert.IsFalse(field.IsRevealed);
            Assert.IsFalse(field.IsFlagged);
            Assert.IsFalse(field.Selected);
            Assert.AreEqual(0, field.AdjacentMines);
        }

        [Test]
        public void IsMine_CanBeSetAndGet()
        {
            Field field = new Field(0, 0);

            field.IsMine = true;

            Assert.IsTrue(field.IsMine);
        }

        [Test]
        public void IsRevealed_CanBeSetAndGet()
        {
            Field field = new Field(0, 0);

            field.IsRevealed = true;

            Assert.IsTrue(field.IsRevealed);
        }
    }

    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void Constructor_SetsCorrectDimensions()
        {
            int width = 8;
            int height = 8;
            int mineCount = 10;

            Board board = new Board(width, height, mineCount);

            Assert.AreEqual(width, board.Width);
            Assert.AreEqual(height, board.Height);
            Assert.AreEqual(mineCount, board.MineCount);
        }

        [Test]
        public void Initialize_CreatesCorrectNumberOfFields()
        {
            Board board = new Board(8, 8, 10);

            board.Initialize();

            Assert.AreEqual(64, board.Fields.Count());
        }

        [Test]
        public void Initialize_PlacesCorrectNumberOfMines()
        {
            Board board = new Board(8, 8, 10);

            board.Initialize();

            int mineCount = board.Fields.Count(f => f.IsMine);
            Assert.AreEqual(10, mineCount);
        }
    }

    [TestFixture]
    public class MineSweeperGameTests
    {
        [Test]
        public void Constructor_InitializesGame()
        {
            MineSweeperGame game = new MineSweeperGame(8, 8, 10);

            Assert.IsNotNull(game);
            // Add more assertions based on your implementation
        }

        [Test]
        public void RevealField_RevealsMine_ReturnsTrue()
        {
            MineSweeperGame game = new MineSweeperGame(8, 8, 64); // All fields are mines

            bool result = game.RevealField(0, 0);

            Assert.IsTrue(result);
            Assert.IsTrue(game.IsGameOver());
        }

        [Test]
        public void RevealField_RevealsEmptyField_ReturnsFalse()
        {
            MineSweeperGame game = new MineSweeperGame(8, 8, 0); // No mines

            bool result = game.RevealField(0, 0);

            Assert.IsFalse(result);
            Assert.IsFalse(game.IsGameOver());
        }
    }
}