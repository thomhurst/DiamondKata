namespace TomLonghurst.DiamondKata.UnitTests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class DiamondKataWorkerTests
{
    private readonly DiamondKataWorker _diamondKataWorker;
    private readonly Mock<IPrinter> _printer;
    private readonly Mock<IDiamondGenerator> _diamondGenerator;
    private readonly Mock<ICharacterValidator> _characterValidator;
    private readonly Mock<IInputReceiver> _inputReceiver;

    public DiamondKataWorkerTests()
    {
        _printer = new Mock<IPrinter>();
        _diamondGenerator = new Mock<IDiamondGenerator>();
        _characterValidator = new Mock<ICharacterValidator>();
        _inputReceiver = new Mock<IInputReceiver>();
        
        _diamondKataWorker = new DiamondKataWorker(
            _inputReceiver.Object,
            _characterValidator.Object,
            _diamondGenerator.Object,
            _printer.Object
            );
    }

    [Test]
    public async Task When_Character_In_Program_Args_Then_Do_Not_Call_Input_Receiver()
    {
        _characterValidator.Setup(x => x.Validate(It.IsAny<string?>()))
            .Returns(ValidationResult.Success);
        
        await _diamondKataWorker.Start(new[] { "B" });
        
        _inputReceiver.Verify(x => x.GetInput(), Times.Never);
    }
    
    [Test]
    public async Task When_Valid_Character_Then_Pass_Character_To_Generator()
    {
        _characterValidator.Setup(x => x.Validate(It.IsAny<string?>()))
            .Returns(ValidationResult.Success);
        
        await _diamondKataWorker.Start(new[] { "B" });
        
        _diamondGenerator.Verify(x => x.GenerateDiamond('B'), Times.Once);
    }
    
    [Test]
    public async Task When_Character_In_Program_Args_Fails_Validation_Then_Call_Input_Receiver()
    {
        _characterValidator.Setup(x => x.Validate("BB"))
            .Returns(ValidationResult.Failure("Oops"));
        
        _characterValidator.Setup(x => x.Validate("A"))
            .Returns(ValidationResult.Success);

        _inputReceiver.Setup(x => x.GetInput())
            .ReturnsAsync("A");
        
        await _diamondKataWorker.Start(new[] { "BB" });
        
        _inputReceiver.Verify(x => x.GetInput(), Times.Once);
    }
    
    [Test]
    public void When_Character_In_InputReceiver_Fails_Validation_Then_Throw_ValidationException()
    {
        _characterValidator.Setup(x => x.Validate("AA"))
            .Returns(ValidationResult.Failure("Oops"));

        _inputReceiver.Setup(x => x.GetInput())
            .ReturnsAsync("AA");

        Assert.That(() => _diamondKataWorker.Start(Array.Empty<string>()),
            Throws.TypeOf<ValidationException>());
    }
    
    [Test]
    public async Task When_Diamond_Generated_Then_Printer_Passed_Diamond_Value()
    {
        _characterValidator.Setup(x => x.Validate(It.IsAny<string?>()))
            .Returns(ValidationResult.Success);

        const string diamond = "A";
        
        _diamondGenerator.Setup(x => x.GenerateDiamond('A'))
            .Returns(diamond);

        await _diamondKataWorker.Start(new[] { "A" });

        _printer.Verify(x => x.Print(diamond), Times.Once);
    }
}