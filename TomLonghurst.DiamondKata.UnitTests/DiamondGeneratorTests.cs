namespace TomLonghurst.DiamondKata.UnitTests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class DiamondGeneratorTests
{
    private readonly DiamondGenerator _diamondGenerator;

    public DiamondGeneratorTests()
    {
        _diamondGenerator = new DiamondGenerator();
    }

    [Test]
    public void When_Character_A_Then_Generate_A()
    {
        var diamond = _diamondGenerator.GenerateDiamond('A');
        
        Assert.That(diamond, Is.EqualTo("A"));
    }
    
    [Test]
    public void When_Character_B_Then_Generate_A_And_B_Diamond()
    {
        var diamond = _diamondGenerator.GenerateDiamond('B');
        
        Assert.That(diamond, Is.EqualTo(@" A
B B
 A"));
    }
    
    [Test]
    public void When_Character_C_Then_Generate_A_And_B_And_C_Diamond()
    {
        var diamond = _diamondGenerator.GenerateDiamond('C');
        
        Assert.That(diamond, Is.EqualTo(@"  A
 B B
C   C
 B B
  A"));
    }
    
    [Test]
    public void When_Character_F_Then_Generate_Valid_Diamond()
    {
        var diamond = _diamondGenerator.GenerateDiamond('F');
        
        Assert.That(diamond, Is.EqualTo(@"     A
    B B
   C   C
  D     D
 E       E
F         F
 E       E
  D     D
   C   C
    B B
     A"));
    }

    [Test]
    public void When_Character_M_Then_Generate_Valid_Diamond()
    {
     var diamond = _diamondGenerator.GenerateDiamond('M');

     Assert.That(diamond, Is.EqualTo(@"            A
           B B
          C   C
         D     D
        E       E
       F         F
      G           G
     H             H
    I               I
   J                 J
  K                   K
 L                     L
M                       M
 L                     L
  K                   K
   J                 J
    I               I
     H             H
      G           G
       F         F
        E       E
         D     D
          C   C
           B B
            A"));
    }

    [Test]
    public void When_Character_Z_Then_Generate_Valid_Diamond()
    {
        var diamond = _diamondGenerator.GenerateDiamond('Z');
        
        Assert.That(diamond, Is.EqualTo(@"                         A
                        B B
                       C   C
                      D     D
                     E       E
                    F         F
                   G           G
                  H             H
                 I               I
                J                 J
               K                   K
              L                     L
             M                       M
            N                         N
           O                           O
          P                             P
         Q                               Q
        R                                 R
       S                                   S
      T                                     T
     U                                       U
    V                                         V
   W                                           W
  X                                             X
 Y                                               Y
Z                                                 Z
 Y                                               Y
  X                                             X
   W                                           W
    V                                         V
     U                                       U
      T                                     T
       S                                   S
        R                                 R
         Q                               Q
          P                             P
           O                           O
            N                         N
             M                       M
              L                     L
               K                   K
                J                 J
                 I               I
                  H             H
                   G           G
                    F         F
                     E       E
                      D     D
                       C   C
                        B B
                         A"));
    }
}