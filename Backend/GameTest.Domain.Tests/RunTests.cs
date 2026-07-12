using GameTest.Domain.Entities;
using GameTest.Domain.Exceptions;

namespace GameTest.Domain.Tests;

public class RunTests
{
    private readonly Guid _idempotencyKey = Guid.NewGuid();
    private readonly DateTime _startedAt = DateTime.UtcNow;


    [Fact]
    public void Constructor_ShouldCreateRun_WhenDataValid()
    {
        var run = new Run(
            _idempotencyKey,
            1,
            1,
            _startedAt,
            600,
            100,
            500,
            10);

        Assert.Equal(_idempotencyKey, run.IdempotencyKey);
        Assert.Equal(1, run.PlayerId);
        Assert.Equal(1, run.UnitId);
        Assert.Equal(_startedAt, run.StartedAt);
        Assert.Equal(600, run.DurationSeconds);
        Assert.Equal(100, run.Kills);
        Assert.Equal(500, run.GoldEarned);
        Assert.Equal(10, run.LevelReached);
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenPlayerIdInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Run(
                _idempotencyKey,
                0,
                1,
                _startedAt,
                600,
                100,
                500,
                10));
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenUnitIdInvalid()
    {
        Assert.Throws<DomainException>(() =>
            new Run(
                _idempotencyKey,
                1,
                0,
                _startedAt,
                600,
                100,
                500,
                10));
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenStartedAtDefault()
    {
        Assert.Throws<DomainException>(() =>
            new Run(
                _idempotencyKey,
                1,
                1,
                default,
                600,
                100,
                500,
                10));
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenDurationNegative()
    {
        Assert.Throws<DomainException>(() =>
            new Run(
                _idempotencyKey,
                1,
                1,
                _startedAt,
                0,
                100,
                500,
                10));
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenKillsNegative()
    {
        Assert.Throws<DomainException>(() =>
            new Run(
                _idempotencyKey,
                1,
                1,
                _startedAt,
                600,
                -1,
                500,
                10));
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenGoldEarnedNegative()
    {
        Assert.Throws<DomainException>(() =>
            new Run(
                _idempotencyKey,
                1,
                1,
                _startedAt,
                600,
                100,
                -1,
                10));
    }


    [Fact]
    public void Constructor_ShouldThrow_WhenLevelReachedNegative()
    {
        Assert.Throws<DomainException>(() =>
            new Run(
                _idempotencyKey,
                1,
                1,
                _startedAt,
                600,
                100,
                500,
                -1));
    }


    [Fact]
    public void Constructor_ShouldAllowZeroKills()
    {
        var run = new Run(
            _idempotencyKey,
            1,
            1,
            _startedAt,
            600,
            0,
            500,
            1);

        Assert.Equal(0, run.Kills);
    }


    [Fact]
    public void Constructor_ShouldAllowZeroGold()
    {
        var run = new Run(
            _idempotencyKey,
            1,
            1,
            _startedAt,
            600,
            10,
            0,
            1);

        Assert.Equal(0, run.GoldEarned);
    }
}