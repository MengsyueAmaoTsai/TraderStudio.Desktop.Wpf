using RichillCapital.SharedKernel;

namespace RichillCapital.TraderStudio.Domain;

public sealed class SignalSourceVisibility : Enumeration<SignalSourceVisibility>
{
    public static readonly SignalSourceVisibility Public = new(nameof(Public), 1);
    public static readonly SignalSourceVisibility Protected = new(nameof(Protected), 2);
    public static readonly SignalSourceVisibility Private = new(nameof(Private), 3);

    private SignalSourceVisibility(string name, int value) 
        : base(name, value)
    {
    }
}
